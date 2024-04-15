﻿using MediatR;
using TesteGerenciadorTarefas.Application.Commands.ExcluirTarefa.Dto_;
using TesteGerenciadorTarefas.Domain.Dto_;
using TesteGerenciadorTarefas.Domain.Interfaces.Services;

namespace TesteGerenciadorTarefas.Application.Commands.CriarTarefa.Handler_
{
    public class ExcluirTarefaHandler : IRequestHandler<ExcluirTarefaRequestDto, ExcluirTarefaResponseDto>
    {

        private readonly ITarefaDomainService _tarefaService;

        public ExcluirTarefaHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<ExcluirTarefaResponseDto> Handle(ExcluirTarefaRequestDto request, CancellationToken cancellationToken)
        {       
         
            var tarefaResponse = new ExcluirTarefaResponseDto();
                                  
      
            var tarefaRetornoService = await _tarefaService.ExcluirTarefaAsync(request.Id);

            if (!tarefaRetornoService)
            {
                tarefaResponse.Mensagem = "Não é possivel excluir tarefa que não foi concluida";

                return tarefaResponse;
            }

            tarefaResponse.Mensagem = "Tarefa excluida com sucesso";
           
            return tarefaResponse;
        }
    }
}
