using PB.Domain;
using System;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IProdutoLoteService
    {
        List<ProdutoLote> Get();
        ProdutoLote Get(int codigo);
        int Insert(ProdutoLote ProdutoLote);
        int Update(ProdutoLote ProdutoLote);
        int Delete(ProdutoLote ProdutoLote);
    }
}
