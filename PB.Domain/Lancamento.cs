using PB.Domain.Core;
using System;
using System.Collections.Generic;

namespace PB.Domain
{
    public class Lancamento : EntityBase
    {
        public Decimal valor { get; set; }
        public DateTime data { get; set; }
        public String tipo { get; set; }
        public int cancelado { get; set; }
        public int? funcionario_codigo { get; set; }
        public int? plano_codigo { get; set; }
        public int? lancamento_tipo_codigo { get; set; }
        public String observacao { get; set; }

        public int? aluno_codigo { get; set; }
        public int? forma_pagamento_codigo { get; set; }

        public List<LancamentoProduto> lancamentoProduto { get; set; }
    }
}
