using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public partial class tiendaContext : DbContext
    {
        public tiendaContext()
        {
        }
        public tiendaContext(DbContextOptions<tiendaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
            });
       
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Categoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_categoria");
            });

            OnModelCreatingPartial(modelBuilder);
}
partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
