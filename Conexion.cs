using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
namespace ApiBanco
{
    class Conexion
    {
        string cadenaConexion = "Data Source=ANGEL;Initial Catalog=Cocopel;Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();
        public SqlDataReader dr;
        public Conexion()
        {
            conectarbd.ConnectionString = cadenaConexion;
        }
        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch (Exception e )
            {
                Console.WriteLine("Error al abrir la BD: " + e);

            }
 
        }
        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}
