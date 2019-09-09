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

        public virtual DbSet<CAduana> CAduana { get; set; }
        public virtual DbSet<CCaducidadfolios> CCaducidadfolios { get; set; }
        public virtual DbSet<CClaveProdServ> CClaveProdServ { get; set; }
        public virtual DbSet<CClaveunidad> CClaveunidad { get; set; }
        public virtual DbSet<CFormapago> CFormapago { get; set; }
        public virtual DbSet<CImpuesto> CImpuesto { get; set; }
        public virtual DbSet<CMetodopago> CMetodopago { get; set; }
        public virtual DbSet<CMoneda> CMoneda { get; set; }
        public virtual DbSet<CNumpedimentoaduana> CNumpedimentoaduana { get; set; }
        public virtual DbSet<CPatenteaduanal> CPatenteaduanal { get; set; }
        public virtual DbSet<CRegimenfiscal> CRegimenfiscal { get; set; }
        public virtual DbSet<CTasaocuota> CTasaocuota { get; set; }
        public virtual DbSet<CTipodecomprobante> CTipodecomprobante { get; set; }
        public virtual DbSet<CTipofactor> CTipofactor { get; set; }
        public virtual DbSet<CTiporelacion> CTiporelacion { get; set; }
        public virtual DbSet<CUsocfdi> CUsocfdi { get; set; }
        public virtual DbSet<CambiosPrecio> CambiosPrecio { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Comprap> Comprap { get; set; }
        public virtual DbSet<ConceptoEgreso> ConceptoEgreso { get; set; }
        public virtual DbSet<ConceptoIngreso> ConceptoIngreso { get; set; }
        public virtual DbSet<ConceptoMovInv> ConceptoMovInv { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<Consecutivo> Consecutivo { get; set; }
        public virtual DbSet<Corte> Corte { get; set; }
        public virtual DbSet<Cp> Cp { get; set; }
        public virtual DbSet<Cxc> Cxc { get; set; }
        public virtual DbSet<Cxcp> Cxcp { get; set; }
        public virtual DbSet<Cxp> Cxp { get; set; }
        public virtual DbSet<Cxpp> Cxpp { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoDoc> EstadoDoc { get; set; }
        public virtual DbSet<Flujo> Flujo { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Impuesto> Impuesto { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<MovInv> MovInv { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Presentacion> Presentacion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoSustancia> ProductoSustancia { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Punto> Punto { get; set; }
        public virtual DbSet<PuntoConfig> PuntoConfig { get; set; }
        public virtual DbSet<Query> Query { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermiso> RolePermiso { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Sustancia> Sustancia { get; set; }
        public virtual DbSet<TipoDoc> TipoDoc { get; set; }
        public virtual DbSet<Traspaso> Traspaso { get; set; }
        public virtual DbSet<Traspasop> Traspasop { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRole> UsuarioRole { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<Ventap> Ventap { get; set; }

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

            modelBuilder.Entity<CAduana>(entity =>
            {
                entity.ToTable("C_Aduana");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CAduana1)
                    .HasColumnName("c_Aduana")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);
            });

            modelBuilder.Entity<CCaducidadfolios>(entity =>
            {
                entity.ToTable("C_Caducidadfolios");

                entity.Property(e => e.DiasCaducidad).HasColumnName("diasCaducidad");

                entity.Property(e => e.PorcentajeCaducidad).HasColumnName("porcentajeCaducidad");
            });

            modelBuilder.Entity<CClaveProdServ>(entity =>
            {
                entity.HasKey(e => e.ClaveProdServId)
                    .HasName("PK_ClaveSat");

                entity.ToTable("C_ClaveProdServ");

                entity.Property(e => e.ClaveProdServId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<CClaveunidad>(entity =>
            {
                entity.HasKey(e => e.ClaveUnidadId);

                entity.ToTable("C_Claveunidad");

                entity.Property(e => e.ClaveUnidadId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CFormapago>(entity =>
            {
                entity.HasKey(e => e.FormaPagoId)
                    .HasName("PK_C_Formapago_1");

                entity.ToTable("C_Formapago");

                entity.Property(e => e.FormaPagoId)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bancarizado).HasMaxLength(255);

                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<CImpuesto>(entity =>
            {
                entity.HasKey(e => e.ImpuestoId);

                entity.ToTable("C_Impuesto");

                entity.Property(e => e.ImpuestoId)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Retencion).HasMaxLength(255);

                entity.Property(e => e.Traslado).HasMaxLength(255);
            });

            modelBuilder.Entity<CMetodopago>(entity =>
            {
                entity.HasKey(e => e.MetodoPagoId)
                    .HasName("PK_C_Metodopago_1");

                entity.ToTable("C_Metodopago");

                entity.Property(e => e.MetodoPagoId)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<CMoneda>(entity =>
            {
                entity.HasKey(e => e.MonedaId);

                entity.ToTable("C_Moneda");

                entity.Property(e => e.MonedaId)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<CNumpedimentoaduana>(entity =>
            {
                entity.HasKey(e => e.CAduana);

                entity.ToTable("C_Numpedimentoaduana");

                entity.Property(e => e.CAduana)
                    .HasColumnName("c_Aduana")
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasMaxLength(255);

                entity.Property(e => e.Ejercicio).HasMaxLength(255);

                entity.Property(e => e.FechaFinDeVigencia)
                    .HasColumnName("Fecha fin de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaInicioDeVigencia)
                    .HasColumnName("Fecha inicio de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.Patente).HasMaxLength(255);
            });

            modelBuilder.Entity<CPatenteaduanal>(entity =>
            {
                entity.ToTable("C_Patenteaduanal");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CPatenteAduanal1)
                    .HasColumnName("C_PatenteAduanal")
                    .HasMaxLength(255);

                entity.Property(e => e.FinDeVigencia)
                    .HasColumnName("Fin de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.InicioDeVigencia)
                    .HasColumnName("Inicio de vigencia")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CRegimenfiscal>(entity =>
            {
                entity.HasKey(e => e.RegimenFiscalId)
                    .HasName("PK_C_Regimenfiscal_1");

                entity.ToTable("C_Regimenfiscal");

                entity.Property(e => e.RegimenFiscalId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Física).HasMaxLength(255);

                entity.Property(e => e.Moral).HasMaxLength(255);
            });

            modelBuilder.Entity<CTasaocuota>(entity =>
            {
                entity.ToTable("C_Tasaocuota");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Factor).HasMaxLength(255);

                entity.Property(e => e.FechaFinDeVigencia)
                    .HasColumnName("Fecha fin de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaInicioDeVigencia)
                    .HasColumnName("Fecha inicio de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.Impuesto).HasMaxLength(255);

                entity.Property(e => e.RangoOfijo)
                    .HasColumnName("RangoOFijo")
                    .HasMaxLength(255);

                entity.Property(e => e.Retención).HasMaxLength(255);

                entity.Property(e => e.Traslado).HasMaxLength(255);

                entity.Property(e => e.ValorMáximo)
                    .HasColumnName("Valor máximo")
                    .HasMaxLength(255);

                entity.Property(e => e.ValorMínimo)
                    .HasColumnName("Valor mínimo")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CTipodecomprobante>(entity =>
            {
                entity.HasKey(e => e.TipoComprobanteId)
                    .HasName("PK_C_Tipodecomprobante_1");

                entity.ToTable("C_Tipodecomprobante");

                entity.Property(e => e.TipoComprobanteId)
                    .HasMaxLength(1)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<CTipofactor>(entity =>
            {
                entity.HasKey(e => e.TipoFactorId)
                    .HasName("PK_C_Tipofactor_1");

                entity.ToTable("C_Tipofactor");

                entity.Property(e => e.TipoFactorId)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CTiporelacion>(entity =>
            {
                entity.HasKey(e => e.TipoRelacionId)
                    .HasName("PK_C_Tiporelacion_1");

                entity.ToTable("C_Tiporelacion");

                entity.Property(e => e.TipoRelacionId)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripción).HasMaxLength(255);
            });

            modelBuilder.Entity<CUsocfdi>(entity =>
            {
                entity.HasKey(e => e.UsoCfdiid)
                    .HasName("PK_C_Usocfdi_1");

                entity.ToTable("C_Usocfdi");

                entity.Property(e => e.UsoCfdiid)
                    .HasColumnName("UsoCFDIId")
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Fisica).HasMaxLength(255);

                entity.Property(e => e.Moral).HasMaxLength(255);
            });

            modelBuilder.Entity<CambiosPrecio>(entity =>
            {
                entity.HasKey(e => e.CambioPrecioId);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Precio1Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio1Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio2Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio2Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio3Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio3Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio4Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Precio4Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrecioCompraNuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrecioCompraViejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Utilidad1Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad1Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad2Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad2Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad3Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad3Viejo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad4Nuevo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Utilidad4Viejo).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CambiosPrecio)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CambiosPrecio_Usuario");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.CambiosPrecio)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CambiosPrecio_Producto");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.CategoriaId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(50);

                entity.Property(e => e.DineroElectronico).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EsCxc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FormaPagoId)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Localidad).HasMaxLength(50);

                entity.Property(e => e.MetodoPagoId)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Municipio).HasMaxLength(50);

                entity.Property(e => e.Pais).HasMaxLength(50);

                entity.Property(e => e.PrecioDefault).HasDefaultValueSql("((1))");

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasMaxLength(50);

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.UsoCfdiid)
                    .IsRequired()
                    .HasColumnName("UsoCFDIId")
                    .HasMaxLength(5);

                entity.HasOne(d => d.FormaPago)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.FormaPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_C_Formapago");

                entity.HasOne(d => d.FormaPagoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.FormaPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_FormaPago");

                entity.HasOne(d => d.MetodoPago)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_C_Metodopago");

                entity.HasOne(d => d.UsoCfdi)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.UsoCfdiid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_C_Usocfdi");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.AlmacenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.Datos).IsRequired();

                entity.Property(e => e.EsCxp).HasColumnName("EsCXP");

                entity.Property(e => e.EstacionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.EstadoDocId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'PEN')");

                entity.Property(e => e.FacturaProveedor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaDocumento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProveedorId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProveedorName)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.Property(e => e.TipoDocId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'COM')");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Usuario");

                entity.HasOne(d => d.Cxp)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.CxpId)
                    .HasConstraintName("FK_Compra_CXP");

                entity.HasOne(d => d.Estacion)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.EstacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Estacion");

                entity.HasOne(d => d.EstadoDoc)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.EstadoDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_EstadoDoc");

                entity.HasOne(d => d.TipoDoc)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.TipoDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_TipoDoc");
            });

            modelBuilder.Entity<Comprap>(entity =>
            {
                entity.Property(e => e.Caducidad)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImporteImpuesto1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImporteImpuesto2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Impuesto1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Impuesto2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LaboratorioId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.LaboratorioName)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.Property(e => e.Lote)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.NImpuestos).HasColumnName("nImpuestos");

                entity.Property(e => e.PrecioCaja).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stock).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.Comprap)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprap_Compra");
            });

            modelBuilder.Entity<ConceptoEgreso>(entity =>
            {
                entity.Property(e => e.ConceptoEgresoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<ConceptoIngreso>(entity =>
            {
                entity.Property(e => e.ConceptoIngresoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<ConceptoMovInv>(entity =>
            {
                entity.Property(e => e.ConceptoMovInvId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.Property(e => e.RutaCadenaOriginal).HasMaxLength(250);

                entity.Property(e => e.RutaCer).HasMaxLength(250);

                entity.Property(e => e.RutaComprobantes).HasMaxLength(250);

                entity.Property(e => e.RutaCortes).HasMaxLength(250);

                entity.Property(e => e.RutaFormatoCorte).HasMaxLength(250);

                entity.Property(e => e.RutaFormatoFactura).HasMaxLength(250);

                entity.Property(e => e.RutaFormatoTicket).HasMaxLength(250);

                entity.Property(e => e.RutaKey).HasMaxLength(250);

                entity.Property(e => e.RutaPlantillas).HasMaxLength(250);
            });

            modelBuilder.Entity<Consecutivo>(entity =>
            {
                entity.Property(e => e.ConsecutivoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Corte>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EstacionId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RutaArchivo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Corte)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Corte_Usuario");

                entity.HasOne(d => d.Estacion)
                    .WithMany(p => p.Corte)
                    .HasForeignKey(d => d.EstacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Corte_Estacion");
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

            modelBuilder.Entity<Cxc>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EstadoDocId)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'PEN')");

                entity.Property(e => e.FechaDocumento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MonedaId)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("(N'MXN')");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SerieDocId).HasMaxLength(3);

                entity.Property(e => e.TipoDocId).HasMaxLength(3);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Cxc)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Cxc_Usuario");
            });

            modelBuilder.Entity<Cxcp>(entity =>
            {
                entity.Property(e => e.CargoAbono).HasMaxLength(1);

                entity.Property(e => e.ConceptoPago).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Cxc)
                    .WithMany(p => p.Cxcp)
                    .HasForeignKey(d => d.CxcId)
                    .HasConstraintName("FK_Cxcp_Cxc");
            });

            modelBuilder.Entity<Cxp>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EstadoDocId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'PEN')");

                entity.Property(e => e.FacturaProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'NO ESPECIFICADO')");

                entity.Property(e => e.FechaDocumento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProveedorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TipoDocId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'COM')");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Cxp)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cxp_Usuario");

                entity.HasOne(d => d.EstadoDoc)
                    .WithMany(p => p.Cxp)
                    .HasForeignKey(d => d.EstadoDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CXP_EstadoDoc");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Cxp)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CXP_Proveedor");

                entity.HasOne(d => d.TipoDoc)
                    .WithMany(p => p.Cxp)
                    .HasForeignKey(d => d.TipoDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CXP_TipoDoc");
            });

            modelBuilder.Entity<Cxpp>(entity =>
            {
                entity.Property(e => e.CargoAbono)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProveedorId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cxp)
                    .WithMany(p => p.Cxpp)
                    .HasForeignKey(d => d.CxpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cxpp_Cxp");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Cxpp)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PCXP_Proveedor");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.ClavePrivada).HasMaxLength(50);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(50);

                entity.Property(e => e.DirectorioComprobantes).HasMaxLength(250);

                entity.Property(e => e.DirectorioCortes).HasMaxLength(250);

                entity.Property(e => e.DirectorioOpenSslBin).HasMaxLength(250);

                entity.Property(e => e.DirectorioReportes).HasMaxLength(250);

                entity.Property(e => e.DirectorioTickets).HasMaxLength(250);

                entity.Property(e => e.DirectorioTrabajo).HasMaxLength(250);

                entity.Property(e => e.DirectorioTraspasos).HasMaxLength(250);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.PassWstimbrado)
                    .HasColumnName("PassWSTimbrado")
                    .HasMaxLength(50);

                entity.Property(e => e.RegimenFiscal).HasMaxLength(50);

                entity.Property(e => e.RegimenFiscalId).HasMaxLength(50);

                entity.Property(e => e.Rfc).HasMaxLength(13);

                entity.Property(e => e.RutaArchivoPfx)
                    .HasColumnName("RutaArchivoPFX")
                    .HasMaxLength(50);

                entity.Property(e => e.RutaCadenaOriginal).HasMaxLength(250);

                entity.Property(e => e.RutaCer).HasMaxLength(250);

                entity.Property(e => e.RutaFormatoCorte).HasMaxLength(250);

                entity.Property(e => e.RutaFormatoFactura).HasMaxLength(250);

                entity.Property(e => e.RutaFormatoTicket).HasMaxLength(250);

                entity.Property(e => e.RutaKey).HasMaxLength(250);

                entity.Property(e => e.RutaPlantillaDetalleTraspaso).HasMaxLength(250);

                entity.Property(e => e.RutaPlantillaTraspaso).HasMaxLength(250);

                entity.Property(e => e.UserWstimbrado)
                    .HasColumnName("UserWSTimbrado")
                    .HasMaxLength(50);

                entity.HasOne(d => d.RegimenFiscalNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.RegimenFiscalId)
                    .HasConstraintName("FK_Empresa_C_Regimenfiscal");
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.Property(e => e.EstacionId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultAlmacenId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ImpresoraF)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.ImpresoraNc)
                    .IsRequired()
                    .HasColumnName("ImpresoraNC")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.ImpresoraT)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SIN NOMBRE')");

                entity.Property(e => e.SolicitarFmpago).HasColumnName("SolicitarFMPago");

                entity.Property(e => e.SumarUnidadesPdv).HasColumnName("SumarUnidadesPDV");

                entity.Property(e => e.TantosF).HasDefaultValueSql("((1))");

                entity.Property(e => e.TantosNc)
                    .HasColumnName("TantosNC")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TantosT).HasDefaultValueSql("((1))");
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

            modelBuilder.Entity<EstadoDoc>(entity =>
            {
                entity.Property(e => e.EstadoDocId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Flujo>(entity =>
            {
                entity.Property(e => e.ConceptoEgresoId).HasMaxLength(50);

                entity.Property(e => e.ConceptoImporteId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ConceptoIngresoId).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EntradaSalida)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.EstacionId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RefBancaria).HasMaxLength(50);

                entity.HasOne(d => d.ConceptoEgreso)
                    .WithMany(p => p.Flujo)
                    .HasForeignKey(d => d.ConceptoEgresoId)
                    .HasConstraintName("FK_Flujo_ConceptoEgreso");

                entity.HasOne(d => d.ConceptoIngreso)
                    .WithMany(p => p.Flujo)
                    .HasForeignKey(d => d.ConceptoIngresoId)
                    .HasConstraintName("FK_Flujo_ConceptoIngreso");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.Property(e => e.FormaPagoId)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.Property(e => e.ImpuestoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CImpuesto)
                    .IsRequired()
                    .HasColumnName("C_Impuesto")
                    .HasMaxLength(5);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Tasa).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CImpuestoNavigation)
                    .WithMany(p => p.Impuesto)
                    .HasForeignKey(d => d.CImpuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Impuesto_C_Impuesto_ImpuestoId_fk");
            });

            modelBuilder.Entity<Laboratorio>(entity =>
            {
                entity.Property(e => e.LaboratorioId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.Property(e => e.Caducidad).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NoLote)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StockInicial).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.StockRestante).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lote_Producto1");
            });

            modelBuilder.Entity<MovInv>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.ConceptoMovsInvId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EntradaSalida)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ConceptoMovsInv)
                    .WithMany(p => p.MovInv)
                    .HasForeignKey(d => d.ConceptoMovsInvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovsInv_ConceptoMovInv");
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
                entity.Property(e => e.PresentacionId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AlmacenId).HasMaxLength(50);

                entity.Property(e => e.CategoriaId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.ClaveProdServId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'01010101')");

                entity.Property(e => e.ClaveUnidadId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'H87')");

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CratedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CratedBy).HasMaxLength(50);

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.Property(e => e.Impuesto1Id)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.Impuesto2Id)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.Impuesto3Id)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.LaboratorioId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.LoteId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ocupado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Precio1)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio2)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio3)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio4)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioCaja)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioCompra)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PresentacionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.RutaImg)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.UnidadMedidaId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.Unidades).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Utilidad1)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Utilidad2)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Utilidad3)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Utilidad4)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Categoria");

                entity.HasOne(d => d.Impuesto1)
                    .WithMany(p => p.ProductoImpuesto1)
                    .HasForeignKey(d => d.Impuesto1Id)
                    .HasConstraintName("FK_Producto_Impuesto");

                entity.HasOne(d => d.Impuesto2)
                    .WithMany(p => p.ProductoImpuesto2)
                    .HasForeignKey(d => d.Impuesto2Id)
                    .HasConstraintName("FK_Producto_Impuesto1");

                entity.HasOne(d => d.Impuesto3)
                    .WithMany(p => p.ProductoImpuesto3)
                    .HasForeignKey(d => d.Impuesto3Id)
                    .HasConstraintName("FK_Producto_Impuesto2");

                entity.HasOne(d => d.Laboratorio)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.LaboratorioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Laboratorio");

                entity.HasOne(d => d.Presentacion)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.PresentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Presentacion");

                entity.HasOne(d => d.UnidadMedida)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.UnidadMedidaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_UnidadMedida");
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

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(10);

                entity.Property(e => e.Estado).HasMaxLength(100);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Localidad).HasMaxLength(100);

                entity.Property(e => e.Municipio).HasMaxLength(100);

                entity.Property(e => e.Pais).HasMaxLength(100);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("RFC")
                    .HasMaxLength(13);

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Telefono).HasMaxLength(100);
            });

            modelBuilder.Entity<Punto>(entity =>
            {
                entity.Property(e => e.Base).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ClienteId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ClienteName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ResetedBy).HasMaxLength(50);

                entity.Property(e => e.Tasa).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Punto)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Punto_Cliente");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.Punto)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Punto_Venta");
            });

            modelBuilder.Entity<PuntoConfig>(entity =>
            {
                entity.HasKey(e => e.PuntosConfigId)
                    .HasName("PK_Monedero");

                entity.Property(e => e.TasaDescuento).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.Property(e => e.QueryId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Sql).HasColumnName("SQL");
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

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Sustancia>(entity =>
            {
                entity.Property(e => e.SustanciaId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoDoc>(entity =>
            {
                entity.Property(e => e.TipoDocId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Traspaso>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Documento).HasMaxLength(50);

                entity.Property(e => e.EstadoDocId).HasMaxLength(5);

                entity.Property(e => e.FechaDocumento).HasColumnType("datetime");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SentBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SerieDestino)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.SerieOrigen)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SucursalDestinoName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SucursalOrigenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoDocId).HasMaxLength(5);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.SucursalDestino)
                    .WithMany(p => p.TraspasoSucursalDestino)
                    .HasForeignKey(d => d.SucursalDestinoId)
                    .HasConstraintName("FK_Traspaso_Sucursal1");

                entity.HasOne(d => d.SucursalOrigen)
                    .WithMany(p => p.TraspasoSucursalOrigen)
                    .HasForeignKey(d => d.SucursalOrigenId)
                    .HasConstraintName("FK_Traspaso_Sucursal");
            });

            modelBuilder.Entity<Traspasop>(entity =>
            {
                entity.Property(e => e.Caducidad).HasColumnType("datetime");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.ImporteImpuesto1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImporteImpuesto2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Impuesto1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Impuesto2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImpuestoId1).HasMaxLength(50);

                entity.Property(e => e.ImpuestoId2).HasMaxLength(50);

                entity.Property(e => e.NoLote).HasMaxLength(50);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stock).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Traspaso)
                    .WithMany(p => p.Traspasop)
                    .HasForeignKey(d => d.TraspasoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Traspasop_Traspaso");
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

                entity.Property(e => e.EstacionId).HasMaxLength(50);

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

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.Anulada).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cambio).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ClienteId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.ConceptoPago1)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'EFECTIVO')");

                entity.Property(e => e.ConceptoPago2).HasMaxLength(50);

                entity.Property(e => e.ConceptoPago3).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DatosCliente).HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.DescXpuntos).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EsCxc).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstacionId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'ESTACION01')");

                entity.Property(e => e.EstadoDocId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'PEN')");

                entity.Property(e => e.EstatusSat)
                    .HasColumnName("EstatusSAT")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaDoc)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FormaPago1)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("(N'01')");

                entity.Property(e => e.FormaPago2).HasMaxLength(2);

                entity.Property(e => e.FormaPago3).HasMaxLength(2);

                entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MetodoPago).HasMaxLength(50);

                entity.Property(e => e.MonedaId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'MXN')");

                entity.Property(e => e.NoCertificado).HasMaxLength(40);

                entity.Property(e => e.NoPrecio).HasDefaultValueSql("((1))");

                entity.Property(e => e.NoRef).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pago1).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Pago2).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Pago3).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RutaXml).HasMaxLength(250);

                entity.Property(e => e.SelloCfdi).HasColumnName("SelloCFDI");

                entity.Property(e => e.SelloSat).HasColumnName("SelloSAT");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TipoDocId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'TIC')");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Unidades).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UsoCfdi)
                    .HasColumnName("UsoCFDI")
                    .HasMaxLength(5);

                entity.Property(e => e.UuId).HasMaxLength(40);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Venta_Cliente");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Usuario");

                entity.HasOne(d => d.Estacion)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.EstacionId)
                    .HasConstraintName("FK_Venta_Estacion");

                entity.HasOne(d => d.TipoDoc)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.TipoDocId)
                    .HasConstraintName("FK_Venta_TipoDoc");

                entity.HasOne(d => d.UsoCfdiNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.UsoCfdi)
                    .HasConstraintName("Venta_C_Usocfdi_UsoCFDIId_fk");
            });

            modelBuilder.Entity<Ventap>(entity =>
            {
                entity.Property(e => e.Caducidad1).HasColumnType("datetime");

                entity.Property(e => e.Caducidad2).HasColumnType("datetime");

                entity.Property(e => e.Caducidad3).HasColumnType("datetime");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(18, 6)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClaveImpuesto1).HasMaxLength(5);

                entity.Property(e => e.ClaveImpuesto2).HasMaxLength(5);

                entity.Property(e => e.ClaveProdServ)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'01010101')");

                entity.Property(e => e.ClaveUnidad)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'H87')");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteImpuesto1).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteImpuesto2).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Impuesto1).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Impuesto2).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.NoLote1).HasMaxLength(50);

                entity.Property(e => e.NoLote2).HasMaxLength(50);

                entity.Property(e => e.NoLote3).HasMaxLength(50);

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 6)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TasaOcuota1).HasMaxLength(50);

                entity.Property(e => e.TasaOcuota2).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Unidad).HasMaxLength(50);

                entity.HasOne(d => d.ClaveImpuesto1Navigation)
                    .WithMany(p => p.VentapClaveImpuesto1Navigation)
                    .HasForeignKey(d => d.ClaveImpuesto1)
                    .HasConstraintName("Ventap_C_Impuesto_ImpuestoId_fk");

                entity.HasOne(d => d.ClaveImpuesto2Navigation)
                    .WithMany(p => p.VentapClaveImpuesto2Navigation)
                    .HasForeignKey(d => d.ClaveImpuesto2)
                    .HasConstraintName("Ventap_C_Impuesto_ImpuestoId_fk_2");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.Ventap)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventap_Venta");
            });
        }
    }
}
