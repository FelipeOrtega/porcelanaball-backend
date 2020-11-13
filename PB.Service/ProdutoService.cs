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
        /*    try
            {
                List<Aluno> alunos = _repository.Consultar();
                return alunos;
            }
            catch (Exception)
            {

            }*/

            return null;
        }

        public Produto Get(int codigo)
        {
          /*  try
            {
                Aluno aluno = _repository.SelecionarPorId(codigo);
                return aluno;
            }
            catch (Exception)
            {

            }*/

            return null;
        }

        public int Insert(Produto aluno)
        {
           /* try
            {
                int codigoAlunoInserido = _repository.Inserir(aluno);
                return codigoAlunoInserido;
            }
            catch (Exception)
            {

            }*/
            return 0;
        }

        public int Update(Produto aluno)
        {
          /*  try
            {
                _repository.Alterar(aluno);
            }
            catch (Exception)
            {

            }*/

            return 0;
        }

        public int Delete(Produto aluno)
        {
           /* try
            {
                _repository.Excluir(aluno);
            }
            catch (Exception)
            {

            }*/

            return 0;
        }
    }
}
