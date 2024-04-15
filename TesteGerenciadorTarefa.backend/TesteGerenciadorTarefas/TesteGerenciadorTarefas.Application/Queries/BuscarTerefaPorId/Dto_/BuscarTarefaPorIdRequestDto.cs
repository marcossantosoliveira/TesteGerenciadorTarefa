using MediatR;

namespace TesteGerenciadorTarefas.Application.Queries.BuscarTerefaPorId.Dto_
{
    public class BuscarTarefaPorIdRequestDto : IRequest<BuscarTarefaPorIdResponseDto>
    {
        public int Id { get; set; }
        
    }
}
