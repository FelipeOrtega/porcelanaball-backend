using System;
using System.Collections.Generic;
using System.Text;

namespace PB.Domain.Interface.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        public Produto SearchByDescription(string descricao);
    }
}
