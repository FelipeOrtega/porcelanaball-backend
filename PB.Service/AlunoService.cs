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
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Aluno> alunos = _repository.FullList();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return alunos;
            }
            catch (Exception ex) 
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }
            return null;
        }

        public Aluno Get(int codigo)
        { 
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Aluno aluno = _repository.SelectById(codigo);
                aluno = _repository.FullSearch(aluno);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return aluno;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Aluno aluno)
        {
            try
            {
                aluno.rg = Util.removeCaracteresEspeciais(aluno.rg);
                aluno.cpf = Util.removeCaracteresEspeciais(aluno.cpf);
                aluno.telefone_celular = Util.removeCaracteresEspeciais(aluno.telefone_celular);
                aluno.telefone_residencial = Util.removeCaracteresEspeciais(aluno.telefone_residencial);

                Log.write(Log.Nivel.INFO, "CPF = " + aluno.cpf + " IN");
                Aluno alunoExiste = _repository.SearchCpf(aluno.cpf);

                if (alunoExiste == null)
                {
                    Log.write(Log.Nivel.INFO, "CPF = " + aluno.cpf + " OUT");
                    int codigoAlunoInserido = _repository.Insert(aluno);
                    return codigoAlunoInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Já existe um cadastro para esse CPF OUT");
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Aluno aluno)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "CPF = " + aluno.cpf + " IN");
                Aluno alunoExistente =  _repository.SearchCpf(aluno.cpf);

                if (alunoExistente != null)
                {
                    _repository.Update(aluno);
                    Log.write(Log.Nivel.INFO, "CPF = " + aluno.cpf + " OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "CPF = " + aluno.cpf + " Aluno não encontrado OUT");
                    _notificationContext.AddNotification("Aluno não encontrado.");
                    return 0;
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
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo+ " IN");
                Aluno aluno = _repository.SelectById(codigo);

                if (aluno == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + ", Este cadastro não foi encontrado no banco de dados OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(aluno);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
                _notificationContext.AddNotification(ex.Message);
            }

            return 0;
        }
    }
}
