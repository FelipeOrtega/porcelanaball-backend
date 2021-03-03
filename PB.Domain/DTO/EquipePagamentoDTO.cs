using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PB.Domain.DTO
{
    public class EquipePagamentoDTO
    {
        public Equipe equipe { get; set; }
        public decimal valorRestante { get; set; }
        public List<PagamentoDTO> pagamentos { get; set; }

    }
}
