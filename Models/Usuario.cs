using System;
using System.Collections.Generic;

namespace Cocoppel.Models
{
    /// <summary>
    /// DTO Usuario
    /// Persona física o moral que puede tener varias cuentas de cheques y lineas de crédito
    /// </summary>
    public partial class Usuario
    {
        /// <summary>
        /// Constructor Usuario
        /// Mapeo de sus cuentas de cheques y sus lineas de crédito
        /// </summary>
        public Usuario()
        {
            CuentaCheques = new HashSet<CuentaCheques>();
            LineaCredito = new HashSet<LineaCredito>();
        }

        /// <summary>
        /// Idusuario
        /// El número único que identifica al usuario
        /// </summary>
        public int Idusuario { get; set; }

        /// <summary>
        /// FechaAfiliacion
        /// La fecha en la que se registró en el banco
        /// </summary>
        public DateTime FechaAfiliacion { get; set; }

        /// <summary>
        /// PuntajeCredito
        /// Métrica usada para saber si el banco puede confiar al usuario que saldará deudas a tiempo
        /// </summary>
        public int PuntajeCredito { get; set; }

        /// <summary>
        /// CuentaCheques
        /// Colección de las cuentas de cheque del usuario
        /// </summary>
        public virtual ICollection<CuentaCheques> CuentaCheques { get; set; }

        /// <summary>
        /// LineaCredito
        /// Colección de las lineas de crédito dle usuario
        /// </summary>
        public virtual ICollection<LineaCredito> LineaCredito { get; set; }
    }
}
