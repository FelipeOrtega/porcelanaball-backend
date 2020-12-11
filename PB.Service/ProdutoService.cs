using System;
using System.Collections.Generic;
using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;

namespace PB.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IProdutoCategoriaRepository _repositoryProdutoCategoria;
        private readonly NotificationContext _notificationContext;

        public ProdutoService(IProdutoRepository repository, NotificationContext notificationContext, IProdutoCategoriaRepository repositoryProdutoCategoria)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryProdutoCategoria = repositoryProdutoCategoria;
        }

        public List<Produto> Get()
        {
            try
            {
                List<Produto> produtos = _repository.Consultar();
                return produtos;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Produto Get(int codigo)
        {
            try
            {
                Produto produto = _repository.SelecionarPorId(codigo);
                return produto;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Produto produto)
        {
            try
            {
                if (VerificaInclusaoAlteracao(produto))
                {
                    int codigoProdutoInserido = _repository.Inserir(produto);
                    return codigoProdutoInserido;
                }
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Produto produto)
        {
            try
            {
                if (VerificaInclusaoAlteracao(produto))
                {
                    _repository.Alterar(produto);
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(Produto produto)
        {
            try
            {
                _repository.Excluir(produto);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool VerificaInclusaoAlteracao(Produto produto)
        {
            Produto produtoExiste = _repository.ConsultaPorDescricao(produto.descricao);

            if (produtoExiste == null)
            {
                ProdutoCategoria produtoCategoriaExiste = _repositoryProdutoCategoria.SelecionarPorId(produto.produto_categoria_codigo);

                if (produtoCategoriaExiste != null)
                {
                    return true;
                }
                else
                {
                    _notificationContext.AddNotification("Código da categoria não encontrado.");
                    return false;
                }
            }
            else
            {
                _notificationContext.AddNotification("Já existe um cadastro para essa descrição de produto.");
                return false;
            }
        }
    }
}
