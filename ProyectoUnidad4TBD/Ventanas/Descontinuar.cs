using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoUnidad4TBD.Modelo;
using ProyectoUnidad4TBD.DAO;

namespace ProyectoUnidad4TBD
{
    public partial class Descontinuar : Form
    {
        public Descontinuar()
        {
            InitializeComponent();
        }
        // Lista de productos a descontinuar
        private List<Product> products = new List<Product>();
        private DAO.DAO dao = new DAO.DAO();
        private void txtCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            // Verificar que se presione enter
            if (e.KeyCode == Keys.Enter)
            {
                // buscar usando el codigo
                string codigo = txtCodigoBarras.Text;
                Product producto = dao.ObtenerProductoPorCodigo(codigo);
                // Si el producto no existe: 
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoBarras.Clear();
                    return;
                }
                // Producto encontrado: 
                else {
                    products.Add(producto);
                    dtvProductos.DataSource = null;
                    dtvProductos.DataSource = products;
                    txtCodigoBarras.Clear();
                }
            
               
            }
        }

        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            // Verificar que haya productos en la lista
            if (products.Count == 0) {
                MessageBox.Show("No hay productos para descontinuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Llamar al metodo descontinuar productos
            bool exito = dao.DescontinuarProductos(products);
            if (exito)
            {
                MessageBox.Show("Productos descontinuados exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                products.Clear();
                dtvProductos.DataSource = null;
            }
            else
            {
                MessageBox.Show("Error al descontinuar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
