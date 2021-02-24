using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class QuadraService : IQuadraService
    {
        private readonly IQuadraRepository _repository;
        private readonly NotificationContext _notificationContext;

        public QuadraService(IQuadraRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Quadra> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Quadra> quadras = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return quadras;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Quadra Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Quadra quadra = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return quadra;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Quadra quadra)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                int codigoQuadraInserido = _repository.Insert(quadra);
                Log.write(Log.Nivel.INFO, "OUT");
                return codigoQuadraInserido;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Quadra quadra)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + quadra.codigo + " IN");
                _repository.Update(quadra);
                Log.write(Log.Nivel.INFO, "Codigo = " + quadra.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + quadra.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Quadra quadra = _repository.SelectById(codigo);

                if (quadra == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(quadra);
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
