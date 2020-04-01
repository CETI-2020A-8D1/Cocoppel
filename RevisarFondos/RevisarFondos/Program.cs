using System;

namespace RevisarFondos
{
    class Program
    {
        bool fondosTarjeta(TarjetaCredito credit, Transaccion transaccion)
        {
            if(credit.Saldo < transaccion.Cantidad)
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
