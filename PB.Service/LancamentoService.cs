using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Lancamento> lancamentos = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return lancamentos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Lancamento Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Lancamento lancamento = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return lancamento;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Lancamento lancamento)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo funcionario = " + lancamento.funcionario_codigo + " IN");

                Lancamento lancamentoValido = CheckInsertUpdate(lancamento);

                if (lancamentoValido != null)
                {
                    int codigoLancamentoInserido = _repository.Insert(lancamento);
                    Log.write(Log.Nivel.INFO, "Codigo funcionario = " + lancamento.funcionario_codigo + " OUT");
                    return codigoLancamentoInserido;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo funcionario = " + lancamento.funcionario_codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Lancamento lancamento)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo funcionario = " + lancamento.funcionario_codigo + ", codigo lancamento= " + lancamento.codigo + " IN");

                Lancamento lancamentoValido = CheckInsertUpdate(lancamento);

                if (lancamentoValido != null)
                {
                    _repository.Update(lancamento);
                    Log.write(Log.Nivel.INFO, "Codigo funcionario = " + lancamento.funcionario_codigo + ", codigo lancamento= " + lancamento.codigo + " OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Codigo funcionario = " + lancamento.funcionario_codigo + ", codigo lancamento= " + lancamento.codigo + " Lancamento nao é valido OUT");
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo funcionario = " + lancamento.funcionario_codigo + ", codigo lancamento= " + lancamento.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Lancamento lancamento = _repository.SelectById(codigo);

                if (lancamento == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(lancamento);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        public Lancamento CheckInsertUpdate(Lancamento lancamento)
        {
            var existeSaldo = true;
            Funcionario funcionarioExiste = _repositoryFuncionario.SelectById(lancamento.funcionario_codigo.Value);

            if ((funcionarioExiste != null && funcionarioExiste.ativo) && lancamento.lancamentoFormaPagamento != null)
            {
                if (lancamento.lancamentoProduto != null)
                {
                    Produto produtoExiste;
                    for (int i = 0; i < lancamento.lancamentoProduto.Count; i++)
                    {
                        produtoExiste = _repositoryProduto.SelectById(lancamento.lancamentoProduto[i].produto_codigo);

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
                    return lancamento;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                _notificationContext.AddNotification("É necessário incluir funcionario e/ou forma de pagamento.");
                throw new Exception();
            }
        }
    }
}
