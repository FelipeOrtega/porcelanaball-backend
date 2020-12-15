using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IFuncionarioRepository _repositoryFuncionario;
        private readonly IFormaPagamentoRepository _repositoryFormaPagamento;
        private readonly IProdutoRepository _repositoryProduto;

        public LancamentoService(
            ILancamentoRepository repository, 
            NotificationContext notificationContext, 
            IFuncionarioRepository repositoryFuncionario,
            IFormaPagamentoRepository repositoryFormaPagamento,
            IProdutoRepository repositoryProduto)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryFuncionario = repositoryFuncionario;
            _repositoryFormaPagamento = repositoryFormaPagamento;
            _repositoryProduto = repositoryProduto;
        }

        public List<Lancamento> Get()
        {
            try
            {
                List<Lancamento> lancamentos = _repository.Consultar();
                return lancamentos;
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Lancamento Get(int codigo)
        {
            try
            {
                Lancamento lancamento = _repository.SelecionarPorId(codigo);
                return lancamento;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Lancamento lancamento)
        {
            try
            {
                var existeSaldo = true;
                Funcionario funcionarioExiste = _repositoryFuncionario.SelecionarPorId(lancamento.funcionario_codigo.Value);
                FormaPagamento formaPagamentoExiste = _repositoryFormaPagamento.SelecionarPorId(lancamento.forma_pagamento_codigo.Value);

                if ((funcionarioExiste != null && funcionarioExiste.ativo) && formaPagamentoExiste != null)
                {
                    if (lancamento.lancamentoProduto != null)
                    {
                        Produto produtoExiste;
                        for (int i = 0; i < lancamento.lancamentoProduto.Count; i++)
                        {
                            produtoExiste = _repositoryProduto.SelecionarPorId(lancamento.lancamentoProduto[i].produto_codigo);

                            if (produtoExiste.saldo < lancamento.lancamentoProduto[i].quantidade)
                            {
                                _notificationContext.AddNotification("Não existe saldo suficiente no produto com codigo: " + 
                                    lancamento.lancamentoProduto[i].produto_codigo);
                                existeSaldo = false;
                            }
                            else
                            {
                                produtoExiste.saldo = produtoExiste.saldo - lancamento.lancamentoProduto[i].quantidade;
                            }
                        }
                    }

                    if (existeSaldo)
                    {
                        int codigoLancamentoInserido = _repository.Inserir(lancamento);
                        return codigoLancamentoInserido;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    _notificationContext.AddNotification("É necessário incluir funcionario e/ou forma de pagamento.");
                    return 0;
                }
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Lancamento lancamento)
        {
            try
            {
                _repository.Alterar(lancamento);
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
                Lancamento lancamento = _repository.SelecionarPorId(codigo);
                if (lancamento == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Excluir(lancamento);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
