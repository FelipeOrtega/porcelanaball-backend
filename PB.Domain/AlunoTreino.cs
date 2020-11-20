using PB.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB.Domain
{
    public class AlunoTreino : EntityBase
    {
        private String treino { get; set; }
        private int aluno_codigo { get; set; }
    }
}
