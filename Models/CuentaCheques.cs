using System;
using System.Collections.Generic;

namespace Cocoppel.Models
{
    public partial class CuentaCheques
    {
        public int IdnumeroDeCuenta { get; set; }
        public int Idusuario { get; set; }
        public bool Valida { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual TarjetaDebito TarjetaDebito { get; set; }
    }
}
