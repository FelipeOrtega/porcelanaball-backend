using System;
using System.Collections.Generic;
using System.Text;

namespace PB.Domain
{
    public abstract class Pessoa
    {
        public String codigo { get; set; }
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
