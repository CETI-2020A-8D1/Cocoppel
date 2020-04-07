using System;
using System.Collections.Generic;

namespace Cocoppel.DTO
{
    public partial class CuentaChequesDTO
    {
        public int IdnumeroDeCuenta { get; set; }
        public int Idusuario { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual UsuarioDTO IdusuarioNavigation { get; set; }
        public virtual TarjetaDebitoDTO TarjetaDebito { get; set; }
    }
}
