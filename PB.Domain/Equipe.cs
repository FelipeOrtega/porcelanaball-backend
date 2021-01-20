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
        public DateTime data_inicio_contrato { get; set; }
        public DateTime data_fim_contrato { get; set; }
        public Decimal valor { get; set; }
        public DateTime pagamento_frequencia_codigo { get; set; }
    }
}
