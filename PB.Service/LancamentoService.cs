using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _repository;
        private readonly NotificationContext _notificationContext;

        public LancamentoService(ILancamentoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Lancamento> Get()
        {
            try
            {
                List<Lancamento> lancamentos = _repository.Consultar();
                return lancamentos;
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Lancamento Get(int codigo)
        {
            try
            {
                Lancamento lancamento = _repository.SelecionarPorId(codigo);
                return lancamento;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Lancamento lancamento)
        {
            try
            {
                int codigoLancamentoInserido = _repository.Inserir(lancamento);
                return codigoLancamentoInserido;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Lancamento lancamento)
        {
            try
            {
                _repository.Alterar(lancamento);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(Lancamento lancamento)
        {
            try
            {
                _repository.Excluir(lancamento);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
