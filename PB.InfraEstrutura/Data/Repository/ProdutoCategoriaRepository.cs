﻿using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ProdutoCategoriaRepository : RepositoryBase<ProdutoCategoria>, IProdutoCategoriaRepository
    {
        public ProdutoCategoriaRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
