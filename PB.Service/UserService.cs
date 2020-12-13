using System;
using System.Collections.Generic;
using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;

namespace PB.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly NotificationContext _notificationContext;

        public UserService(IUserRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<User> Get()
        {
            try
            {
                List<User> Users = _repository.Consultar();
                return Users;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public User Get(User user)
        {
            try
            {
                User User = _repository.Get(user.username, user.password);
                return User;
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(User User)
        {
            try
            {
                 int codigoUserInserido = _repository.Inserir(User);
                 return codigoUserInserido;
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(User User)
        {
            try
            {
                 _repository.Alterar(User);   
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(User User)
        {
            try
            {
                _repository.Excluir(User);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

    }
}
