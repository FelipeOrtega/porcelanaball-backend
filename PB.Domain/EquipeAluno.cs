using System.Text.Json.Serialization;
using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class EquipeAluno : EntityBase
    {
        public int aluno_codigo { get; set; }
        public Aluno aluno { get; set; }
        public int equipe_codigo { get; set; }
        public Equipe equipe { get; set; }
        public bool responsavel { get; set; }

    }
}
