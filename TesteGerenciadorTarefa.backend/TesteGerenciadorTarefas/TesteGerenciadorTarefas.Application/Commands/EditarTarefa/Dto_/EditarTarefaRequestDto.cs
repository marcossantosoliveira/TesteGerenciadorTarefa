using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciadorTarefas.Application.Commands.EditarTarefa.Dto_
{
    public class EditarTarefaRequestDto : IRequest<EditarTarefaResponseDto>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; }
    }
}
