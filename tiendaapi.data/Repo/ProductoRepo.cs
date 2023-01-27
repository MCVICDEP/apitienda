using apitienda.modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace apitienda.data.Repo
{
    public class ProductoRepo : IProductoRepo
    {
        private readonly MySqlConfiguration _connectionString;
        public ProductoRepo(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbconexion()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> EliminarProducto(Producto producto)
        {
            var db = dbconexion();
            var sql = @"DELETE FROM productos WHERE idproducto = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = producto.IdProducto });
            return result > 0;
        }

        public async Task<Producto> GetDetalles(int id)
        {
            var db = dbconexion();
            var sql = @"SELECT * FROM productos WHERE idproducto = @Id";
            return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { Id = id});
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            var db = dbconexion();
            var sql = @"SELECT * FROM productos WHERE flag = 0 order by idproducto ASC";

            return await db.QueryAsync<Producto>(sql, new { });
        }

        public async Task<bool> InsertarProducto(Producto producto)
        {
            var db = dbconexion();
            var sql = @"INSERT INTO productos (idproducto, cod_producto, nom_producto, desc_producto, precio_producto, cant_producto, img_producto, flag) 
                        VALUES (@idproducto ,@cod_producto, @nom_producto, @desc_producto, @precio_producto, @cant_producto, @img_producto, @flag)";
            var result = await db.ExecuteAsync(sql, new
            {
                producto.IdProducto,
                producto.Cod_Producto,
                producto.Nom_Producto,
                producto.Desc_Producto,
                producto.Precio_Producto,
                producto.Cant_Producto,
                producto.Img_Producto,
                producto.flag
            });
            return result > 0;
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            var db = dbconexion();
            var sql = @"UPDATE productos SET cod_producto = @cod_producto, 
                                            nom_producto = @nom_producto, 
                                            desc_producto = @desc_producto, 
                                            precio_producto = @precio_producto, 
                                            cant_producto = @cant_producto, 
                                            img_producto = @img_producto,
                                            flag = @flag
                                            WHERE idproducto = @idproducto";

            var result = await db.ExecuteAsync(sql, new
            {
                producto.IdProducto,
                producto.Cod_Producto,
                producto.Nom_Producto,
                producto.Desc_Producto,
                producto.Precio_Producto,
                producto.Cant_Producto,
                producto.Img_Producto,
                producto.flag
            });
            return result > 0;
        }

    }
}

