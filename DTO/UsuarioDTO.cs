using System;
using System.Collections.Generic;

namespace Cocoppel.DTO
{
    public partial class UsuarioDTO
    {
        public UsuarioDTO()
        {
            CuentaCheques = new HashSet<CuentaChequesDTO>();
            LineaCredito = new HashSet<LineaCreditoDTO>();
        }

        public int Idusuario { get; set; }
        public DateTime FechaAfiliacion { get; set; }
        public int PuntajeCredito { get; set; }

        public virtual ICollection<CuentaChequesDTO> CuentaCheques { get; set; }
        public virtual ICollection<LineaCreditoDTO> LineaCredito { get; set; }
    }
}
