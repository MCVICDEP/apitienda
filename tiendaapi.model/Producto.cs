using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitienda.modelo
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Cod_Producto { get; set; }
        public string Nom_Producto { get; set; }
        public string Desc_Producto { get; set; }
        public double Precio_Producto { get; set; }
        public int Cant_Producto { get; set; }
        public string Img_Producto { get; set; }
        public int flag { get; set; }

    }
}
