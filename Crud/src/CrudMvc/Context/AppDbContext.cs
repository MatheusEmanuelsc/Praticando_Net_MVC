using CrudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Contato> contatos { get; set; }
}