using System;
using System.Collections.Generic;

namespace ApiCocoppel.Models
{
    public partial class LineaCredito
    {
        public int IdlineaDeCredito { get; set; }
        public int Idusuario { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal CantidadMaximaDisponible { get; set; }
        public decimal SaldoRestante { get; set; }

        public Usuario IdusuarioNavigation { get; set; }
        public TarjetaCredito TarjetaCredito { get; set; }
    }
}
