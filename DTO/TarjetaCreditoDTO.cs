using System;
using System.Collections.Generic;

namespace Cocoppel.DTO
{
    public partial class TarjetaCreditoDTO
    {
        public int IdlineaCredito { get; set; }
        public string Numero { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Cvv { get; set; }

        public virtual LineaCreditoDTO IdlineaCreditoNavigation { get; set; }
    }
}
