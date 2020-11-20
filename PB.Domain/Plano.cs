using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Plano : EntityBase
    {
        public String descricao { get; set; }
        public decimal valor { get; set; }
        public int modalidade_codigo { get; set; }
        public bool ativo { get; set; }
        public int modulo_codigo { get; set; }
    }
}
