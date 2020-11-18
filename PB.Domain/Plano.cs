using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Plano : EntityBase
    {
        public String descricao { get; set; }
        public decimal valor { get; set; }
        public int modalidade_codigo { get; set; }
    }
}
