using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly NotificationContext _notificationContext;

        public AlunoService(IAlunoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Aluno> Get()
        {
            try
            {
                List<Aluno> alunos = _repository.Consultar();

                return alunos;
            }
            catch (Exception ex) {
                _notificationContext.AddNotification("Nao foi possivel obter os alunos");
            }
            return null;
        }
    }
}
