using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class Produto : EntityBase
    {
        public String descricao { get; set; }
        public decimal preco_venda { get; set; }
        public decimal preco_compra { get; set; }
        public DateTime validade { get; set; }
        public DateTime data_cadastro { get; set; } 
        public int lote_codigo { get; set; }
        public int produto_categoria_codigo { get; set; }
        public bool ativo { get; set; }
        public decimal saldo { get; set; }
    }
}
