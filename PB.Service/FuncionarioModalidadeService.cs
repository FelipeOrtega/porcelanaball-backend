using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class FuncionarioModalidadeService : IFuncionarioModalidadeService
    {
        private readonly IFuncionarioModalidadeRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IFuncionarioRepository _repositoryFuncionario;

        public FuncionarioModalidadeService(IFuncionarioModalidadeRepository repository, NotificationContext notificationContext, IFuncionarioRepository repositoryFuncionario)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public List<FuncionarioModalidade> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<FuncionarioModalidade> modalidadesFuncionario = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return modalidadesFuncionario;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public FuncionarioModalidade Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                FuncionarioModalidade modalidadeFuncionario = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return modalidadeFuncionario;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(FuncionarioModalidade modalidadeFuncionario)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "modalidade_codigo = " + modalidadeFuncionario.modalidade_codigo + " IN");
                if (CheckInsertUpdate(modalidadeFuncionario))
                {
                    int codigoModalidadeFuncionarioInserido = _repository.Insert(modalidadeFuncionario);
                    Log.write(Log.Nivel.INFO, "modalidade_codigo = " + modalidadeFuncionario.modalidade_codigo + " OUT");
                    return codigoModalidadeFuncionarioInserido;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "modalidade_codigo = " + modalidadeFuncionario.modalidade_codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(FuncionarioModalidade modalidadeFuncionario)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + modalidadeFuncionario.codigo + " IN");
                if (CheckInsertUpdate(modalidadeFuncionario))
                {
                    _repository.Update(modalidadeFuncionario);
                    Log.write(Log.Nivel.INFO, "Codigo = " + modalidadeFuncionario.codigo + " OUT");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + modalidadeFuncionario.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                FuncionarioModalidade modalidadeFuncionario = _repository.SelectById(codigo);

                if (modalidadeFuncionario == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(modalidadeFuncionario);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(FuncionarioModalidade modalidadeFuncionario)
        {
            FuncionarioModalidade modalidadeFuncionarioExiste = _repository.
                    ModalidadeFuncionarioExist(modalidadeFuncionario.funcionario_codigo, modalidadeFuncionario.modalidade_codigo);

            if (modalidadeFuncionarioExiste == null)
            {
                Funcionario funcionarioExiste = _repositoryFuncionario.SelectById(modalidadeFuncionario.funcionario_codigo);

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
