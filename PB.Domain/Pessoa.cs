using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public abstract class Pessoa : EntityBase
    {
        public String nome { get; set; }
        public String endereco { get; set; }
        public String numero { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String cep { get; set; }
        public String uf { get; set; }
        public String complemento { get; set; }
        public DateTime data_nascimento { get; set; }
        public String telefone_residencial { get; set; }
        public String telefone_celular { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public bool ativo { get; set; }
        public String biometria { get; set; }
    }
}
