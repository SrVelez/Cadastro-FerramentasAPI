using Cadastro_de_Ferramentas.Models;

namespace Cadastro_de_Ferramentas.Handlers.Contracts
{
    public interface IFerramentaHandler
    {

        Task<Ferramenta> AddFerramentaAsync(Ferramenta ferramenta);

        Task<bool> RemoveFerramentaAsync(int ferramenta);

        Task<Ferramenta?> GetFerramentaByIdAsync(int ferramentaId);

        Task<List<Ferramenta>> GetAllFerramentasAsync();

        Task<Ferramenta> UpdateFerramentaAsync(int ferramentaId, Ferramenta ferramenta);
    }
}
