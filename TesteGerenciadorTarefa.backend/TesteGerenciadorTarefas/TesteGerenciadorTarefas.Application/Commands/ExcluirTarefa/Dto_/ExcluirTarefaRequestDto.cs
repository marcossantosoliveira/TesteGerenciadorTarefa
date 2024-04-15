﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciadorTarefas.Application.Commands.ExcluirTarefa.Dto_
{
    public class ExcluirTarefaRequestDto : IRequest<ExcluirTarefaResponseDto>
    {
        public int Id { get; set; }
    }
}