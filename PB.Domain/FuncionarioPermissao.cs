using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class FuncionarioPermissao : EntityBase
    {
        public int funcionario_codigo { get; set; }
        public String permissao { get; set; }
    }
}
