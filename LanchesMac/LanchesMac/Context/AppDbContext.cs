using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}