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

        public PlanoService(IPlanoRepository repository, NotificationContext notificationContext, IModalidadeRepository repositoryModalidade,
            IModuloRepository repositoryModulo)
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
                Plano planoExiste = _repository.ConsultaPorDescricao(plano.descricao);

                if (planoExiste == null)
                {
                    Modalidade modalidadeExiste = _repositoryModalidade.SelecionarPorId(plano.modalidade_codigo);
                    Modulo moduloExiste = _repositoryModulo.SelecionarPorId(plano.modulo_codigo);

                    if (modalidadeExiste != null && moduloExiste != null)
                    {
                        int planoInserido = _repository.Inserir(plano);
                        return planoInserido;
                    }
                    else
                    {
                        _notificationContext.AddNotification("É necessário o preenchimento dos campos modulo e modalidade.");
                        return 0;
                    }
                }
                else
                {
                    _notificationContext.AddNotification("Já existe um cadastro para essa descrição de plano.");
                    return 0;
                }
            }
            catch (Exception e)
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
