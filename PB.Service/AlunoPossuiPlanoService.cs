using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class AlunoPossuiPlanoService : IAlunoPossuiPlanoService
    {
        private readonly IAlunoPossuiPlanoRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IAlunoRepository _repositoryAluno;
        private readonly IPlanoRepository _repositoryPlano;

        public AlunoPossuiPlanoService(
            IAlunoPossuiPlanoRepository repository, 
            NotificationContext notificationContext,
            IAlunoRepository repositoryAluno,
            IPlanoRepository repositoryPlano)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryAluno = repositoryAluno;
            _repositoryPlano = repositoryPlano;
        }

        public List<AlunoPossuiPlano> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Get<List> AlunoPossuiPlano IN");
                List<AlunoPossuiPlano> alunoPossuiPlanos = _repository.Get();
                Log.write(Log.Nivel.INFO, "Get<List> AlunoPossuiPlano OUT");
                return alunoPossuiPlanos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Get<List> AlunoPossuiPlano OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoPossuiPlano Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Get AlunoPossuiPlano Codigo = " + codigo + " IN");
                AlunoPossuiPlano alunoPossuiPlano = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Get AlunoPossuiPlano Codigo = " + codigo + " OUT");
                return alunoPossuiPlano;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Get AlunoPossuiPlano Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(AlunoPossuiPlano alunoPossuiPlano)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Insert AlunoPossuiPlano IN");
                if (CheckInsertUpdate(alunoPossuiPlano))
                {
                    int codigoAlunoPossuiPlanoInserido = _repository.Insert(alunoPossuiPlano);
                    Log.write(Log.Nivel.INFO, "Insert AlunoPossuiPlano OUT");
                    return codigoAlunoPossuiPlanoInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Insert AlunoPossuiPlano inexistente(s) ou inativo(s). OUT");
                    _notificationContext.AddNotification("Aluno ou Plano inexistente(s) ou inativo(s).");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Insert AlunoPossuiPlano OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(AlunoPossuiPlano alunoPossuiPlano)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Update AlunoPossuiPlano IN");
                if (CheckInsertUpdate(alunoPossuiPlano))
                {
                    _repository.Update(alunoPossuiPlano);
                    Log.write(Log.Nivel.INFO, "Update AlunoPossuiPlano OK OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Update AlunoPossuiPlano Aluno ou Plano inexistente(s) ou inativo(s). OUT");
                    _notificationContext.AddNotification("Aluno ou Plano inexistente(s) ou inativo(s).");
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Update AlunoPossuiPlano OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Delete AlunoPossuiPlano Codigo  = " + codigo + " IN");
                AlunoPossuiPlano alunoPossuiPlano = _repository.SelectById(codigo);

                if (alunoPossuiPlano == null)
                {
                    Log.write(Log.Nivel.INFO, "Delete AlunoPossuiPlano Codigo  = " + codigo + " nao encontrado OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(alunoPossuiPlano);
                Log.write(Log.Nivel.INFO, "Delete AlunoPossuiPlano OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.INFO, ex, "Delete AlunoPossuiPlano Codigo  = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(AlunoPossuiPlano alunoPossuiPlano)
        {
            try
            {
                Aluno alunoExiste = _repositoryAluno.SelectById(alunoPossuiPlano.aluno_codigo);
                Plano planoExiste = _repositoryPlano.SelectById(alunoPossuiPlano.plano_codigo);

                return ((alunoExiste != null && alunoExiste.ativo) && (planoExiste != null && planoExiste.ativo));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
