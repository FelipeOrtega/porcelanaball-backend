using PB.Domain.Core;
using System;
using System.Text.Json.Serialization;

namespace PB.Domain
{
    public class FuncionarioPossuiPlano : EntityBase
    {
        public int funcionario_codigo { get; set; }
        public int plano_codigo { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_validade { get; set; }
        [JsonIgnore]
        public Funcionario funcionario { get; set; }
    }
}
