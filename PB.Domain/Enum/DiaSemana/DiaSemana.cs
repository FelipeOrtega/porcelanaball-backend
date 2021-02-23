using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PB.Domain
{
    public enum DiaSemana
    {
        [Description("Segunda-feira")]
        SEGUNDA,

        [Description("Terça-feira")]
        TERCA,

        [Description("Quarta-feira")]
        QUARTA,

        [Description("Quinta-feira")]
        QUINTA,

        [Description("Sexta-feira")]
        SEXTA,

        [Description("Sábado")]
        SABADO,

        [Description("Domingo")]
        DOMINGO

    }
}
