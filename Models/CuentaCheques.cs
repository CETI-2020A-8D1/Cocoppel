using System;
using System.Collections.Generic;

namespace Cocoppel.Models
{
    /// <summary>
    /// DTO CuentaCheques
    /// Poseídas por usuarios, son cuentas a las que se puede retirar y depositar dinero
    /// </summary>
    public partial class CuentaCheques
    {
        /// <summary>
        /// IdnumeroDeCuenta
        /// Número único que identifica la cuenta
        /// </summary>
        public int IdnumeroDeCuenta { get; set; }

        /// <summary>
        /// Idusuario
        /// Identifica a qué usuario le pertenece esta cuenta
        /// </summary>
        public int Idusuario { get; set; }

        /// <summary>
        /// Valida
        /// Si la cuenta ha sido activada por el banco emisor
        /// </summary>
        public bool Valida { get; set; }

        /// <summary>
        /// Balance
        /// El monto de dinero que tiene la cuenta
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// FechaVencimiento
        /// La fecha en la que la cuenta es cerrada si no se renueva el contrato
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Foreign Key IdUsuarioNavigation
        /// </summary>
        public virtual Usuario IdusuarioNavigation { get; set; }


        /// <summary>
        /// Foreign Key TarjetaDebito
        /// </summary>
        public virtual TarjetaDebito TarjetaDebito { get; set; }
    }
}
