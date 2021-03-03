using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _repository;
        private readonly NotificationContext _notificationContext;

        public PagamentoService(IPagamentoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Pagamento> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Pagamento> pagamentos = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return pagamentos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }
            return null;
        }

        public Pagamento Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Pagamento pagamento = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return pagamento;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Pagamento pagamento)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                int codigoInserido = _repository.Insert(pagamento);
                Log.write(Log.Nivel.INFO, "OUT");
                return codigoInserido;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
           
            return 0;
        }

        public int Update(Pagamento pagamento)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + pagamento.codigo + " IN");
                _repository.Update(pagamento);
                Log.write(Log.Nivel.INFO, "Codigo = " + pagamento.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + pagamento.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Pagamento pagamento = _repository.SelectById(codigo);

                if (pagamento == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(pagamento);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
