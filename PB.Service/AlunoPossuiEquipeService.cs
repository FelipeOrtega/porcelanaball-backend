using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "Get<List> AlunoPossuiEquipe IN");
                List<AlunoPossuiEquipe> alunoPossuiEquipes = _repository.Get();
                Log.write(Log.Nivel.INFO, "Get<List> AlunoPossuiEquipe OUT");
                return alunoPossuiEquipes;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Get<List> AlunoPossuiEquipe OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoPossuiEquipe Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Get AlunoPossuiEquipe Codigo = " + codigo + " IN");
                AlunoPossuiEquipe alunoPossuiEquipe = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Get AlunoPossuiEquipe Codigo = " + codigo + " OUT");
                return alunoPossuiEquipe;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Get AlunoPossuiEquipe Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(AlunoPossuiEquipe alunoPossuiEquipe)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Insert AlunoPossuiEquipe IN");
                if (CheckInsertUpdate(alunoPossuiEquipe))
                {
                    int codigoAlunoPossuiEquipeInserido = _repository.Insert(alunoPossuiEquipe);

                    Log.write(Log.Nivel.INFO, "Insert AlunoPossuiEquipe OUT");
                    return codigoAlunoPossuiEquipeInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Insert AlunoPossuiEquipe Aluno nao Existe OUT");
                    _notificationContext.AddNotification("Aluno ou Equipe inexistente(s) ou inativo(s).");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Insert AlunoPossuiEquipe OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(AlunoPossuiEquipe alunoPossuiEquipe)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Update AlunoPossuiEquipe IN");
                if (CheckInsertUpdate(alunoPossuiEquipe))
                {
                    _repository.Update(alunoPossuiEquipe);
                    Log.write(Log.Nivel.INFO, "Update AlunoPossuiEquipe OK OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Update Aluno ou Equipe não existe OUT");
                    _notificationContext.AddNotification("Aluno ou Equipe inexistente(s) ou inativo(s).");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Update AlunoPossuiEquipe OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Delete AlunoPossuiEquipe Codigo  = " + codigo + " IN");
                AlunoPossuiEquipe alunoPossuiEquipe = _repository.SelectById(codigo);

                if (alunoPossuiEquipe == null)
                {
                    Log.write(Log.Nivel.INFO, "Delete AlunoPossuiEquipe Codigo  = " + codigo + " nao encontrado OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(alunoPossuiEquipe);
                Log.write(Log.Nivel.INFO, "Delete AlunoPossuiEquipe OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.INFO, ex, "Delete AlunoPossuiEquipe Codigo  = " + codigo + " OUT ERROR");
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
