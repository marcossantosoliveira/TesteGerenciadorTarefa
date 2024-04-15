using Microsoft.EntityFrameworkCore;
using TesteGerenciadorTarefas.Domain.Entities;
using TesteGerenciadorTarefas.Infra.Config;

namespace TesteGerenciadorTarefas.Infra.Context
{

    public class BdContexto : DbContext
    {



        public BdContexto(DbContextOptions<BdContexto> opcoes) : base(opcoes)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbTarefa;Integrated Security=True;" +
                                             "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                                               "Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        public DbSet<TarefaEntities> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TarefasConfig());
        }
    }
}
