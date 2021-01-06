using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

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
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<ProdutoCategoria> produtosCategoria = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return produtosCategoria;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public ProdutoCategoria Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                ProdutoCategoria produtoCategoria = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return produtoCategoria;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(ProdutoCategoria produtoCategoria)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                if (CheckInsertUpdate(produtoCategoria))
                {
                    int codigoProdutoCategoriaInserido = _repository.Insert(produtoCategoria);
                    Log.write(Log.Nivel.INFO, "OUT");
                    return codigoProdutoCategoriaInserido;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(ProdutoCategoria produtoCategoria)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + produtoCategoria.codigo + " IN");
                if (CheckInsertUpdate(produtoCategoria))
                {
                    _repository.Update(produtoCategoria);
                    Log.write(Log.Nivel.INFO, "Codigo = " + produtoCategoria.codigo + " OUT");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + produtoCategoria.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                ProdutoCategoria produtoCategoria = _repository.SelectById(codigo);

                if (produtoCategoria == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }
                _repository.Delete(produtoCategoria);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
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
