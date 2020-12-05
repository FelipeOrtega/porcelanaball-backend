using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB.Domain.Core
{
    public abstract class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo { get; set; }
    }
}
