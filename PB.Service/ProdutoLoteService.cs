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
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
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
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
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
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(ProdutoLote ProdutoLote)
        {
            try
            {
                _repository.Alterar(ProdutoLote);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
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
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
