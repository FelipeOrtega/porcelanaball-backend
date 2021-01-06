using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Plano> planos = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return planos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Plano Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Plano plano = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return plano;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Plano plano)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                if (CheckInsertUpdate(plano))
                {
                    int planoInserido = _repository.Insert(plano);
                    Log.write(Log.Nivel.INFO, "OUT");
                    return planoInserido;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Plano plano)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + plano.codigo + " IN");
                if (CheckInsertUpdate(plano))
                {
                    _repository.Update(plano);
                    Log.write(Log.Nivel.INFO, "Codigo = " + plano.codigo + " OUT");
                }
                
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + plano.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Plano plano = _repository.SelectById(codigo);

                if (plano == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(plano);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
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
