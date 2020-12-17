using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class AlunoTreinoService : IAlunoTreinoService
    {
        private readonly IAlunoTreinoRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IAlunoRepository _repositoryAluno;

        public AlunoTreinoService(IAlunoTreinoRepository repository, NotificationContext notificationContext, IAlunoRepository repositoryAluno)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryAluno = repositoryAluno;
        }

        public List<AlunoTreino> Get()
        {
            try
            {
                List<AlunoTreino> alunoTreinos = _repository.Get();
                return alunoTreinos;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoTreino Get(int codigo)
        {
            try
            {
                AlunoTreino alunoTreino = _repository.SelectById(codigo);
                return alunoTreino;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(AlunoTreino alunoTreino)
        {
            try
            {
                if (CheckInsertUpdate(alunoTreino))
                {
                    int codigoAlunoTreinoInserido = _repository.Insert(alunoTreino);
                    return codigoAlunoTreinoInserido;
                }
                else
                {
                    _notificationContext.AddNotification("Aluno inexistente ou inativo.");
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(AlunoTreino alunoTreino)
        {
            try
            {
                if (CheckInsertUpdate(alunoTreino))
                {
                    _repository.Update(alunoTreino);
                }
                else
                {
                    _notificationContext.AddNotification("Aluno inexistente ou inativo.");
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
                AlunoTreino alunoTreino = _repository.SelectById(codigo);
                if (alunoTreino == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(alunoTreino);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(AlunoTreino alunoTreino)
        {
            try
            {
                Aluno alunoExiste = _repositoryAluno.SelectById(alunoTreino.aluno_codigo);

                if (alunoExiste != null && alunoExiste.ativo)
                {
                    return true;
                }
                else
                {
                    _notificationContext.AddNotification("Aluno inexistente ou inativo.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
