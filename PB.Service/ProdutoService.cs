using System;
using System.Collections.Generic;
using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Produto> produtos = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return produtos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Produto Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Produto produto = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return produto;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Produto produto)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                if (CheckInsertUpdate(produto))
                {
                    int codigoProdutoInserido = _repository.Insert(produto);
                    Log.write(Log.Nivel.INFO, "OUT");
                    return codigoProdutoInserido;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Produto produto)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + produto.codigo + " IN");
                if (CheckInsertUpdate(produto))
                {
                    _repository.Update(produto);
                    Log.write(Log.Nivel.INFO, "Codigo = " + produto.codigo + " OUT");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + produto.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Produto produto = _repository.SelectById(codigo);

                if (produto == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }
                _repository.Delete(produto);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(Produto produto)
        {
            Produto produtoExiste = _repository.SearchByDescription(produto.descricao);

            if (produtoExiste == null)
            {
                ProdutoCategoria produtoCategoriaExiste = _repositoryProdutoCategoria.SelectById(produto.produto_categoria_codigo);

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
