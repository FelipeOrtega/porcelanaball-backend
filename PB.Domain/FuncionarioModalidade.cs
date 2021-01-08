using PB.Domain.Core;
using System.Text.Json.Serialization;

namespace PB.Domain
{
    public class FuncionarioModalidade : EntityBase
    {
        public int modalidade_codigo { get; set; }
        public int funcionario_codigo { get; set; }

        [JsonIgnore]
        public Funcionario funcionario { get; set; }
    }
}