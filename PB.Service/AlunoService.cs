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
                List<Aluno> alunos = _repository.Consultar();
                return alunos;
            }
            catch (Exception ex) {
             
            }

            return null;
        }

        public Aluno Get(int codigo)
        { 
            try
            {
                Aluno aluno = _repository.SelecionarPorId(codigo);
                return aluno;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public int Insert(Aluno aluno)
        {
            try
            {
                int codigoAlunoInserido = _repository.Inserir(aluno);
                return codigoAlunoInserido;
            }
            catch (Exception) { 
            
            }
            return 0;
        }

        public int Update(Aluno aluno)
        {
            try
            {
                _repository.Alterar(aluno);
            }
            catch (Exception) { 
            
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
            
            }

            return 0;
        }
    }
}
