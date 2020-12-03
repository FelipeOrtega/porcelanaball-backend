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
                List<AlunoTreino> alunoTreinos = _repository.Consultar();
                return alunoTreinos;
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoTreino Get(int codigo)
        {
            try
            {
                AlunoTreino alunoTreino = _repository.SelecionarPorId(codigo);
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
                Aluno alunoExiste = _repositoryAluno.SelecionarPorId(alunoTreino.aluno_codigo);
                if (alunoExiste != null && alunoExiste.ativo)
                {
                    int codigoAlunoTreinoInserido = _repository.Inserir(alunoTreino);
                    return codigoAlunoTreinoInserido;
                }
                else
                {
                    _notificationContext.AddNotification("Aluno inexistente ou inativo.");
                    return 0;
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
                _repository.Alterar(alunoTreino);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(AlunoTreino alunoTreino)
        {
            try
            {
                _repository.Excluir(alunoTreino);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
