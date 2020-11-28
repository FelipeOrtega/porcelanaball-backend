using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IModalidadeFuncionarioService
    {
        List<ModalidadeFuncionario> Get();
        ModalidadeFuncionario Get(int codigo);
        int Insert(ModalidadeFuncionario modalidadeFuncionario);
        int Update(ModalidadeFuncionario modalidadeFuncionario);
        int Delete(int codigo);
    }
}
