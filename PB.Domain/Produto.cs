using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Produto : EntityBase
    {
        public String descricao { get; set; }
        public decimal precoVenda { get; set; }
        public decimal precoCompra { get; set; }
        public DateTime validade { get; set; }
        public DateTime dataCadastro { get; set; } 
        public int LoteCodio { get; set; }
        public int CodigoProdutoCategoria { get; set; }
        public bool ativo;
    }
}
