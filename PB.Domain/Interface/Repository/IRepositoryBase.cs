using PB.Domain.Core;
using System;
using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> Get();
        TEntity SelectById(int codigo);
    }
}
