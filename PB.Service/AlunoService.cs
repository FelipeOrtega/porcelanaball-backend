using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly NotificationContext _notificationContext;

        public AlunoService(IAlunoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Aluno> Get()
        {
            try
            {
                List<Aluno> alunos = _repository.FullList();
                return alunos;
            }
            catch (Exception) 
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Aluno Get(int codigo)
        { 
            try
            {
                Aluno aluno = _repository.SelectById(codigo);
                aluno = _repository.FullSearch(aluno);
                return aluno;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Aluno aluno)
        {
            try
            {
                Aluno alunoExiste = _repository.SearchCpf(aluno.cpf);

                if (alunoExiste == null)
                {
                    int codigoAlunoInserido = _repository.Insert(aluno);
                    return codigoAlunoInserido;
                }
                else
                {
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
                    return 0;
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Aluno aluno)
        {
            try
            {
                Aluno alunoExistente =  _repository.SearchCpf(aluno.cpf);

                if (alunoExistente != null)
                {
                    if (alunoExistente.ativo)
                    {
                        _repository.Update(aluno);
                    }
                    else
                    {
                        _notificationContext.AddNotification("Aluno inativo.");
                        return 0;
                    }
                }
                else
                {
                    _notificationContext.AddNotification("Aluno não encontrado.");
                    return 0;
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
                Aluno aluno = _repository.SelectById(codigo);
                if (aluno == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(aluno);
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
                _notificationContext.AddNotification(e.Message);
            }

            return 0;
        }
    }
}
