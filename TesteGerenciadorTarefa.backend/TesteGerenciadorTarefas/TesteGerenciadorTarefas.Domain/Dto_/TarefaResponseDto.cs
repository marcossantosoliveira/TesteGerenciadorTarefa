using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciadorTarefas.Domain.Dto_
{
    public class TarefaResponseDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; }
    }
}
