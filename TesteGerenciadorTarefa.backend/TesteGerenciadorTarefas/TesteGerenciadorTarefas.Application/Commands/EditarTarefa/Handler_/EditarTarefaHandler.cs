﻿using MediatR;
using TesteGerenciadorTarefas.Application.Commands.EditarTarefa.Dto_;
using TesteGerenciadorTarefas.Domain.Dto_;
using TesteGerenciadorTarefas.Domain.Interfaces.Services;

namespace TesteGerenciadorTarefas.Application.Commands.EditarTarefa.Handler_
{
    public class EditarTarefaHandler : IRequestHandler<EditarTarefaRequestDto, EditarTarefaResponseDto>
    {

        private readonly ITarefaDomainService _tarefaService;

        public EditarTarefaHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<EditarTarefaResponseDto> Handle(EditarTarefaRequestDto request, CancellationToken cancellationToken)
        {         

            var tarefaDto = new TarefaDto();            
            var tarefaResponse = new EditarTarefaResponseDto();

            if (request == null)
            {
                tarefaResponse.Mensagem = "Todos os campos são obrigatório";

                return tarefaResponse;
            }

            tarefaDto.Id = request.Id;
            tarefaDto.Descricao = request.Descricao;
            tarefaDto.Status = request.Status;

            var tarefaRetornoService = await _tarefaService.EditarTarefaAsync(request.Id, tarefaDto);

            if (!tarefaRetornoService)
            {
                tarefaResponse.Mensagem = "Tarefa ja foi concluida";

                return tarefaResponse;
            }

            tarefaResponse.Mensagem = "Tarefa Editada com sucesso";
            
            return tarefaResponse;
        }
    }
}