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
        private readonly IModalidadeRepository _repositoryModalidade;
        private readonly IModuloRepository _repositoryModulo;

        public PlanoService(IPlanoRepository repository, NotificationContext notificationContext, IModalidadeRepository repositoryModalidade, IModuloRepository repositoryModulo)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryModalidade = repositoryModalidade;
            _repositoryModulo = repositoryModulo;
        }

        public List<Plano> Get()
        {
            try
            {
                List<Plano> planos = _repository.Get();
                return planos;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Plano Get(int codigo)
        {
            try
            {
                Plano plano = _repository.SelectById(codigo);
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
                if (CheckInsertUpdate(plano))
                {
                    int planoInserido = _repository.Insert(plano);
                    return planoInserido;
                }
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
                if (CheckInsertUpdate(plano))
                {
                    _repository.Update(plano);
                }
                
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
                Plano plano = _repository.SelectById(codigo);

                if (plano == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(plano);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(Plano plano)
        {
            Plano planoExiste = _repository.SearchByDescription(plano.descricao);

            if (planoExiste == null)
            {
                Modalidade modalidadeExiste = _repositoryModalidade.SelectById(plano.modalidade_codigo);
                Modulo moduloExiste = _repositoryModulo.SelectById(plano.modulo_codigo);

                if (modalidadeExiste != null && moduloExiste != null)
                {
                    return true;
                }
                else
                {
                    _notificationContext.AddNotification("É necessário o preenchimento dos campos modulo e modalidade.");
                    return false;
                }
            }
            else
            {
                _notificationContext.AddNotification("Já existe um cadastro para essa descrição de plano.");
                return false;
            }
        }
    }
}
