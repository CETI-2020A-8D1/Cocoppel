using System;
using System.Collections.Generic;

namespace ApiCocoppel.Models
{
    public partial class CuentaCheques
    {
        public int IdnumeroDeCuenta { get; set; }
        public int Idusuario { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Usuario IdusuarioNavigation { get; set; }
        public TarjetaDebito TarjetaDebito { get; set; }
    }
}
