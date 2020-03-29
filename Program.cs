using ApiBanco.Models;
using System;

namespace ApiBanco
{
    class Program
    {
        TarjetaCredito credito = new TarjetaCredito();
        int saldoLimite = 20000;
        bool MaximoCobro(TarjetaCredito credit) //Si el credito es menor al limite de saldo devuelve verdadero si no, devuelve falso
        {
            if(credit.Saldo < Limite)
            {
                return true;
            }

            return false;
        }
        bool validarTarjeta(TarjetaDebito debit)
        {
            if(debit.NumeroDeTarjeta.leght != 16)
            {
                return false;
            }
            if(debit.FechaVencimiento.Date<DateTime.Today.Date)
            {
                return false;
            }
            if (debit.Ccv.leght != 3)
            {
                return false;
            }
            return true;
        }
        bool validarTarjeta(TarjetaCredito credit)
        {
            if (credit.NumeroDeTarjeta.leght != 16)
            {
                return false;
            }
            if (credit.FechaVencimiento.Date < DateTime.Today.Date)
            {
                return false;
            }
            if (credit.Ccv.leght != 3)
            {
                return false;
            }
            return true;
        }


        static void Main(string[] args)
        {
            


        }
    }
}
