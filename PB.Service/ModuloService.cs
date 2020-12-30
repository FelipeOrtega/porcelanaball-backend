using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ModuloService(IModuloRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Modulo> Get()
        {
            try
            {
                List<Modulo> modulos = _repository.Get();
                return modulos;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Modulo Get(int codigo)
        {
            try
            {
                Modulo modulo = _repository.SelectById(codigo);
                return modulo;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Modulo modulo)
        {
            try
            {
                int codigoModuloInserido = _repository.Insert(modulo);
                return codigoModuloInserido;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Modulo modulo)
        {
            try
            {
                _repository.Update(modulo);
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
                Modulo modulo = _repository.SelectById(codigo);

                if (modulo == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(modulo);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
