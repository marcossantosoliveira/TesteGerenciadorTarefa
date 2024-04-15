using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciadorTarefas.Domain.Entities
{
    public class TarefaEntities
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; }
    }
}
