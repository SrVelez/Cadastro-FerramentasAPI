using Cadastro_de_Ferramentas.Context;
using Cadastro_de_Ferramentas.Handlers.Contracts;
using Cadastro_de_Ferramentas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_Ferramentas.Handlers
{
    public class FerramentaHandler(AppDbContext context) : IFerramentaHandler
    {
        public async Task<Ferramenta> AddFerramentaAsync(Ferramenta ferramenta)
        {
            try
            {
                await context.Ferramentas.AddAsync(ferramenta);
                await context.SaveChangesAsync();

                return ferramenta;
            }
            catch (Exception err) 
            {
                throw new Exception("Nao foi Possivel Cadastrar o produto. " + err.Message);
            }
        }

        public async Task<List<Ferramenta>> GetAllFerramentasAsync()
        {
            try
            {
                var ferramenta = await context.Ferramentas
                    .Include(x => x.Cliente)
                    .AsNoTracking()
                    .ToListAsync();

                return ferramenta;
            }
            catch (Exception err)
            {
                throw new Exception("Nao foi Possivel encontrar os produtos. " + err.Message);
            }
        }

        public async Task<Ferramenta?> GetFerramentaByIdAsync(int ferramentaId)
        {
            try
            {
                var ferramenta = await context.Ferramentas
                    .AsNoTracking()
                    .Where(x => x.Id == ferramentaId)
                    .FirstOrDefaultAsync();

                if (ferramenta == null)
                {
                    return null;
                }
                return ferramenta;
            }
            catch (Exception err) 
            {
                throw new Exception("Nao foi Possivel localizar os produtos. " + err.Message);
            }
        }

        public async Task<bool> RemoveFerramentaAsync(int ferramentaId)
        {
            try
            {
                var ferramenta = await context.Ferramentas
               .Where(x => x.Id == ferramentaId)
               .FirstOrDefaultAsync();

                if (ferramenta == null)
                {
                    throw new Exception("Nao foi Possivel localizar o produto para deletar.");
                }

                context.Remove(ferramenta);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception err) 
            {
                throw new Exception("Nao foi Possivel deletar o produto." + err.Message);
            }
        }

        public async Task<Ferramenta> UpdateFerramentaAsync(int ferramentaId, Ferramenta ferramenta)
        {
            try
            {
                var FerramentaSearch = await context.Ferramentas
                    .Where(x => x.Id == ferramentaId)
                    .FirstOrDefaultAsync();

                if (FerramentaSearch == null)
                {
                    throw new Exception("Nao foi Possivel localizar o produto para alterar.");
                }

                FerramentaSearch.NomeDaFerramenta = ferramenta.NomeDaFerramenta;
                FerramentaSearch.ClienteId = ferramenta.ClienteId;
                FerramentaSearch.Descricao = ferramenta.Descricao;
                FerramentaSearch.DataPedido = ferramenta.DataPedido;

                context.Ferramentas.Update(FerramentaSearch);

                await context.SaveChangesAsync();

                return FerramentaSearch;
            }
            catch (Exception err) 
            {
                throw new Exception("Nao foi Possivel alterar o produto." + err.Message);
            }
        }
    }

   
}
