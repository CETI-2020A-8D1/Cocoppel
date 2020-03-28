using System;
using System.Collections.Generic;

namespace ApiBanco.Models
{
    public partial class Transaccion
    {
        public long IdTransaccion { get; set; }
        public byte TipoMovimiento { get; set; }
        public long Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public long Tarjeta { get; set; }

        public TarjetaDebito Tarjeta1 { get; set; }
        public TarjetaCredito TarjetaNavigation { get; set; }
        public Movimiento TipoMovimientoNavigation { get; set; }
    }
}
