
using BD.Domain.Entidad;
using BD.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BD.Domain
{
    public class PruebaDbContext : DbContext, IPruebaDbContext
    {
        public PruebaDbContext(DbContextOptions<PruebaDbContext> options)
           : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Documentos> Documento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PruebaDbContext).Assembly);
        }
    }
}
