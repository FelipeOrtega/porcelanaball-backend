using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;
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
            Log.write(Log.Nivel.INFO, "Get<List> Alunos IN");

            try
            {
                List<Aluno> alunos = _repository.FullList();
                Log.write(Log.Nivel.INFO, "Get<List> Alunos OUT");
                return alunos;
            }
            catch (Exception ex) 
            {
                Log.write(Log.Nivel.ERROR, ex, "Get<List> Alunos OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }
            return null;
        }

        public Aluno Get(int codigo)
        { 
            try
            {
                Log.write(Log.Nivel.INFO, "Get Aluno = " + codigo + " IN");
                Aluno aluno = _repository.SelectById(codigo);
                aluno = _repository.FullSearch(aluno);
                Log.write(Log.Nivel.INFO, "Get Aluno = " + codigo + " OUT");
                return aluno;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Get Aluno = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Aluno aluno)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Insert Aluno CPF = " + aluno.cpf + " IN");
                Aluno alunoExiste = _repository.SearchCpf(aluno.cpf);

                if (alunoExiste == null)
                {
                    Log.write(Log.Nivel.INFO, "Insert Aluno OK");
                    int codigoAlunoInserido = _repository.Insert(aluno);
                    return codigoAlunoInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Insert Aluno CPF Ja Cadastrado");
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Insert Aluno OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Aluno aluno)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Update Aluno CPF = " + aluno.cpf + " IN");
                Aluno alunoExistente =  _repository.SearchCpf(aluno.cpf);

                if (alunoExistente != null)
                {
                    Log.write(Log.Nivel.INFO, "Update Aluno OK");
                    _repository.Update(aluno);
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Update Aluno CPF = " + aluno.cpf + " não existe");
                    _notificationContext.AddNotification("Aluno não encontrado.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Update Aluno OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Delete Aluno Codigo  = " + codigo+ " IN");
                Aluno aluno = _repository.SelectById(codigo);

                if (aluno == null)
                {
                    Log.write(Log.Nivel.INFO, "Delete Aluno Codigo  = " + codigo + " Não encontrado");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(aluno);
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.INFO, ex, "Delete Aluno Codigo  = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
                _notificationContext.AddNotification(ex.Message);
            }

            return 0;
        }
    }
}
