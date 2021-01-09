using PB.Domain.Core;
using System.Text.Json.Serialization;

namespace PB.Domain
{
    public class LancamentoAluno : EntityBase
    {
        public int aluno_codigo { get; set; }
        public int lancamento_codigo { get; set; }

        [JsonIgnore]
        public Lancamento lancamento { get; set; }
    }
}
