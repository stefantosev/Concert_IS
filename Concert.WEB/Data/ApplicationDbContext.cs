using Concert.WEB.Models;
using Concert.WEB.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Concert.WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ConcertAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ConcertLab> Concerts { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<ConcertAppUser> ConcertAppUsers { get; set; }

    }
}
