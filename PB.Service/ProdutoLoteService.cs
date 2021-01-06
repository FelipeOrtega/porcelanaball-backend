using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<ProdutoLote> ProdutoLotes = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return ProdutoLotes;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public ProdutoLote Get(int codigo)
        { 
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                ProdutoLote ProdutoLote = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return ProdutoLote;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(ProdutoLote produtoLote)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                int codigoProdutoLoteInserido = _repository.Insert(produtoLote);
                Log.write(Log.Nivel.INFO, "OUT");
                return codigoProdutoLoteInserido;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(ProdutoLote produtoLote)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + produtoLote.codigo + " IN");
                _repository.Update(produtoLote);
                Log.write(Log.Nivel.INFO, "Codigo = " + produtoLote.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + produtoLote.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(ProdutoLote produtoLote)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + produtoLote.codigo + " IN");
                _repository.Delete(produtoLote);
                Log.write(Log.Nivel.INFO, "Codigo = " + produtoLote.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + produtoLote.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
