using System;
using System.Collections.Generic;

namespace PB.Domain
{
    public class Funcionario : Pessoa
    {
        public String senha { get; set; }
        public List<FuncionarioPermissao> funcionarioPermissao { get; set; }
        public List<FuncionarioModalidade> modalidadeFuncionario { get; set; }
        public List<PlanoFuncionario> funcionarioPossuiPlano { get; set; }
    }
}
