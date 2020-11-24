using PB.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PB.Domain
{
    [Table("produto_lote")]
    public class ProdutoLote : EntityBase
    {
        public string descricao { get; set; }
        public DateTime validade { get; set; }

    }
}
