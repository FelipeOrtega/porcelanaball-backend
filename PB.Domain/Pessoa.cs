using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public abstract class Pessoa : EntityBase
    {
        public String nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public String telefone_residencial { get; set; }
        public String telefone_celular { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public bool ativo { get; set; }
        public String biometria { get; set; }
    }
}
