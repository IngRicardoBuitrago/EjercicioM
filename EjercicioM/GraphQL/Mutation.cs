
using EjercicioM.Infrastructure;
using EjercicioM.Domain;


namespace EjercicioM.GraphQL
{
    public class Mutation
    {


        public async Task<Cliente> CrearCliente(
                    string nombre,
                    string email,
                    string telefono,
                    bool activo,
                    [Service] ApplicationDbContext db)
        {
            var cliente = new Cliente
            {
                Nombre = nombre,
                Email = email,
                Telefono = telefono,
                FechaRegistro= DateTime.Now,
                Activo= activo,
            };

            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente?> ActualizarCliente(
            int ClineteID,
                 string nombre,
                 string email,
                 string telefono,
                 
            [Service] ApplicationDbContext db)
        {
            var cliente = await db.Clientes.FindAsync(ClineteID);

            if (cliente == null) return null;

            cliente.Nombre = nombre;
            cliente.Email = email;
            cliente.Telefono = telefono;


            await db.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> EliminarCliente(
            int id,
            [Service] ApplicationDbContext db)
        {
            var cliente = await db.Clientes.FindAsync(id);

            if (cliente == null) return false;

            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();

            return true;
        }

        // ========================
        // PRODUCTO
        // ========================

        public async Task<Producto> CrearProducto(
            string nombre,
            decimal precio,
            [Service] ApplicationDbContext db)
        {
            var producto = new Producto
            {
                Nombre = nombre,
                Precio = precio
            };

            db.Productos.Add(producto);
            await db.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto?> ActualizarProducto(
            int id,
            string nombre,
            decimal precio,
            [Service] ApplicationDbContext db)
        {
            var producto = await db.Productos.FindAsync(id);

            if (producto == null) return null;

            producto.Nombre = nombre;
            producto.Precio = precio;

            await db.SaveChangesAsync();

            return producto;
        }

        public async Task<bool> EliminarProducto(
            int id,
            [Service] ApplicationDbContext db)
        {
            var producto = await db.Productos.FindAsync(id);

            if (producto == null) return false;

            db.Productos.Remove(producto);
            await db.SaveChangesAsync();

            return true;
        }

    }
}
