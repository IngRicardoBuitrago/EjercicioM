
using EjercicioM.Domain;
using EjercicioM.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EjercicioM.Application;

public class ProductoService : IProductoService
{
    private readonly ApplicationDbContext _context;

    public ProductoService(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Obtener todos los productos
    public async Task<List<Producto>> ObtenerTodosAsync()
    {
        return await _context.Productos
                             .AsNoTracking()
                             .ToListAsync();
    }

    // ✅ Obtener producto por Id
    public async Task<Producto?> ObtenerPorIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("El id del producto no es válido");

        return await _context.Productos.FindAsync(id);
    }

    // ✅ Crear producto
    public async Task<Producto> CrearAsync(Producto producto)
    {
        ValidarProducto(producto);

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return producto;
    }

    // ✅ Actualizar producto
    public async Task<bool> ActualizarAsync(int id, Producto producto)
    {
        var existente = await _context.Productos.FindAsync(id);
        if (existente == null)
            return false;

        existente.Nombre = producto.Nombre;
        existente.Descripcion = producto.Descripcion;
        existente.Precio = producto.Precio;

        await _context.SaveChangesAsync();
        return true;
    }

    // ✅ Eliminar producto
    public async Task<bool> EliminarAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("El id del producto no es válido");

        var productoExistente = await _context.Productos.FindAsync(id);
        if (productoExistente == null)
            return false;

        _context.Productos.Remove(productoExistente);
        await _context.SaveChangesAsync();

        return true;
    }

    // ✅ Validaciones de negocio
    private static void ValidarProducto(Producto producto)
    {
        if (string.IsNullOrWhiteSpace(producto.Nombre))
            throw new ArgumentException("El nombre del producto es obligatorio");

        if (string.IsNullOrWhiteSpace(producto.Descripcion))
            throw new ArgumentException("La descripción del producto es obligatoria");

        if (producto.Precio < 0)
            throw new ArgumentException("El precio no puede ser negativo");
    }
}
