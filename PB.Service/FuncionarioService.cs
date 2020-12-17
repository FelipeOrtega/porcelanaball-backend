using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

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
                List<Funcionario> funcionarios = _repository.Get();
                return funcionarios;
            }
            catch(Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Funcionario Get(int codigo)
        {
            try
            {
                Funcionario funcionario = _repository.SelectById(codigo);
                return funcionario;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Funcionario funcionario)
        {
            try
            {
                if (CheckInsertUpdate(funcionario))
                {
                    int codigoFuncionarioInserido = _repository.Insert(funcionario);
                    return codigoFuncionarioInserido;
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

        public int Update(Funcionario funcionario)
        {
            try
            {
                if (CheckInsertUpdate(funcionario))
                {
                    _repository.Update(funcionario);
                }
                else
                {
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
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
                Funcionario funcionario = _repository.SelectById(codigo);

                if (funcionario == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(funcionario);
            }
            catch (Exception)
            {
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
