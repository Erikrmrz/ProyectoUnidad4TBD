using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        // Lista de compras
        private List<Product> products = new List<Product>();
        private DAO.DAO dao = new DAO.DAO();

        private void txtCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            // Verificar que se presione enter
            if (e.KeyCode == Keys.Enter)
            {
                string codigo = txtCodigoBarras.Text.Trim();
                Product producto = dao.ObtenerProductoPorCodigo(codigo);

                // Si el producto no existe
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoBarras.Clear();
                    return;
                }

                // Producto encontrado: se agrega a la lista de compras
                products.Add(producto);
                dtvProductos.DataSource = null;
                dtvProductos.DataSource = products;
                txtCodigoBarras.Clear();
            }
        }

        // Finalizar compra: suma los precios y genera el txt
        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            // Verificar que haya productos en la lista
            if (products.Count == 0)
            {
                MessageBox.Show("La lista de compras está vacía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sumar todos los precios
            decimal total = products.Sum(p => p.Precio);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo de texto (*.txt)|*.txt";
                sfd.FileName = "ListaDeCompras_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("LISTA DE COMPRAS");
                    sb.AppendLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    sb.AppendLine(new string('-', 50));

                    foreach (Product p in products)
                    {
                        sb.AppendLine(p.Nombre.PadRight(35) + p.Precio.ToString("C2").PadLeft(15));
                    }

                    sb.AppendLine(new string('-', 50));
                    sb.AppendLine("Total de productos: " + products.Count);
                    sb.AppendLine("TOTAL A PAGAR:".PadRight(35) + total.ToString("C2").PadLeft(15));

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Compra finalizada.\nTotal: " + total.ToString("C2") + "\nArchivo guardado correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar para una nueva lista
                    products.Clear();
                    dtvProductos.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}