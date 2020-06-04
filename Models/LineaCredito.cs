using System;
using System.Collections.Generic;

namespace Cocoppel.Models
{
    /// <summary>
    /// DTO LineaCredito
    /// Indica la cantidad que el usuario puede pedir prestado del banco, para luego pagarla
    /// </summary>
    public partial class LineaCredito
    {
        /// <summary>
        /// IdlineaDeCredito
        /// Identificador único de la linea de crédito
        /// </summary>
        public int IdlineaDeCredito { get; set; }

        /// <summary>
        /// Idusuario
        /// Identificador único del poseedor de la línea de crédito
        /// </summary>
        public int Idusuario { get; set; }

        /// <summary>
        /// Valida
        /// Si la linea ha sido aprobada por el banco emisor
        /// </summary>
        public bool Valida { get; set; }

        /// <summary>        
        /// FechaVencimiento
        /// La fecha en la que la cuenta es cerrada si no se renueva el contrato
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// CantidadMaximaDisponible
        /// El limite de la linea de crédito
        /// </summary>
        public decimal CantidadMaximaDisponible { get; set; }

        /// <summary>
        /// SaldoRestante
        /// El monto que aún está disponible para prestar
        /// </summary>
        public decimal SaldoRestante { get; set; }

        /// <summary>
        /// Foreign Key IdusuarioNavigation
        /// </summary>
        public virtual Usuario IdusuarioNavigation { get; set; }

        /// <summary>
        /// Foreign Key TarjetaCredito
        /// </summary>
        public virtual TarjetaCredito TarjetaCredito { get; set; }
    }
}
