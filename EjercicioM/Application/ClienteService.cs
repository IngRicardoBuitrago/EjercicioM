
using EjercicioM.Domain;
using EjercicioM.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EjercicioM.Application;

public class ClienteService : IClienteService
{
    private readonly ApplicationDbContext _context;

    public ClienteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ObtenerTodosAsync()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }

    public async Task<Cliente?> ObtenerPorIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente> CrearAsync(Cliente cliente)
    {
        cliente.FechaRegistro = DateTime.UtcNow;

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task<bool> ActualizarAsync(int id, Cliente cliente)
    {
        var existente = await _context.Clientes.FindAsync(id);
        if (existente == null) return false;

        existente.Nombre = cliente.Nombre;
        existente.Email = cliente.Email;
        existente.Telefono = cliente.Telefono;
        existente.Activo = cliente.Activo;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
}

