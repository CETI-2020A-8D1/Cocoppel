using System;
using System.Collections.Generic;

namespace ApiBanco.Models
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            Transaccion = new HashSet<Transaccion>();
        }

        public byte IdMovimiento { get; set; }
        public string Nombre { get; set; }

        public ICollection<Transaccion> Transaccion { get; set; }
    }
}
