using PB.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB.Domain
{
    [Table("USER")]
    public class User : EntityBase
    {
        [Column("USERNAME")]
        public string username { get; set; }
        [Column("PASSWORD")]
        public string password { get; set; }
        [Column("ROLE")]
        public string role { get; set; }
    }
}
