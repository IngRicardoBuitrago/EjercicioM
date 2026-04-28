
using EjercicioM.Domain;

namespace EjercicioM.Application;

public interface IClienteService
{
    Task<List<Cliente>> ObtenerTodosAsync();
    Task<Cliente?> ObtenerPorIdAsync(int id);
    Task<Cliente> CrearAsync(Cliente cliente);
    Task<bool> ActualizarAsync(int id, Cliente cliente);
    Task<bool> EliminarAsync(int id);
}
