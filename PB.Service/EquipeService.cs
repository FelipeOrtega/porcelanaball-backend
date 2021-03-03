using PB.Domain;
using PB.Domain.DTO;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;

namespace PB.Service
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IModalidadeRepository _repositoryModalidade;
        private readonly IModuloRepository _repositoryModulo;
        private readonly IPagamentoRepository _repositoryPagamento;

        public EquipeService(IEquipeRepository repository, NotificationContext notificationContext,
            IModalidadeRepository repositoryModalidade, IModuloRepository repositoryModulo, IPagamentoRepository repositoryPagamento)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryModalidade = repositoryModalidade;
            _repositoryModulo = repositoryModulo;
            _repositoryPagamento = repositoryPagamento;
        }

        public List<Equipe> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Equipe> equipes = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return equipes;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Equipe Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Equipe equipe = _repository.SelectById(codigo);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return equipe;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }


        public EquipePagamentoDTO GetHistoricoPagamento(int codigo)
        {
            try
            {
                EquipePagamentoDTO equipePagamentoDTO = new EquipePagamentoDTO();
                List<PagamentoDTO> pagamentosDTO = new List<PagamentoDTO>();
                decimal valorTotalPago = 0;

                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");

                equipePagamentoDTO.equipe = _repository.SelectById(codigo);
                List<Pagamento> pagamentos = _repositoryPagamento.SearchCodigo_Equipe(codigo);
             
                foreach (Pagamento pagamento in pagamentos)
                {
                    PagamentoDTO pagamentoDTO = new PagamentoDTO();
                    valorTotalPago = + pagamento.valor;
                    pagamentoDTO.convertPagamentoToDTO(pagamento);
                    pagamentosDTO.Add(pagamentoDTO);
                }

                equipePagamentoDTO.pagamentos = pagamentosDTO;

                if(valorTotalPago <= equipePagamentoDTO.equipe.valor)
                    equipePagamentoDTO.valorRestante = equipePagamentoDTO.equipe.valor - valorTotalPago;

                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return equipePagamentoDTO;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Equipe equipe)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Modalidade_Codigo = " + equipe.modalidade_codigo + " IN");
                if (CheckInsertUpdate(equipe))
                {
                    int equipeInserido = _repository.Insert(equipe);
                    Log.write(Log.Nivel.INFO, "OUT");
                    return equipeInserido;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Equipe equipe)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + equipe.codigo + " IN");
                if (CheckInsertUpdate(equipe))
                {
                    _repository.Update(equipe);
                    Log.write(Log.Nivel.INFO, "OK OUT");
                }
                
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + equipe.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                Equipe equipe = _repository.SelectById(codigo);

                if (equipe == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " nao encontrado OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(equipe);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }

        private bool CheckInsertUpdate(Equipe equipe)
        {
            Equipe equipeExiste = _repository.SearchByDescription(equipe.descricao);

            if (equipeExiste == null)
            {
                Modalidade modalidadeExiste = _repositoryModalidade.SelectById(equipe.modalidade_codigo);
                Modulo moduloExiste = _repositoryModulo.SelectById(equipe.modulo_codigo);

                if (modalidadeExiste != null && moduloExiste != null)
                {
                    return true;
                }
                else
                {
                    _notificationContext.AddNotification("É necessário o preenchimento dos campos modulo e modalidade.");
                    return false;
                }
            }
            else
            {
                _notificationContext.AddNotification("Já existe um cadastro para essa descrição de equipe.");
                return false;
            }
        }
    }
}
