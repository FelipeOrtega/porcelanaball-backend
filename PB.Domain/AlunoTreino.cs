using PB.Domain.Core;
using System;
using System.Text.Json.Serialization;

namespace PB.Domain
{
    public class AlunoTreino : EntityBase
    {
        public String treino { get; set; }
        public int aluno_codigo { get; set; }
        [JsonIgnore]
        public Aluno aluno { get; set; }
    }
}
