using PB.Domain.Core;

namespace PB.Domain
{
    public class LancamentoProduto : EntityBase
    {
        public int lancamento_codigo { get; set; }
        public int produto_codigo { get; set; }
        public int quantidade { get; set; }
    }
}
