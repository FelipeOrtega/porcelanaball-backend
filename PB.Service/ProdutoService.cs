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
        private readonly NotificationContext _notificationContext;

        public ProdutoService(IProdutoRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
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

            }

            return null;
        }

        public int Insert(Produto produto)
        {
            try
            {
                int codigoProdutoInserido = _repository.Inserir(produto);
                return codigoProdutoInserido;
            }
            catch (Exception)
            {

            }
            return 0;
        }

        public int Update(Produto produto)
        {
            try
            {
                _repository.Alterar(produto);
            }
            catch (Exception)
            {

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

            }

            return 0;
        }
    }
}
