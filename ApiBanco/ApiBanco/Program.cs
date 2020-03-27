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
        
        
        static void Main(string[] args)
        {
            


        }
    }
}
