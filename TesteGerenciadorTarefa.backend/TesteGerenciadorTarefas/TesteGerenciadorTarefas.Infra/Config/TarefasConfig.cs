using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteGerenciadorTarefas.Domain.Entities;

namespace TesteGerenciadorTarefas.Infra.Config
{
    public class TarefasConfig : IEntityTypeConfiguration<TarefaEntities>
    {
        public void Configure(EntityTypeBuilder<TarefaEntities> builder)
        {
            builder.Property(p => p.Id)                  
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .HasMaxLength(200);                 

            builder.Property(p => p.Data);

            builder.Property(p => p.Status);
                   

        }
    }
}
