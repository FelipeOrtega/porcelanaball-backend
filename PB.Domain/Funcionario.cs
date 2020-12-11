using System;
using System.Collections.Generic;

namespace PB.Domain
{
    public class Funcionario : Pessoa
    {
        public String rua { get; set; }
        public String numero { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String uf { get; set; }
        public String cep { get; set; }
        public String senha { get; set; }

        public List<FuncionarioPermissao> funcionarioPermissao { get; set; }
        public List<ModalidadeFuncionario> modalidadeFuncionario { get; set; }
        public List<FuncionarioPossuiPlano> funcionarioPossuiPlano { get; set; }
    }
}
