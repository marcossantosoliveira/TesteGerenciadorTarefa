

namespace TesteGerenciadorTarefas.Application.Queries.BuscarTarefas.Dto_
{
    public class BuscarTarefasResponseDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; }
    }
}
