using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Equipe : EntityBase
    {
        public string descricao { get; set; }
        public int modalidade_codigo { get; set; }
        public bool ativo { get; set; }
        public int modulo_codigo { get; set; }
        public Decimal valor { get; set; }
        public DateTime data_primeiro_jogo { get; set; }
        public int quantidade_meses_a_pagar { get; set; }   

    }
}
