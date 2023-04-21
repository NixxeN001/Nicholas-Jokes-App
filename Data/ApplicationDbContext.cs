using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nicholas_Jokes_App.Models;

namespace Nicholas_Jokes_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Nicholas_Jokes_App.Models.JokesContain>? JokesContain { get; set; }
    }
}