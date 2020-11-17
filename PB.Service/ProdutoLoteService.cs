using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class ProdutoLoteService : IProdutoLoteService
    {
        private readonly IProdutoLoteRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ProdutoLoteService(IProdutoLoteRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<ProdutoLote> Get()
        {
            try
            {
                List<ProdutoLote> ProdutoLotes = _repository.Consultar();
                return ProdutoLotes;
            }
            catch (Exception ex) {
             
            }

            return null;
        }

        public ProdutoLote Get(int codigo)
        { 
            try
            {
                ProdutoLote ProdutoLote = _repository.SelecionarPorId(codigo);
                return ProdutoLote;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public int Insert(ProdutoLote ProdutoLote)
        {
            try
            {
                int codigoProdutoLoteInserido = _repository.Inserir(ProdutoLote);
                return codigoProdutoLoteInserido;
            }
            catch (Exception) { 
            
            }
            return 0;
        }

        public int Update(ProdutoLote ProdutoLote)
        {
            try
            {
                _repository.Alterar(ProdutoLote);
            }
            catch (Exception) { 
            
            }

            return 0;
        }

        public int Delete(ProdutoLote ProdutoLote)
        {
            try
            {
                _repository.Excluir(ProdutoLote);
            }
            catch (Exception)
            { 
            
            }

            return 0;
        }
    }
}
