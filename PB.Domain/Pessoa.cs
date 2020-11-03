using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public abstract class Pessoa : EntityBase
    {
        public String nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public String telefoneResidencial { get; set; }
        public String telefoneCelular { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public String biometria { get; set; }
        public bool ativo { get; set; }
    }
}
