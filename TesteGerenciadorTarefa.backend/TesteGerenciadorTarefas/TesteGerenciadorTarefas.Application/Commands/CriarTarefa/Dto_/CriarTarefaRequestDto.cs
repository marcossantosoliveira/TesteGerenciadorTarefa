using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciadorTarefas.Application.Commands.CriarTarefa.Dto_
{
    public class CriarTarefaRequestDto : IRequest<CriarTarefaResponseDto>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
                
    }
}
