using PB.Domain.Core;
using System;
using System.Text.Json.Serialization;

namespace PB.Domain
{
    public class FuncionarioPermissao : EntityBase
    {
        public int funcionario_codigo { get; set; }
        public String permissao { get; set; }

        [JsonIgnore]
        public Funcionario funcionario { get; set; }
    }
}
