using System;
using System.Collections.Generic;

namespace ApiBanco.Models
{
    public partial class TarjetaDebito
    {
        public TarjetaDebito()
        {
            Cliente = new HashSet<Cliente>();
            Transaccion = new HashSet<Transaccion>();
        }

        public long NumeroDeTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public short Ccv { get; set; }
        public long Saldo { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Transaccion> Transaccion { get; set; }
    }
}
