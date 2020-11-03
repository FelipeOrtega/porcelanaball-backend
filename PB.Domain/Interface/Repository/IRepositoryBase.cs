using PB.Domain.Core;
using System;

namespace PB.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Inserir(TEntity entity);
        void Excluir(TEntity entity);
        void Alterar(TEntity entity);
        TEntity SelecionarPorId(String codigo);
    }
}
