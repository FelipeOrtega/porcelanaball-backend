using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        private readonly NotificationContext _notificationContext;

        public FuncionarioService(IFuncionarioRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Funcionario> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Funcionario> funcionarios = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return funcionarios;
            }
            catch(Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Funcionario Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Funcionario funcionario = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return funcionario;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Funcionario funcionario)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "CPF = " + funcionario.cpf + " IN");
                if (CheckInsertUpdate(funcionario))
                {
                    int codigoFuncionarioInserido = _repository.Insert(funcionario);
                    Log.write(Log.Nivel.INFO, "CPF = " + funcionario.cpf + " OUT");
                    return codigoFuncionarioInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "CPF = " + funcionario.cpf + " Já existe um cadastro para esse CPF OUT");
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "CPF = " + funcionario.cpf + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Funcionario funcionario)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "CPF = " + funcionario.cpf + " IN");
                if (CheckInsertUpdate(funcionario))
                {
                    _repository.Update(funcionario);
                    Log.write(Log.Nivel.INFO, "CPF = " + funcionario.cpf + " OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "CPF = " + funcionario.cpf + " Já existe um cadastro para esse CPF. OUT");
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "CPF = " + funcionario.cpf + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Funcionario funcionario = _repository.SelectById(codigo);

                if (funcionario == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(funcionario);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(Funcionario funcionario)
        {
            try
            {
                Funcionario funcionarioExiste = _repository.SearchCpf(funcionario.cpf);

                return (funcionarioExiste == null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
