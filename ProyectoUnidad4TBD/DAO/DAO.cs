using MySql.Data.MySqlClient;
using ProyectoUnidad4TBD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4TBD.DAO
{
    internal class DAO
    {
        private Conexion.Conexion conexion = new Conexion.Conexion();
        // Metodo para volver la propiedad de descontinuado de los productos a true
        public bool DescontinuarProductos(List<Product> ListaProductos)
        {
            MySqlConnection cn = conexion.Conectar();
            MySqlTransaction trans = cn.BeginTransaction();
            try
            {
                foreach (Product producto in ListaProductos)
                {
                    string consulta = "update Productos set Descontinuado = 'true' where Codigo = @Codigo";
                    MySqlCommand comando = new MySqlCommand(consulta, cn, trans);
                    comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                    comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error en transaccion: " + ex.Message); 
                trans.Rollback();
                return false;
            }
            finally
            {
                trans.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        // Metodo para mostrar los datos del producot en el grid
        public Product ObtenerProductoPorCodigo(string codigo)
        {
            MySqlConnection cn = null;
            MySqlDataReader reader = null;
            Product producto = null;
            try
            {
                cn = conexion.Conectar();    
                string consulta = "select Codigo, Nombre, Precio, Categoria, Descontinuado, Descripcion, Existencias " +
                                  "from Productos where Codigo = @Codigo";
                
                MySqlCommand comando = new MySqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@Codigo", codigo);

                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    producto = new Product
                    {
                        Codigo = reader["Codigo"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Categoria = reader["Categoria"].ToString(),
                        Descontinuado = reader["Descontinuado"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Existencias = Convert.ToInt32(reader["Existencias"])
                    };
                }
                
                return producto; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar producto por codigo: " + ex.Message);
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (cn != null) cn.Close();
                if (cn != null) cn.Dispose();
            }
        }

    }
}
