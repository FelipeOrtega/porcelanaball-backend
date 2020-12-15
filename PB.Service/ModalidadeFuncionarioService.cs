using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class ModalidadeFuncionarioService : IModalidadeFuncionarioService
    {
        private readonly IModalidadeFuncionarioRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IFuncionarioRepository _repositoryFuncionario;

        public ModalidadeFuncionarioService(IModalidadeFuncionarioRepository repository, NotificationContext notificationContext, 
            IFuncionarioRepository repositoryFuncionario)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryFuncionario = repositoryFuncionario;
        }
        public List<ModalidadeFuncionario> Get()
        {
            try
            {
                List<ModalidadeFuncionario> modalidadesFuncionario = _repository.Consultar();
                return modalidadesFuncionario;
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public ModalidadeFuncionario Get(int codigo)
        {
            try
            {
                ModalidadeFuncionario modalidadeFuncionario = _repository.SelecionarPorId(codigo);
                return modalidadeFuncionario;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(ModalidadeFuncionario modalidadeFuncionario)
        {
            try
            {
                if (VerificaInclusaoAlteracao(modalidadeFuncionario))
                {
                    int codigoModalidadeFuncionarioInserido = _repository.Inserir(modalidadeFuncionario);
                    return codigoModalidadeFuncionarioInserido;
                }
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(ModalidadeFuncionario modalidadeFuncionario)
        {
            try
            {
                if (VerificaInclusaoAlteracao(modalidadeFuncionario))
                {
                    _repository.Alterar(modalidadeFuncionario);
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
                ModalidadeFuncionario modalidadeFuncionario = _repository.SelecionarPorId(codigo);
                if (modalidadeFuncionario == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Excluir(modalidadeFuncionario);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool VerificaInclusaoAlteracao(ModalidadeFuncionario modalidadeFuncionario)
        {
            ModalidadeFuncionario modalidadeFuncionarioExiste = _repository.
                    ModalidadeFuncionarioExiste(modalidadeFuncionario.funcionario_codigo, modalidadeFuncionario.modalidade_codigo);

            if (modalidadeFuncionarioExiste == null)
            {
                Funcionario funcionarioExiste = _repositoryFuncionario.SelecionarPorId(modalidadeFuncionario.funcionario_codigo);

                if (funcionarioExiste != null && funcionarioExiste.ativo)
                {
                    return true;
                }
                else
                {
                    _notificationContext.AddNotification("Funcionario inexistente ou inativo.");
                    return false;
                }
            }
            else
            {
                _notificationContext.AddNotification("Já existe um cadastro para essa modalidade_funcionario.");
                return false;
            }
        }
    }
}
