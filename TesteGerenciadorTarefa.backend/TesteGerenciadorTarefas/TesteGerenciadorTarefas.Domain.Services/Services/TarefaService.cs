
using TesteGerenciadorTarefas.Domain.Dto_;
using TesteGerenciadorTarefas.Domain.Entities;
using TesteGerenciadorTarefas.Domain.Interfaces.Mensageria;
using TesteGerenciadorTarefas.Domain.Interfaces.Repository;
using TesteGerenciadorTarefas.Domain.Interfaces.Services;

namespace TesteGerenciadorTarefas.Domain.Services.Services
{
    public class TarefaService : ITarefaDomainService
    {

        private readonly ITarefaDomainRepository _tarefaRepository;
        private readonly IMensageriaService _mensageriaService;

        public TarefaService(ITarefaDomainRepository tarefaRepository,
                              IMensageriaService mensageriaService)
        {
            _tarefaRepository = tarefaRepository;
            _mensageriaService = mensageriaService;
        }

        public async Task<List<TarefaResponseDto>> BuscarTarefasAsync()
        {
            var tarefasRepo = _tarefaRepository.BuscarTarefasAsync().Result;
            var tarefas = new List<TarefaResponseDto>();

            foreach (var item in tarefasRepo)
            {
                var tarefaItem = new TarefaResponseDto
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Data = item.Data,
                    Status = item.Status
                };

                tarefas.Add(tarefaItem);
            }

            return tarefas;
        }

        public async Task<TarefaResponseDto> BuscarTarefasPorIdAsync(int id)
        {
            var tarefaRepo = await _tarefaRepository.BuscarTarefasPorIdAsync(id);
            var tarefa = new TarefaResponseDto();

            tarefa.Id = tarefaRepo.Id;
            tarefa.Descricao = tarefaRepo.Descricao;
            tarefa.Data = tarefaRepo.Data;
            tarefa.Status = tarefaRepo.Status;

            return tarefa;
        }

        public async Task<int> CriarTarefaAsync(TarefaDto tarefa)
        {

            var tarefaEnti = new TarefaEntities();
           
            tarefaEnti.Descricao = tarefa.Descricao;
            tarefaEnti.Data = tarefa.Data;
            tarefaEnti.Status = tarefa.Status;

            var tarefaResponse = await _tarefaRepository.CriarTarefaAsync(tarefaEnti);

            _mensageriaService.Publicar(tarefaResponse, "gerenciador-tarefa-routingKey");

            return tarefaResponse.Id;
        }

        public async Task<bool> EditarTarefaAsync(int id, TarefaDto tarefa)
        {
            var tarefaEnti = new TarefaEntities();          

            tarefaEnti.Id = tarefa.Id;
            tarefaEnti.Descricao = tarefa.Descricao;            
            tarefaEnti.Status = tarefa.Status;

            var tarefaRepo = await _tarefaRepository.EditarTarefaAsync(id, tarefaEnti);            

            return tarefaRepo;
        }

        public async Task<bool> ExcluirTarefaAsync(int id)
        {
            var tarefaRepo = await _tarefaRepository.ExcluirTarefaAsync(id);

            return tarefaRepo;
        }
    }
}
