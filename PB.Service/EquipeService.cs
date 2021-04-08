using PB.Domain;
using PB.Domain.DTO;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Service.Interface;
using System;
using System.Collections.Generic;
using PB.Utils;
using System.Linq;

namespace PB.Service
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _repository;
        private readonly NotificationContext _notificationContext;
        private readonly IModalidadeRepository _repositoryModalidade;
        private readonly IModuloRepository _repositoryModulo;
        private readonly IPagamentoRepository _repositoryPagamento;
        private readonly IEquipeAlunoRepository _repositoryEquipeAluno;

        public EquipeService(IEquipeRepository repository, NotificationContext notificationContext,
            IModalidadeRepository repositoryModalidade, IModuloRepository repositoryModulo, IPagamentoRepository repositoryPagamento,
            IEquipeAlunoRepository repositoryEquipeAluno)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _repositoryModalidade = repositoryModalidade;
            _repositoryModulo = repositoryModulo;
            _repositoryPagamento = repositoryPagamento;
            _repositoryEquipeAluno = repositoryEquipeAluno;
        }

        public List<Equipe> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<Equipe> equipes = _repository.FullList();
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
                Equipe equipe = _repository.FullSearch(codigo);
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
                List<PagamentoDTO> pagamentosDTOVigentes = new List<PagamentoDTO>();
                List<PagamentoDTO> pagamentosDTONaoVigentes = new List<PagamentoDTO>();
                decimal valorTotalPago = 0;

                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");

                equipePagamentoDTO.equipe = _repository.SelectById(codigo);

                DateTime datanow = DateTime.Now;
                DateTime MesVencimento = new DateTime(datanow.Year, datanow.Month, equipePagamentoDTO.equipe.dia_vencimento);
                DateTime MesAnterior = new DateTime(datanow.Year, datanow.Month, equipePagamentoDTO.equipe.dia_vencimento);
                if(datanow.Day <= equipePagamentoDTO.equipe.dia_vencimento)
                {
                    MesAnterior = MesAnterior.AddMonths(-1);
                }
                else
                {
                    MesVencimento = MesVencimento.AddMonths(1);
                }

                List<Pagamento> pagamentos = _repositoryPagamento.SearchCodigo_Equipe(codigo);

                foreach (Pagamento pagamento in pagamentos)
                {
                    PagamentoDTO pagamentoDTO = new PagamentoDTO();

                    if ((pagamento.data > MesAnterior) && (pagamento.data <= MesVencimento))
                    {
                        pagamentoDTO.convertPagamentoToDTO(pagamento);
                        pagamentosDTOVigentes.Add(pagamentoDTO);
                        valorTotalPago += pagamento.valor;
                    }
                    else
                    {
                        pagamentoDTO.convertPagamentoToDTO(pagamento);
                        pagamentosDTONaoVigentes.Add(pagamentoDTO);
                    }
                }

                equipePagamentoDTO.pagamentosVigentes = pagamentosDTOVigentes;
                equipePagamentoDTO.pagamentosNaoVigentes = pagamentosDTONaoVigentes;

                if (valorTotalPago <= equipePagamentoDTO.equipe.valor)
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
                Equipe equipeExiste = _repository.SelectById(equipe.codigo);
                if (equipeExiste != null)
                {
                    deleteReleatedEntitesToUpdate(equipe);
                    Log.write(Log.Nivel.INFO, "Codigo = " + equipe.codigo + " IN");
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

        private void deleteReleatedEntitesToUpdate(Equipe equipe)
        {
            var equipesAlunosNotInNewEquipeAluno = _repositoryEquipeAluno.GetByEquipeCodigo(equipe.codigo);
            foreach (var equipeAlunoNotInNewEquipeAluno in equipesAlunosNotInNewEquipeAluno.ToList())
            {
                _repositoryEquipeAluno.Delete(equipeAlunoNotInNewEquipeAluno);
            }
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
