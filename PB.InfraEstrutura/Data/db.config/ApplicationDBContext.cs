using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PB.Domain;
using PB.InfraEstrutura.Data.Mapping;
using System;


namespace PB.InfraEstrutura.Data.db.config
{
    public class ApplicationDBContext : DbContext
    {
        public IDbContextTransaction Transaction { get; private set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {}

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlunoMap()).
                         ApplyConfiguration(new AlunoTreinoMap()).
                         ApplyConfiguration(new ProdutoMap()).
                         ApplyConfiguration(new FuncionarioMap()).
                         ApplyConfiguration(new ProdutoLoteMap()).
                         ApplyConfiguration(new PlanoMap()).
                         ApplyConfiguration(new ModalidadeMap()).
                         ApplyConfiguration(new ProdutoCategoriaMap()).
                         ApplyConfiguration(new LancamentoMap()).
                         ApplyConfiguration(new ModalidadeFuncionarioMap()).
                         ApplyConfiguration(new ProdutoCategoriaMap()).
                         ApplyConfiguration(new ModuloMap()).
                         ApplyConfiguration(new ModalidadeFuncionarioMap()).
                         ApplyConfiguration(new AlunoPossuiPlanoMap());
        }
    }
}
