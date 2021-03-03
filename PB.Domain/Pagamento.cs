using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Pagamento : EntityBase
    {
        public decimal valor { get; set; }
        public string observacao { get; set; }
        public DateTime data { get; set; }
        public int equipe_codigo { get; set; }
        public int modulo_codigo { get; set; }
        public int modalidade_codigo { get; set; }
    }
}
