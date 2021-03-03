using PB.Domain.Core;
using System;
using System.Collections.Generic;

namespace PB.Domain
{
    public class Equipe : EntityBase
    {
        public string descricao { get; set; }
        public int modalidade_codigo { get; set; }
        public bool ativo { get; set; }
        public int modulo_codigo { get; set; }
        public Decimal valor { get; set; }
        public int dia_vencimento { get; set; }
        public bool adere_academia { get; set; }
        public string jogo_dia_da_semana { get; set; }
        public TimeSpan jogo_horario_inicial { get; set; }
        public TimeSpan jogo_horario_final { get; set; }
        public int quadra_codigo { get; set; }
        public List<EquipeAluno> equipeAluno { get; set; }
    }
}
