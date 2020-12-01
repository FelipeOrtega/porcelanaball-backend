﻿using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        public Aluno ConsultaCpf(string cpf);
        public Aluno ConsultaCompleta(Aluno aluno);
        public List<Aluno> ListagemCompleta();

    }
}
