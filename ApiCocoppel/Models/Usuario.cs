using System;
using System.Collections.Generic;

namespace ApiCocoppel.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CuentaCheques = new HashSet<CuentaCheques>();
            LineaCredito = new HashSet<LineaCredito>();
        }

        public int Idusuario { get; set; }
        public DateTime FechaAfiliacion { get; set; }
        public int PuntajeCredito { get; set; }

        public ICollection<CuentaCheques> CuentaCheques { get; set; }
        public ICollection<LineaCredito> LineaCredito { get; set; }
    }
}
