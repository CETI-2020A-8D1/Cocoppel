using System;
using System.Collections.Generic;

namespace Cocoppel.Models
{
    public partial class LineaCredito
    {
        public int IdlineaDeCredito { get; set; }
        public int Idusuario { get; set; }
        public bool Valida { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal CantidadMaximaDisponible { get; set; }
        public decimal SaldoRestante { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual TarjetaCredito TarjetaCredito { get; set; }
    }
}
