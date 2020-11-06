using PB.Domain.Core;
using System;
using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Inserir(TEntity entity);
        void Excluir(TEntity entity);
        void Alterar(TEntity entity);
        List<TEntity> Consultar();
        TEntity SelecionarPorId(int codigo);
    }
}
