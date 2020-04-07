using System;
using System.Collections.Generic;

namespace Cocoppel.DTO
{
    public partial class LineaCreditoDTO
    {
        public int IdlineaDeCredito { get; set; }
        public int Idusuario { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal CantidadMaximaDisponible { get; set; }
        public decimal SaldoRestante { get; set; }

        public virtual UsuarioDTO IdusuarioNavigation { get; set; }
        public virtual TarjetaCreditoDTO TarjetaCredito { get; set; }
    }
}
