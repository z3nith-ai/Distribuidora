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
        public DbSet<productos> productos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<clientes>(cnf => {
                cnf.HasKey(ent => ent.codigo);
            
            });

            modelBuilder.Entity<productos>(cnf => {
                cnf.HasOne(ent => ent.Bodega).WithMany(ent2 => ent2.Productos).HasForeignKey(ent => ent.FK_bodegas);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
