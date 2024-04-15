using Microsoft.EntityFrameworkCore;
using TesteGerenciadorTarefas.Domain.Entities;
using TesteGerenciadorTarefas.Domain.Interfaces.Repository;
using TesteGerenciadorTarefas.Infra.Context;

namespace TesteGerenciadorTarefas.Infra.Repository
{
    public class TarefaRepository : ITarefaDomainRepository
    {

        private readonly BdContexto _tarefaContext;

        public TarefaRepository(BdContexto tarefaContext)
        {
            _tarefaContext = tarefaContext;
        }

        public async Task<List<TarefaEntities>> BuscarTarefasAsync()
        {
            var tarefas = await _tarefaContext.Tarefas.ToListAsync();

            return tarefas;
        }

        public async Task<TarefaEntities> BuscarTarefasPorIdAsync(int id)
        {
            var tarefa = await _tarefaContext.Tarefas.SingleOrDefaultAsync(t => t.Id == id);

            return tarefa;
        }

        public async Task<TarefaEntities> CriarTarefaAsync(TarefaEntities tarefa)
        {
            await _tarefaContext.Tarefas.AddAsync(tarefa);
            await _tarefaContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<bool> EditarTarefaAsync(int id, TarefaEntities tarefa)
        {
            var editarTarefa = await BuscarTarefasPorIdAsync(id);

            if (!editarTarefa.Status)
            {

                _tarefaContext.Tarefas.Update(tarefa);
                _tarefaContext.SaveChanges();

                return true;

            }

            return false;

        }

        public async Task<bool> ExcluirTarefaAsync(int id)
        {
            var excluirTarefa = await BuscarTarefasPorIdAsync(id);

            if (excluirTarefa.Status)
            {
                _tarefaContext.Tarefas.Remove(excluirTarefa);
                _tarefaContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
