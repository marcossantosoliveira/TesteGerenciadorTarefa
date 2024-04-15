using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciadorTarefas.Domain.Interfaces.Mensageria
{
    public interface IMensageriaService
    {
        void Publicar(object objeto, string routinKey);
    }
}
