using Microsoft.EntityFrameworkCore;
using PB.Domain.Core;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDBContext context;

        public RepositoryBase(ApplicationDBContext context) : base()
        {
            this.context = context;
        }

        public void Update(TEntity entity)
        {
            context.InitTransaction();
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SendChanges();
        }

        public void Delete(TEntity entity)
        {
            var i = SelectById(entity.codigo);
            if (i == null)
                throw new Exception("Este cadastro não foi encontrado no banco de dados.");

            context.InitTransaction();
            context.Set<TEntity>().Remove(entity);
            context.SendChanges();
        }

        public int Insert(TEntity entity)
        {

            context.InitTransaction();
            context.Set<TEntity>().Add(entity);
            context.SendChanges();
            var id = entity.codigo;
            return id;
        }

        public List<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity SelectById(int codigo)
        {
            return context.Set<TEntity>().Find(codigo);
        }
    }
}
