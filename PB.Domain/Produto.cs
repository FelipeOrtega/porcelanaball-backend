using PB.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB.Domain
{
    public class Produto : EntityBase
    {
        public String descricao { get; set; }
        public decimal preco_venda { get; set; }
        public decimal preco_compra { get; set; }
        public DateTime validade { get; set; }
        public DateTime data_cadastro { get; set; } 
        public int produto_categoria_codigo { get; set; }

        public bool ativo;

        [Column("lote_codigo")]
        public int produtoLoteCodigo { get; set; }
        public ProdutoLote produtoLote { get; set; }

    }
}
