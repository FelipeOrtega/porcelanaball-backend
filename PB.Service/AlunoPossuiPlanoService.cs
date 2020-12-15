﻿using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;

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
                List<AlunoPossuiPlano> alunoPossuiPlanos = _repository.Consultar();
                return alunoPossuiPlanos;
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public AlunoPossuiPlano Get(int codigo)
        {
            try
            {
                AlunoPossuiPlano alunoPossuiPlano = _repository.SelecionarPorId(codigo);
                return alunoPossuiPlano;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(AlunoPossuiPlano alunoPossuiPlano)
        {
            try
            {
                if (VerificaInclusaoAlteracao(alunoPossuiPlano))
                {
                    int codigoAlunoPossuiPlanoInserido = _repository.Inserir(alunoPossuiPlano);
                    return codigoAlunoPossuiPlanoInserido;
                }
                else
                {
                    _notificationContext.AddNotification("Aluno ou Plano inexistente(s) ou inativo(s).");
                }
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(AlunoPossuiPlano alunoPossuiPlano)
        {
            try
            {
                if (VerificaInclusaoAlteracao(alunoPossuiPlano))
                {
                    _repository.Alterar(alunoPossuiPlano);
                }
                else
                {
                    _notificationContext.AddNotification("Aluno ou Plano inexistente(s) ou inativo(s).");
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
                AlunoPossuiPlano alunoPossuiPlano = _repository.SelecionarPorId(codigo);
                if (alunoPossuiPlano == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Excluir(alunoPossuiPlano);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool VerificaInclusaoAlteracao(AlunoPossuiPlano alunoPossuiPlano)
        {
            try
            {
                Aluno alunoExiste = _repositoryAluno.SelecionarPorId(alunoPossuiPlano.aluno_codigo);
                Plano planoExiste = _repositoryPlano.SelecionarPorId(alunoPossuiPlano.plano_codigo);

                return ((alunoExiste != null && alunoExiste.ativo) && (planoExiste != null && planoExiste.ativo));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
