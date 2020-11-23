using PB.Domain.Core;

namespace PB.Domain
{
    public class ModalidadeFuncionario : EntityBase
    {
        public int modalidade_codigo { get; set; }
        public int funcionario_codigo { get; set; }
    }
}
