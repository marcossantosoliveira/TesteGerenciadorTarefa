using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TesteGerenciadorTarefas.Application.Commands.CriarTarefa.Dto_;
using TesteGerenciadorTarefas.Application.Commands.EditarTarefa.Dto_;
using TesteGerenciadorTarefas.Application.Commands.ExcluirTarefa.Dto_;
using TesteGerenciadorTarefas.Application.Queries.BuscarTarefas.Dto_;
using TesteGerenciadorTarefas.Application.Queries.BuscarTerefaPorId.Dto_;

namespace TesteGerenciadorTarefas.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {



        [HttpGet("buscartarefas")]
        public Task<List<BuscarTarefasResponseDto>> BuscarTodos([FromServices] IMediator mediator)
        {                      

            try
            {
                var tarefasRequest = new BuscarTarefasRequestDto();
                var tarefas = mediator.Send(tarefasRequest);

                Log.Information("Buscar tarefas  - {@tarefas} ", tarefas);

                return tarefas;

            }
            catch (Exception ex)
            {

                Log.Information($"Erro ao buscar tarefas - {ex} ");

                return null;
            }

        }

        [HttpGet("buscarporid/id")]
        public Task<BuscarTarefaPorIdResponseDto> BuscarPorId([FromServices] IMediator mediator, int id)
        {
           
            try
            {
                var tarefaRequest = new BuscarTarefaPorIdRequestDto()
                {
                    Id = id
                };

                var tarefa = mediator.Send(tarefaRequest);

                Log.Information("Buscar tarefas por Id - {@Tarefa} ", tarefa);

                return tarefa;
            }
            catch (Exception ex)
            {

                Log.Information($"Erro ao buscar tarefa por id - {ex} ");

                return null;
            }

        }

        [HttpPost("criar")]
        public Task<CriarTarefaResponseDto> Criar([FromServices] IMediator mediator,
                                                 CriarTarefaRequestDto tarefaRequest)
        {           

            try
            {
                var tarefa = mediator.Send(tarefaRequest);

                Log.Information("Tarefa criada com sucesso - {@Tarefa} ", tarefa);

                return tarefa;                
            }
            catch (Exception ex )
            {
                
                Log.Information($"Erro ao criar tarefa - {ex} ");

                return null;
            }            

        }

        [HttpPut("editar/id")]
        public Task<EditarTarefaResponseDto> Editar([FromServices] IMediator mediator,
                                                    EditarTarefaRequestDto tarefaRequest,
                                                    int id)
        {            

            try
            {
                tarefaRequest.Id = id;
                var tarefa = mediator.Send(tarefaRequest);

                Log.Information("Tarefa editada com sucesso - {@Tarefa} ", tarefa);

                return tarefa;

            }
            catch (Exception ex)
            {
               
                Log.Information($"Erro ao editar tarefa - {ex} ");
                return null;
            }                       

        }

        [HttpDelete("deletar/id")]
        public Task<ExcluirTarefaResponseDto> Excluir([FromServices] IMediator mediator, 
                                                       int id)
        {         

            try
            {
                var tarefaRequest = new ExcluirTarefaRequestDto
                {
                    Id = id
                };

                var tarefa = mediator.Send(tarefaRequest);

                Log.Information("Tarefa excluida com sucesso - {@Tarefa} ", tarefa);

                return tarefa;

            }
            catch (Exception ex)
            {

                Log.Information($"Erro ao excluir tarefa - {ex} ");
                return null;
            }

        }
    }
}
