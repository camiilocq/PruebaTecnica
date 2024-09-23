using Microsoft.EntityFrameworkCore;

namespace BE_PruebaTecnica.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
