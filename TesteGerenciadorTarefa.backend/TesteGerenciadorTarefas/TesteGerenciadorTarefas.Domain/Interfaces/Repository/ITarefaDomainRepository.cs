
using TesteGerenciadorTarefas.Domain.Dto_;
using TesteGerenciadorTarefas.Domain.Entities;

namespace TesteGerenciadorTarefas.Domain.Interfaces.Repository
{
    public interface ITarefaDomainRepository
    {
        Task<List<TarefaEntities>> BuscarTarefasAsync();
        Task<TarefaEntities> BuscarTarefasPorIdAsync(int id);
        Task<TarefaEntities> CriarTarefaAsync(TarefaEntities tarefa);
        Task<bool> EditarTarefaAsync(int id, TarefaEntities tarefa);
        Task<bool> ExcluirTarefaAsync(int id);

    }
}
