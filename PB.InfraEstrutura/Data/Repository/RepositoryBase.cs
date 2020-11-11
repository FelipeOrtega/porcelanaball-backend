﻿using Microsoft.EntityFrameworkCore;
using PB.Domain.Core;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.db.config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PB.InfraEstrutura.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDBContext context;
        public RepositoryBase(ApplicationDBContext context)
            : base()
        {
            this.context = context;
        }

        public void Alterar(TEntity entity)
        {
            context.InitTransacao();
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SendChanges();
        }

        public void Excluir(TEntity entity)
        {
            context.InitTransacao();
            context.Set<TEntity>().Remove(entity);
            context.SendChanges();
        }

        public int Inserir(TEntity entity)
        {
            context.InitTransacao();
            var id = context.Set<TEntity>().Add(entity).Entity.codigo;
            context.SendChanges();
            return id;
        }

        public List<TEntity> Consultar()
        {
            try
            {
                var teste = context.Set<TEntity>().ToList();
                return teste;
            }
            catch (Exception e) { 
            
            }
            return null;
        }

        public TEntity SelecionarPorId(int codigo)
        {
            return context.Set<TEntity>().Find(codigo);
        }
    }
}
