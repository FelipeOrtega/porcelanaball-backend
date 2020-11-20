﻿using PB.Domain.Core;
using System;

namespace PB.Domain
{
    public class FuncionarioPossuiPlano : EntityBase
    {
        public int plano_codigo { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_validade { get; set; }
    }
}
