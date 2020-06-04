using System;
using System.Collections.Generic;

namespace Cocoppel.Models
{
    /// <summary>
    /// DTO TarjetaDébito
    /// Cada tarjeta de débito está ligada a una cuenta de cheques, la cual está ligada a un usuario
    /// </summary>
    public partial class TarjetaDebito
    {
        /// <summary>
        /// IdnumeroDeCuenta
        /// Identificador único de la cuenta de cheques
        /// </summary>
        public int IdnumeroDeCuenta { get; set; }

        /// <summary>
        /// Valida
        /// Si la tarjeta de débito es válida
        /// </summary>
        public bool Valida { get; set; }

        /// <summary>
        /// EntidadEmisora
        /// El banco que expide la tarjeta (Cocoppel)
        /// </summary>
        public string EntidadEmisora { get; set; }

        /// <summary>
        /// Titular
        /// La persona que posee la tarjeta
        /// </summary>
        public string Titular { get; set; }

        /// <summary>
        /// Numero
        /// Numero de la tarjeta
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// FechaCaducidad
        /// La fecha en la que la tarjeta no es válida
        /// </summary>
        public DateTime FechaCaducidad { get; set; }

        /// <summary>
        /// Cvv
        /// Código de seguridad de 3 dígitos
        /// </summary>
        public int Cvv { get; set; }

        /// <summary>
        /// Nip
        /// Código de seguridad opcional de 4 dígitos
        /// </summary>
        public int Nip { get; set; }

        /// <summary>
        /// MarcaInternacional
        /// La marca internacional de la tarjeta (Visa, MasterCard, etc.)
        /// </summary>
        public string MarcaInternacional { get; set; }

        /// <summary>
        /// Foreign key IdnumeroDeCuentaNavigation
        /// </summary>
        public virtual CuentaCheques IdnumeroDeCuentaNavigation { get; set; }
    }
}
