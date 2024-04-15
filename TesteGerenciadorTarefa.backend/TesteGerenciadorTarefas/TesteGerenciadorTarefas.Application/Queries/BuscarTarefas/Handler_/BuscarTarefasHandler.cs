using MediatR;
using TesteGerenciadorTarefas.Application.Queries.BuscarTarefas.Dto_;
using TesteGerenciadorTarefas.Domain.Dto_;
using TesteGerenciadorTarefas.Domain.Interfaces.Services;

namespace TesteGerenciadorTarefas.Application.Queries.BuscarTarefas.Handler_
{
    public class BuscarTarefasHandler : IRequestHandler<BuscarTarefasRequestDto, List<BuscarTarefasResponseDto>>
    {

        private readonly ITarefaDomainService _tarefaService;

        public BuscarTarefasHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<List<BuscarTarefasResponseDto>> Handle(BuscarTarefasRequestDto request, CancellationToken cancellationToken)
        {

            var tarefasResponse = new List<BuscarTarefasResponseDto>();
            var tarefaRetornoService = await _tarefaService.BuscarTarefasAsync();

            foreach (var itemRetorno in tarefaRetornoService)
            {
                var tarefaItem = new BuscarTarefasResponseDto
                {
                    Id = itemRetorno.Id,
                    Descricao = itemRetorno.Descricao,
                    Data = itemRetorno.Data,
                    Status = itemRetorno.Status
                };

                tarefasResponse.Add(tarefaItem);
            }

            return tarefasResponse;
        }
    }
}
