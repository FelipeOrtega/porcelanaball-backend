using System;

namespace PB.Domain.DTO
{
    public class PagamentoDTO
    {
        public decimal valor_pago;
        public DateTime data_pagamento;
        public string observacao;

        public void convertPagamentoToDTO(Pagamento pagamento) {

            valor_pago = pagamento.valor;
            data_pagamento = pagamento.data;
            observacao = pagamento.observacao;
        }

    }
}
