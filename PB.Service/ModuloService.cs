using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ModuloService(IModuloRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<Modulo> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Modulo> modulos = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return modulos;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Modulo Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Modulo modulo = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return modulo;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Modulo modulo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                int codigoModuloInserido = _repository.Insert(modulo);
                Log.write(Log.Nivel.INFO, "OUT");
                return codigoModuloInserido;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Modulo modulo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + modulo.codigo + " IN");
                _repository.Update(modulo);
                Log.write(Log.Nivel.INFO, "Codigo = " + modulo.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + modulo.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Modulo modulo = _repository.SelectById(codigo);

                if (modulo == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(modulo);
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
