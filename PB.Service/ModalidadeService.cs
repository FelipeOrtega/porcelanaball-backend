using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IModalidadeRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ModalidadeService(IModalidadeRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Modalidade> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Modalidade> modalidades = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return modalidades;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Modalidade Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Modalidade modalidade = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return modalidade;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Modalidade modalidade)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                int codigoModalidadeInserido = _repository.Insert(modalidade);
                Log.write(Log.Nivel.INFO, "OUT");
                return codigoModalidadeInserido;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Modalidade modalidade)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + modalidade.codigo + " IN");
                _repository.Update(modalidade);
                Log.write(Log.Nivel.INFO, "Codigo = " + modalidade.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + modalidade.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Modalidade modalidade = _repository.SelectById(codigo);

                if (modalidade == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(modalidade);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
