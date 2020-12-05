using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB.Domain.Core
{
    public abstract class EntityBase
    {
        public int codigo { get; set; }
    }
}
