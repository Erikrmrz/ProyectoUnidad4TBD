using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoUnidad4TBD.Conexion
{
    internal class Conexion{
        string cadenaConexion = "Server=localhost; port=3306; uid=root; pwd=root; database=ProyectoU4;";
        public MySqlConnection Conectar() {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                Console.WriteLine("Conexion a la base de datos exitosa");
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos:" + ex.Message);
                return null;
            }
        }
    }
}
