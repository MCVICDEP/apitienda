using apitienda.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitienda.data.Repo
{
    public interface IProductoRepo
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetDetalles(int id);
        Task<bool> InsertarProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> EliminarProducto(Producto producto);

    }
}
