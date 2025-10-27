using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4TBD.Modelo
{
    internal class Product{
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string Descontinuado { get; set; }
        public string Descripcion { get; set; }
        public int Existencias { get; set; }
    }
}
