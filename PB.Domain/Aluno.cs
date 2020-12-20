using System;
using System.Collections.Generic;

namespace PB.Domain
{
    public class Aluno : Pessoa
    {
        public String apelido { get; set; }
        public Decimal peso { get; set; }
        public Decimal altura { get; set; }
        public List<AlunoTreino> alunoTreinos { get; set; }
        public List<AlunoPossuiPlano> alunoPossuiPlano { get; set; }
    }
}
