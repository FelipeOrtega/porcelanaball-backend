using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IModalidadeRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ModalidadeService(IModalidadeRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Modalidade> Get()
        {
            try
            {
                List<Modalidade> modalidades = _repository.Consultar();
                return modalidades;
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Modalidade Get(int codigo)
        {
            try
            {
                Modalidade modalidade = _repository.SelecionarPorId(codigo);
                return modalidade;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Modalidade modalidade)
        {
            try
            {
                int codigoModalidadeInserido = _repository.Inserir(modalidade);
                return codigoModalidadeInserido;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Modalidade modalidade)
        {
            try
            {
                _repository.Alterar(modalidade);
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
                Modalidade modalidade = _repository.SelecionarPorId(codigo);
                if (modalidade == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Excluir(modalidade);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
