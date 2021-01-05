using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IModalidadeRepository _repositoryModalidade;
        private readonly IModuloRepository _repositoryModulo;

        public EquipeService(IEquipeRepository repository, NotificationContext notificationContext, IModalidadeRepository repositoryModalidade, IModuloRepository repositoryModulo)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryModalidade = repositoryModalidade;
            _repositoryModulo = repositoryModulo;
        }

        public List<Equipe> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Get<List> Equipe IN");
                List<Equipe> equipes = _repository.Get();
                Log.write(Log.Nivel.INFO, "Get<List> Equipe OUT");
                return equipes;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Get<List> Alunos OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Equipe Get(int codigo)
        {
            try
            {
                Equipe equipe = _repository.SelectById(codigo);
                return equipe;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Equipe equipe)
        {
            try
            {
                if (CheckInsertUpdate(equipe))
                {
                    int equipeInserido = _repository.Insert(equipe);
                    return equipeInserido;
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Equipe equipe)
        {
            try
            {
                if (CheckInsertUpdate(equipe))
                {
                    _repository.Update(equipe);
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
                Equipe equipe = _repository.SelectById(codigo);

                if (equipe == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(equipe);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(Equipe equipe)
        {
            Equipe equipeExiste = _repository.SearchByDescription(equipe.descricao);

            if (equipeExiste == null)
            {
                Modalidade modalidadeExiste = _repositoryModalidade.SelectById(equipe.modalidade_codigo);
                Modulo moduloExiste = _repositoryModulo.SelectById(equipe.modulo_codigo);

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
                _notificationContext.AddNotification("Já existe um cadastro para essa descrição de equipe.");
                return false;
            }
        }
    }
}
