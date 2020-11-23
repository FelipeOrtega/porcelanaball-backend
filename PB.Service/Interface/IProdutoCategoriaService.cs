using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IProdutoCategoriaService
    {
        List<ProdutoCategoria> Get();
        ProdutoCategoria Get(int codigo);
        int Insert(ProdutoCategoria modalidade);
        int Update(ProdutoCategoria modalidade);
        int Delete(ProdutoCategoria modalidade);
    }
}
