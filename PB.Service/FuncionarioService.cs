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
            }
            return null;
        }

        public Funcionario Get(int codigo)
        {
            try
            {
                Funcionario Funcionario = _repository.SelecionarPorId(codigo);
                return Funcionario;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public int Insert(Funcionario Funcionario)
        {
            try
            {
                int codigoFuncionarioInserido = _repository.Inserir(Funcionario);
                return codigoFuncionarioInserido;
            }
            catch (Exception)
            {

            }
            return 0;
        }

        public int Update(Funcionario Funcionario)
        {
            try
            {
                _repository.Alterar(Funcionario);
            }
            catch (Exception)
            {

            }

            return 0;
        }

        public int Delete(Funcionario Funcionario)
        {
            try
            {
                _repository.Excluir(Funcionario);
            }
            catch (Exception)
            {

            }

            return 0;
        }
    }
}