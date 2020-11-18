using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PB.Service
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository _repository;
        private readonly NotificationContext _notificationContext;

        public PlanoService(IPlanoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }
        public List<Plano> Get()
        {
            try
            {
                List<Plano> planos = _repository.Consultar();
                return planos;
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Plano Get(int codigo)
        {
            try
            {
                Plano plano = _repository.SelecionarPorId(codigo);
                return plano;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Plano plano)
        {
            try
            {
                int codigoPlanoInserido = _repository.Inserir(plano);
                return codigoPlanoInserido;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Plano plano)
        {
            try
            {
                _repository.Alterar(plano);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Plano plano = _repository.SelecionarPorId(codigo);
                _repository.Excluir(plano);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
