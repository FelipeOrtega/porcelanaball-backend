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
        private readonly IAlunoTreinoRepository _repositoryAlunoTreino;

        public AlunoService(IAlunoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Aluno> Get()
        {
            try
            {
                List<Aluno> alunos = _repository.ListagemCompleta();
                return alunos;
            }
            catch (Exception ex) 
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Aluno Get(int codigo)
        { 
            try
            {
                Aluno aluno = _repository.SelecionarPorId(codigo);
                aluno = _repository.ConsultaCompleta(aluno);
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
                Aluno alunoExiste = _repository.ConsultaCpf(aluno.cpf);

                if (alunoExiste == null)
                {
                    int codigoAlunoInserido = _repository.Inserir(aluno);
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
                Aluno alunoExistente = _repository.SelecionarPorId(aluno.codigo);

                if (alunoExistente != null)
                {
                    if (alunoExistente.ativo)
                    {
                        alunoExistente.alunoTreinos.ForEach(delegate (AlunoTreino ae)
                        {
                            aluno.alunoTreinos.ForEach(delegate (AlunoTreino a)
                            {
                                if(ae.codigo == a.codigo)
                                {
                                    _repositoryAlunoTreino.Alterar(a);
                                }
                                else
                                {
                                    _repositoryAlunoTreino.Excluir(a);//ontem tava dando o erro de tracking pq o codigo do treino novo era igual a um que ja tinha
                                }
                            });
                        });

                        _repository.Alterar(aluno);
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
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(Aluno aluno)
        {
            try
            {
                _repository.Excluir(aluno);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
