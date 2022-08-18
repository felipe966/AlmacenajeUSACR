using AlmacenajeUSACR.Models;
using Microsoft.EntityFrameworkCore;


namespace AlmacenajeUSACR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Codigo_cliente").StartsAt(1000).IncrementsBy(1);
            modelBuilder.Entity<Cliente>().Property(o => o.Codigo_cliente).HasDefaultValueSql("NEXT VALUE FOR Codigo_cliente");
            modelBuilder.HasSequence<int>("Codigo_transportista").StartsAt(1000).IncrementsBy(1);
            modelBuilder.Entity<Transportista>().Property(o => o.Codigo_transportista).HasDefaultValueSql("NEXT VALUE FOR Codigo_transportista");
        }

        public DbSet<Transportista> Transportista { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Articulo_custodia> Articulo_custodia { get; set; }
        public DbSet<Articulo_retirado> Articulo_retirado { get; set; }
    }
}
