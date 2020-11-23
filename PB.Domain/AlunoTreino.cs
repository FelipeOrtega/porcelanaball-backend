using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class AlunoTreino : EntityBase
    {
        public String descricao { get; set; }
        public int aluno_codigo { get; set; }
    }
}
