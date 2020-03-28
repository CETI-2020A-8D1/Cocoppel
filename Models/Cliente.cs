using System;
using System.Collections.Generic;

namespace ApiBanco.Models
{
    public partial class Cliente
    {
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public long? TarjetaCredito { get; set; }
        public long? TarjetaDebito { get; set; }
        public long IdUsuario { get; set; }

        public TarjetaCredito TarjetaCreditoNavigation { get; set; }
        public TarjetaDebito TarjetaDebitoNavigation { get; set; }
    }
}
