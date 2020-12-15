using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IProdutoCategoriaService
    {
        List<ProdutoCategoria> Get();
        ProdutoCategoria Get(int codigo);
        int Insert(ProdutoCategoria produtoCategoria);
        int Update(ProdutoCategoria produtoCategoria);
        int Delete(int codigo);
    }
}
