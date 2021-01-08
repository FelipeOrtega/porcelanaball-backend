using System.Text.Json.Serialization;
using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class PlanoAluno : EntityBase
    {
        public int aluno_codigo { get; set; }
        public int plano_codigo { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_validade { get; set; }

        [JsonIgnore]
        public Aluno aluno { get; set; }
    }
}
