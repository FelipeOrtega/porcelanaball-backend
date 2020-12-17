using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

namespace PB.Service
{
    public class ProdutoCategoriaService : IProdutoCategoriaService
    {
        private readonly IProdutoCategoriaRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ProdutoCategoriaService(IProdutoCategoriaRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<ProdutoCategoria> Get()
        {
            try
            {
                List<ProdutoCategoria> produtosCategoria = _repository.Get();
                return produtosCategoria;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public ProdutoCategoria Get(int codigo)
        {
            try
            {
                ProdutoCategoria produtoCategoria = _repository.SelectById(codigo);
                return produtoCategoria;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(ProdutoCategoria produtoCategoria)
        {
            try
            {
                if (CheckInsertUpdate(produtoCategoria))
                {
                    int codigoProdutoCategoriaInserido = _repository.Insert(produtoCategoria);
                    return codigoProdutoCategoriaInserido;
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(ProdutoCategoria produtoCategoria)
        {
            try
            {
                if (CheckInsertUpdate(produtoCategoria))
                {
                    _repository.Update(produtoCategoria);
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
                ProdutoCategoria produtoCategoria = _repository.SelectById(codigo);

                if (produtoCategoria == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }
                _repository.Delete(produtoCategoria);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(ProdutoCategoria produtoCategoria)
        {
            ProdutoCategoria produtoCategoriaExiste = _repository.SearchByDescription(produtoCategoria.descricao);

            if (produtoCategoriaExiste == null)
            {
                return true;
            }
            else
            {
                _notificationContext.AddNotification("Já existe um cadastro para essa descrição de categoria.");
                return false;
            }
        }
    }
}
