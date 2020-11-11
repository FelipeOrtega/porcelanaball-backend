using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB.Domain
{
    public class Aluno : Pessoa
    {
        public Decimal peso { get; set; }
        public Decimal altura { get; set; }
    }
}
