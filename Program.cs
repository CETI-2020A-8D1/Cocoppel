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
            if(credit.Saldo < saldoLimite)
            {
                return true;
            }

            return false;
        }
        bool fondosTarjeta(TarjetaCredito credit, Transaccion transaccion)
        {
            if(credit.Saldo < transaccion.Cantidad)
            {
                return false;
            }
            return true;
        }
        bool validarTarjeta(TarjetaDebito debit)
        {
            if(debit.NumeroDeTarjeta > 999999999999999 && debit.NumeroDeTarjeta < 10000000000000000)
            {
                return false;
            }
            if(debit.FechaVencimiento.Date<DateTime.Today.Date)
            {
                return false;
            }
            if (debit.Ccv > 99 && debit.Ccv < 1000)
            {
                return false;
            }
            return true;
        }
        bool validarTarjeta(TarjetaCredito credit)
        {
            if (credit.NumeroDeTarjeta > 999999999999999 && credit.NumeroDeTarjeta < 10000000000000000)
            {
                return false;
            }
            if (credit.FechaVencimiento.Date < DateTime.Today.Date)
            {
                return false;
            }
            if (credit.Ccv > 99 && credit.Ccv < 1000)
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
