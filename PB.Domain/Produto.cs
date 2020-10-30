using System;
using System.Collections.Generic;
using System.Text;

namespace PB.Domain
{
    public class Produto
    {
        public int codigo { get; set; }
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
