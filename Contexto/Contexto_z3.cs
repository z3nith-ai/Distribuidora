using Microsoft.EntityFrameworkCore;
using Modelos.Entidades;



namespace Contexto
{
    public class Contexto_z3:DbContext
    {
        public Contexto_z3(DbContextOptions conf):base(conf) { }

        public DbSet<clientes> clientes { get; set; }
        public DbSet<sucursales> sucursales { get; set; }
        public DbSet<bodegas> bodegas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<clientes>(cnf => {
                cnf.HasKey(ent => ent.codigo);
            
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
