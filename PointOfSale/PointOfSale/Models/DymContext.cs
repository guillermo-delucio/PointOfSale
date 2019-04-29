using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PointOfSale.Models
{
    public partial class DymContext : DbContext
    {
        public DymContext()
        {
        }

        public DymContext(DbContextOptions<DymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<ClaveSat> ClaveSat { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Consecutivo> Consecutivo { get; set; }
        public virtual DbSet<Cp> Cp { get; set; }
        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Impuesto> Impuesto { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Presentacion> Presentacion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoAlmacen> ProductoAlmacen { get; set; }
        public virtual DbSet<ProductoImpuesto> ProductoImpuesto { get; set; }
        public virtual DbSet<ProductoSustancia> ProductoSustancia { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermiso> RolePermiso { get; set; }
        public virtual DbSet<Sustancia> Sustancia { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRole> UsuarioRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Dym;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasIndex(e => e.AlmacenId)
                    .HasName("IX_Almacenes")
                    .IsUnique();

                entity.Property(e => e.AlmacenId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasIndex(e => e.CategoriaId)
                    .HasName("IX_Categorias")
                    .IsUnique();

                entity.Property(e => e.CategoriaId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<ClaveSat>(entity =>
            {
                entity.Property(e => e.ClaveSatId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Consecutivo>(entity =>
            {
                entity.Property(e => e.ConsecutivoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Consecutivo1).HasColumnName("Consecutivo");
            });

            modelBuilder.Entity<Cp>(entity =>
            {
                entity.ToTable("CP");

                entity.Property(e => e.CpId).ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasMaxLength(10);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Cp)
                    .HasForeignKey(d => d.MunicipioId)
                    .HasConstraintName("FK_CP_Municipio");
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.Property(e => e.EstacionId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoId).ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("FK_Estado_Pais");
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.HasIndex(e => e.ImpuestoId)
                    .HasName("IX_Impuestos")
                    .IsUnique();

                entity.Property(e => e.ImpuestoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Laboratorio>(entity =>
            {
                entity.HasIndex(e => e.LaboratorioId)
                    .HasName("IX_Laboratorios")
                    .IsUnique();

                entity.Property(e => e.LaboratorioId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.Property(e => e.LoteId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Caducidad).HasColumnType("date");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.MucipioId);

                entity.Property(e => e.MucipioId).ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre).HasMaxLength(120);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_Municipio_Estado");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.PaisId).ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(120);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.PermisoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Presentacion>(entity =>
            {
                entity.HasIndex(e => e.PresentacionId)
                    .HasName("IX_Presentaciones")
                    .IsUnique();

                entity.Property(e => e.PresentacionId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.Descripcion)
                    .HasName("IX_Productos");

                entity.Property(e => e.ProductoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoriaId).HasMaxLength(50);

                entity.Property(e => e.ClaveCfdiId).HasMaxLength(50);

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CratedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CratedBy).HasMaxLength(50);

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.Property(e => e.LaboratorioId).HasMaxLength(50);

                entity.Property(e => e.LoteId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio1).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio2).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio3).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio4).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrecioCaja).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PresentacionId).HasMaxLength(50);

                entity.Property(e => e.RutaImg)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadCfdi).HasMaxLength(50);

                entity.Property(e => e.UnidadMedidaId).HasMaxLength(50);

                entity.Property(e => e.Unidades).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Utilidad1).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad2).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad3).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad4).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<ProductoAlmacen>(entity =>
            {
                entity.HasKey(e => new { e.ProductoId, e.AlmacenId });

                entity.Property(e => e.ProductoId).HasMaxLength(50);

                entity.Property(e => e.AlmacenId).HasMaxLength(50);

                entity.HasOne(d => d.Almacen)
                    .WithMany(p => p.ProductoAlmacen)
                    .HasForeignKey(d => d.AlmacenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoAlmacen_Almacen");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoAlmacen)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoAlmacen_Producto");
            });

            modelBuilder.Entity<ProductoImpuesto>(entity =>
            {
                entity.HasKey(e => new { e.ProductoId, e.ImpuestoId });

                entity.Property(e => e.ProductoId).HasMaxLength(50);

                entity.Property(e => e.ImpuestoId).HasMaxLength(50);

                entity.HasOne(d => d.Impuesto)
                    .WithMany(p => p.ProductoImpuesto)
                    .HasForeignKey(d => d.ImpuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoImpuesto_Impuesto");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoImpuesto)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoImpuesto_Producto");
            });

            modelBuilder.Entity<ProductoSustancia>(entity =>
            {
                entity.HasKey(e => new { e.ProductoId, e.SustanciaId })
                    .HasName("PK_SustanciaProducto");

                entity.Property(e => e.ProductoId).HasMaxLength(50);

                entity.Property(e => e.SustanciaId).HasMaxLength(50);

                entity.Property(e => e.Contenido).HasMaxLength(50);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoSustancia)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SustanciaProducto_Producto");

                entity.HasOne(d => d.Sustancia)
                    .WithMany(p => p.ProductoSustancia)
                    .HasForeignKey(d => d.SustanciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SustanciaProducto_Sustancia");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(e => e.ProveedorId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Celular).HasMaxLength(100);

                entity.Property(e => e.Contancto).HasMaxLength(100);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(10);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Estado).HasMaxLength(100);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Localidad).HasMaxLength(100);

                entity.Property(e => e.Municipio).HasMaxLength(100);

                entity.Property(e => e.Negocio).HasMaxLength(100);

                entity.Property(e => e.Pais).HasMaxLength(100);

                entity.Property(e => e.RazonSocial).HasMaxLength(100);

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasMaxLength(13);

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Telefono).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<RolePermiso>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.Permisoid });

                entity.Property(e => e.RoleId).HasMaxLength(50);

                entity.Property(e => e.Permisoid).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.RolePermiso)
                    .HasForeignKey(d => d.Permisoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermiso_Permiso");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermiso)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermiso_Role");
            });

            modelBuilder.Entity<Sustancia>(entity =>
            {
                entity.HasIndex(e => e.SustanciaId)
                    .HasName("IX_Sustancias")
                    .IsUnique();

                entity.Property(e => e.SustanciaId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.Property(e => e.UnidadMedidaId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.UnidadSat).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<UsuarioRole>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.RoleId });

                entity.Property(e => e.UsuarioId).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsuarioRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRole_Role");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioRole)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRole_Usuario");
            });
        }
    }
}
