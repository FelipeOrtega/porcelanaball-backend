﻿using PB.Domain;
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
                Funcionario funcionario = _repository.SelecionarPorId(codigo);
                return funcionario;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public int Insert(Funcionario funcionario)
        {
            try
            {
                int codigoFuncionarioInserido = _repository.Inserir(funcionario);
                return codigoFuncionarioInserido;
            }
            catch (Exception)
            {

            }
            return 0;
        }

        public int Update(Funcionario funcionario)
        {
            try
            {
                _repository.Alterar(funcionario);
            }
            catch (Exception)
            {

            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Funcionario funcionario = _repository.SelecionarPorId(codigo);
                _repository.Excluir(funcionario);
            }
            catch (Exception)
            {

            }

            return 0;
        }
    }
}
