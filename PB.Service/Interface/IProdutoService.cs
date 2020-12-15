using System;
using System.Collections.Generic;
using System.Text;
using PB.Domain;
namespace PB.Service.Interface
{
    public interface IProdutoService
    {
        List<Produto> Get();
        Produto Get(int codigo);
        int Insert(Produto aluno);
        int Update(Produto aluno);
        int Delete(int codigo);
    }
}
