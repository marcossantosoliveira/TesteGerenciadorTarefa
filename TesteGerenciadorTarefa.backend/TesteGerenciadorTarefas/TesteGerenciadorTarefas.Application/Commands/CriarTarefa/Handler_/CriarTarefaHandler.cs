using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteGerenciadorTarefas.Application.Commands.CriarTarefa.Dto_;
using TesteGerenciadorTarefas.Domain.Dto_;
using TesteGerenciadorTarefas.Domain.Interfaces.Services;

namespace TesteGerenciadorTarefas.Application.Commands.CriarTarefa.Handler_
{
    public class CriarTarefaHandler : IRequestHandler<CriarTarefaRequestDto, CriarTarefaResponseDto>
    {

        private readonly ITarefaDomainService _tarefaService;

        public CriarTarefaHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<CriarTarefaResponseDto> Handle(CriarTarefaRequestDto request, CancellationToken cancellationToken)
        {         

            var tarefaDto = new TarefaDto();            
            var tarefaResponse = new CriarTarefaResponseDto();

            if (request == null)
            {
                tarefaResponse.Mensagem = "Todos os campos são obrigatório";

                return tarefaResponse;
            }
                        
            tarefaDto.Descricao = request.Descricao;
            tarefaDto.Data = DateTime.Now.Date;
            tarefaDto.Status = false;

            var tarefaRetornoService = await _tarefaService.CriarTarefaAsync(tarefaDto);

            if (tarefaRetornoService ==  null)
            {
                tarefaResponse.Mensagem = "Erro ao criar tarefa";

                return tarefaResponse;
            }

            tarefaResponse.Mensagem = "Tarefa cadastrada com sucesso";
            tarefaResponse.Id = tarefaRetornoService;

            return tarefaResponse;
        }
    }
}
