using EjercicioM.Infrastructure;
using EjercicioM.Domain;
using EjercicioM.Migrations;

namespace EjercicioM.GraphQL
{
    public class Query
    {


        [UseFiltering]
        public IQueryable<Cliente> GetClientes([Service] ApplicationDbContext db)
        {
            return db.Clientes;
        }
        /*
                public List<Cliente> GetClientes([Service] ApplicationDbContext db)
                    {
                        return db.Clientes.ToList();
                    }
        */
        [UseFiltering]
        public IQueryable<Producto> GetProductos([Service] ApplicationDbContext db)
        {
            return db.Productos;
        }
        /*
        public List<Producto> GetProductos([Service] ApplicationDbContext db)
            {
                return db.Productos.ToList();
            }
        */
    }
}
