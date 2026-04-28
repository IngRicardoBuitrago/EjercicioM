using EjercicioM.Domain;

namespace EjercicioM.Application
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task<Producto> CrearAsync(Producto Producto);
        Task<bool> ActualizarAsync(int id, Producto Producto);
        Task<bool> EliminarAsync(int id);
        
    }
}
