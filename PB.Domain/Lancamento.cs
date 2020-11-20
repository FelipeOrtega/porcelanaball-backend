using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Lancamento : EntityBase
    {
        public Decimal valor { get; set; }
        public DateTime data { get; set; }
        public String tipo { get; set; }
        public int cancelado { get; set; }
        public int aluno_codigo { get; set; }
        public int funcionario_codigo { get; set; }
        public int plano_codigo { get; set; }
        public int forma_pagamento_codigo { get; set; }
        public int lancamento_categoria_codigo { get; set; }
    }
}
