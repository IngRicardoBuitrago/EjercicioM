
using Microsoft.EntityFrameworkCore;
using EjercicioM.Domain;

namespace EjercicioM.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
}
