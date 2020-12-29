using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class AlunoPossuiEquipeService : IAlunoPossuiEquipeService
    {
        private readonly IAlunoPossuiEquipeRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IAlunoRepository _repositoryAluno;
        private readonly IEquipeRepository _repositoryEquipe;

        public AlunoPossuiEquipeService(
            IAlunoPossuiEquipeRepository repository, 
            NotificationContext notificationContext,
            IAlunoRepository repositoryAluno,
            IEquipeRepository repositoryEquipe)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryAluno = repositoryAluno;
            _repositoryEquipe = repositoryEquipe;
        }

        public List<AlunoPossuiEquipe> Get()
        {
            try
            {
                List<AlunoPossuiEquipe> alunoPossuiEquipes = _repository.Get();
                return alunoPossuiEquipes;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoPossuiEquipe Get(int codigo)
        {
            try
            {
                AlunoPossuiEquipe alunoPossuiEquipe = _repository.SelectById(codigo);
                return alunoPossuiEquipe;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(AlunoPossuiEquipe alunoPossuiEquipe)
        {
            try
            {
                if (CheckInsertUpdate(alunoPossuiEquipe))
                {
                    int codigoAlunoPossuiEquipeInserido = _repository.Insert(alunoPossuiEquipe);
                    return codigoAlunoPossuiEquipeInserido;
                }
                else
                {
                    _notificationContext.AddNotification("Aluno ou Equipe inexistente(s) ou inativo(s).");
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(AlunoPossuiEquipe alunoPossuiEquipe)
        {
            try
            {
                if (CheckInsertUpdate(alunoPossuiEquipe))
                {
                    _repository.Update(alunoPossuiEquipe);
                }
                else
                {
                    _notificationContext.AddNotification("Aluno ou Equipe inexistente(s) ou inativo(s).");
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
                AlunoPossuiEquipe alunoPossuiEquipe = _repository.SelectById(codigo);
                if (alunoPossuiEquipe == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(alunoPossuiEquipe);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(AlunoPossuiEquipe alunoPossuiEquipe)
        {
            try
            {
                Aluno alunoExiste = _repositoryAluno.SelectById(alunoPossuiEquipe.aluno_codigo);
                Equipe equipeExiste = _repositoryEquipe.SelectById(alunoPossuiEquipe.equipe_codigo);

                return ((alunoExiste != null && alunoExiste.ativo) && (equipeExiste != null && equipeExiste.ativo));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
