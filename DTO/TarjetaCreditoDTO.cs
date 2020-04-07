using System;
using System.Collections.Generic;

namespace Cocoppel.DTO
{
    public partial class TarjetaCreditoDTO
    {
        public int IdlineaCredito { get; set; }
        public string EntidadEmisora { get; set; }
        public string Titular { get; set; }
        public string Numero { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Cvv { get; set; }
        public int Nip { get; set; }
        public string MarcaInternacional { get; set; }

        public virtual LineaCreditoDTO IdlineaCreditoNavigation { get; set; }
    }
}
