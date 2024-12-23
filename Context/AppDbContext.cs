using System.Reflection;
using Cadastro_de_Ferramentas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_Ferramentas.Context
{

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Ferramenta> Ferramentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
