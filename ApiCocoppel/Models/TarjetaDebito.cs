﻿using System;
using System.Collections.Generic;

namespace ApiCocoppel.Models
{
    public partial class TarjetaDebito
    {
        public int IdnumeroDeCuenta { get; set; }
        public string EntidadEmisora { get; set; }
        public string Titular { get; set; }
        public string Numero { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Cvv { get; set; }
        public int Nip { get; set; }
        public string MarcaInternacional { get; set; }

        public CuentaCheques IdnumeroDeCuentaNavigation { get; set; }
    }
}