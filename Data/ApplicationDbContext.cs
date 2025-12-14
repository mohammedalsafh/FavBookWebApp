using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FavBookWebApp.Models;

namespace FavBookWebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<FavBookWebApp.Models.Book> Book { get; set; } = default!;
    }
}
