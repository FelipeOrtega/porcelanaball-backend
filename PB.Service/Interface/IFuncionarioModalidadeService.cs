using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IFuncionarioModalidadeService
    {
        List<FuncionarioModalidade> Get();
        FuncionarioModalidade Get(int codigo);
        int Insert(FuncionarioModalidade modalidadeFuncionario);
        int Update(FuncionarioModalidade modalidadeFuncionario);
        int Delete(int codigo);
    }
}
