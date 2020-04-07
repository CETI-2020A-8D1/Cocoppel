using System;
using System.Collections.Generic;

namespace Cocoppel.DTO
{
    public partial class TarjetaDebitoDTO
    {
        public int IdnumeroDeCuenta { get; set; }
        public string Numero { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Cvv { get; set; }

        public virtual CuentaChequesDTO IdnumeroDeCuentaNavigation { get; set; }
    }
}
