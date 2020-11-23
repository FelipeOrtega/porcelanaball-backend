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
                List<ProdutoCategoria> produtosCategoria = _repository.Consultar();
                return produtosCategoria;
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public ProdutoCategoria Get(int codigo)
        {
            try
            {
                ProdutoCategoria produtoCategoria = _repository.SelecionarPorId(codigo);
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
                int codigoProdutoCategoriaInserido = _repository.Inserir(produtoCategoria);
                return codigoProdutoCategoriaInserido;
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
                _repository.Alterar(produtoCategoria);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(ProdutoCategoria produtoCategoria)
        {
            try
            {
                _repository.Excluir(produtoCategoria);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
