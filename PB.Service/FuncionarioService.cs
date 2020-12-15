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
                List<Funcionario> funcionarios = _repository.Consultar();
                return funcionarios;
            }
            catch(Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Funcionario Get(int codigo)
        {
            try
            {
                Funcionario funcionario = _repository.SelecionarPorId(codigo);
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
                if (VerificaInclusaoAlteracao(funcionario))
                {
                    int codigoFuncionarioInserido = _repository.Inserir(funcionario);
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
                if (VerificaInclusaoAlteracao(funcionario))
                {
                    _repository.Alterar(funcionario);
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
                Funcionario funcionario = _repository.SelecionarPorId(codigo);
                if (funcionario == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Excluir(funcionario);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool VerificaInclusaoAlteracao(Funcionario funcionario)
        {
            try
            {
                Funcionario funcionarioExiste = _repository.ConsultaCpf(funcionario.cpf);

                return (funcionarioExiste == null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
