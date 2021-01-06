using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<AlunoTreino> alunoTreinos = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return alunoTreinos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoTreino Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                AlunoTreino alunoTreino = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return alunoTreino;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(AlunoTreino alunoTreino)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                if (CheckInsertUpdate(alunoTreino))
                {
                    int codigoAlunoTreinoInserido = _repository.Insert(alunoTreino);

                    Log.write(Log.Nivel.INFO, "OUT");
                    return codigoAlunoTreinoInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Aluno inexistente ou inativo OUT");
                    _notificationContext.AddNotification("Aluno inexistente ou inativo.");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(AlunoTreino alunoTreino)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                if (CheckInsertUpdate(alunoTreino))
                {
                    _repository.Update(alunoTreino);
                    Log.write(Log.Nivel.INFO, "OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Aluno inexistente ou inativo OUT");
                    _notificationContext.AddNotification("Aluno inexistente ou inativo.");
                }
                
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                AlunoTreino alunoTreino = _repository.SelectById(codigo);

                if (alunoTreino == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " nao encontrado OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(alunoTreino);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
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
