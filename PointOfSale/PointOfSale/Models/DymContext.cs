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
        public virtual DbSet<CAduana> CAduana { get; set; }
        public virtual DbSet<CCaducidadfolios> CCaducidadfolios { get; set; }
        public virtual DbSet<CClaveprodserv> CClaveprodserv { get; set; }
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
        public virtual DbSet<ClaveSat> ClaveSat { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Comprap> Comprap { get; set; }
        public virtual DbSet<Consecutivo> Consecutivo { get; set; }
        public virtual DbSet<Cp> Cp { get; set; }
        public virtual DbSet<Cxc> Cxc { get; set; }
        public virtual DbSet<Cxcp> Cxcp { get; set; }
        public virtual DbSet<Cxp> Cxp { get; set; }
        public virtual DbSet<Cxpp> Cxpp { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoDoc> EstadoDoc { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Impuesto> Impuesto { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
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
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<Sustancia> Sustancia { get; set; }
        public virtual DbSet<TipoDoc> TipoDoc { get; set; }
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

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.Property(e => e.AlmacenId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

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

            modelBuilder.Entity<CClaveprodserv>(entity =>
            {
                entity.ToTable("C_Claveprodserv");

                entity.HasIndex(e => e.Descripción)
                    .HasName("IX_C_Claveprodserv_1");

                entity.HasIndex(e => e.PalabrasSimilares)
                    .HasName("IX_C_Claveprodserv");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CClaveProdServ1)
                    .HasColumnName("c_ClaveProdServ")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementoQueDebeIncluir)
                    .HasColumnName("Complemento que debe incluir")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descripción)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinVigencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicioVigencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IncluirIepsTrasladado)
                    .HasColumnName("Incluir IEPS trasladado")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IncluirIvaTrasladado)
                    .HasColumnName("Incluir IVA trasladado")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PalabrasSimilares)
                    .HasColumnName("Palabras similares")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CClaveunidad>(entity =>
            {
                entity.ToTable("C_Claveunidad");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CClaveUnidad1)
                    .HasColumnName("c_ClaveUnidad")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descripción)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fechadefindevigencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fechadeiniciodevigencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nota)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Símbolo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CFormapago>(entity =>
            {
                entity.ToTable("C_Formapago");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bancarizado).HasMaxLength(255);

                entity.Property(e => e.CFormaPago1)
                    .HasColumnName("c_FormaPago")
                    .HasMaxLength(255);

                entity.Property(e => e.CuentaDeBenenficiario)
                    .HasColumnName("Cuenta de Benenficiario")
                    .HasMaxLength(255);

                entity.Property(e => e.CuentaOrdenante)
                    .HasColumnName("Cuenta Ordenante")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.NombreDelBancoEmisorDeLaCuentaOrdenanteEnCasoDeExtran)
                    .HasColumnName("Nombre del Banco emisor de la cuenta ordenante en caso de extran")
                    .HasMaxLength(255);

                entity.Property(e => e.NúmeroDeOperación)
                    .HasColumnName("Número de operación")
                    .HasMaxLength(255);

                entity.Property(e => e.PatrónParaCuentaBeneficiaria)
                    .HasColumnName("Patrón para cuenta Beneficiaria")
                    .HasMaxLength(255);

                entity.Property(e => e.PatrónParaCuentaOrdenante)
                    .HasColumnName("Patrón para cuenta ordenante")
                    .HasMaxLength(255);

                entity.Property(e => e.RfcDelEmisorCuentaDeBeneficiario)
                    .HasColumnName("RFC del Emisor Cuenta de Beneficiario")
                    .HasMaxLength(255);

                entity.Property(e => e.RfcDelEmisorDeLaCuentaOrdenante)
                    .HasColumnName("RFC del Emisor de la cuenta ordenante")
                    .HasMaxLength(255);

                entity.Property(e => e.TipoCadenaPago)
                    .HasColumnName("Tipo Cadena Pago")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CImpuesto>(entity =>
            {
                entity.ToTable("C_Impuesto");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CImpuesto1)
                    .HasColumnName("c_Impuesto")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.EntidadEnLaQueAplica)
                    .HasColumnName("Entidad en la que aplica")
                    .HasMaxLength(255);

                entity.Property(e => e.LocalOFederal)
                    .HasColumnName("Local o federal")
                    .HasMaxLength(255);

                entity.Property(e => e.Retención).HasMaxLength(255);

                entity.Property(e => e.Traslado).HasMaxLength(255);
            });

            modelBuilder.Entity<CMetodopago>(entity =>
            {
                entity.ToTable("C_Metodopago");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CMetodoPago1)
                    .HasColumnName("c_MetodoPago")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);
            });

            modelBuilder.Entity<CMoneda>(entity =>
            {
                entity.ToTable("C_Moneda");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CMoneda1)
                    .HasColumnName("c_Moneda")
                    .HasMaxLength(255);

                entity.Property(e => e.Decimales).HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.PorcentajeVariación)
                    .HasColumnName("Porcentaje variación")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CNumpedimentoaduana>(entity =>
            {
                entity.ToTable("C_Numpedimentoaduana");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CAduana)
                    .HasColumnName("c_Aduana")
                    .HasMaxLength(255);

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
                entity.ToTable("C_Regimenfiscal");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CRegimenFiscal1)
                    .HasColumnName("c_RegimenFiscal")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.FechaDeFinDeVigencia)
                    .HasColumnName("Fecha de fin de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaDeInicioDeVigencia)
                    .HasColumnName("Fecha de inicio de vigencia")
                    .HasMaxLength(255);

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
                entity.ToTable("C_Tipodecomprobante");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CTipoDeComprobante1)
                    .HasColumnName("c_TipoDeComprobante")
                    .HasMaxLength(255);

                entity.Property(e => e.D).HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.FechaFinDeVigencia)
                    .HasColumnName("Fecha fin de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaInicioDeVigencia)
                    .HasColumnName("Fecha inicio de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.ValorMáximo)
                    .HasColumnName("Valor máximo")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CTipofactor>(entity =>
            {
                entity.ToTable("C_Tipofactor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CTipoFactor1)
                    .HasColumnName("c_TipoFactor")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CTiporelacion>(entity =>
            {
                entity.ToTable("C_Tiporelacion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CTipoRelacion1)
                    .HasColumnName("c_TipoRelacion")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);
            });

            modelBuilder.Entity<CUsocfdi>(entity =>
            {
                entity.ToTable("C_Usocfdi");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CUsoCfdi1)
                    .HasColumnName("c_UsoCFDI")
                    .HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.FechaFinDeVigencia)
                    .HasColumnName("Fecha fin de vigencia")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaInicioDeVigencia)
                    .HasColumnName("Fecha inicio de vigencia")
                    .HasMaxLength(255);

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

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FormaPago)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("(N'PUE')");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Localidad).HasMaxLength(50);

                entity.Property(e => e.MetodoPago)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasDefaultValueSql("(N'01')");

                entity.Property(e => e.Municipio).HasMaxLength(50);

                entity.Property(e => e.Pais).HasMaxLength(50);

                entity.Property(e => e.PrecioDefault)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'PRECIO 1')");

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasMaxLength(50);

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.HasOne(d => d.FormaPagoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.FormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_FormaPago");

                entity.HasOne(d => d.MetodoPagoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.MetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_MetodoPago");
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

                entity.Property(e => e.TipoDocId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'COM')");

                entity.HasOne(d => d.Almacen)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.AlmacenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Almacen");

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
                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Impuesto1)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0.16))");

                entity.Property(e => e.Impuesto2).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Impuesto3).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Impuestos).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.Comprap)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprap_Compra");
            });

            modelBuilder.Entity<Consecutivo>(entity =>
            {
                entity.Property(e => e.ConsecutivoId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();
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
                entity.Property(e => e.CRegimenFiscal)
                    .IsRequired()
                    .HasColumnName("C_RegimenFiscal")
                    .HasMaxLength(50);

                entity.Property(e => e.ClavePrivada)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cp)
                    .IsRequired()
                    .HasColumnName("CP")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion).IsRequired();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Negocio).IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RazonSocial).IsRequired();

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.RutaCer)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RutaComprobantes)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RutaKey)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.Property(e => e.EstacionId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultAlmacenId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ImpresoraF)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.ImpresoraNc)
                    .IsRequired()
                    .HasColumnName("ImpresoraNC")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.ImpresoraR)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.ImpresoraT)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SIN NOMBRE')");
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

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.Property(e => e.FormaPagoId)
                    .HasMaxLength(2)
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
                    .HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Tasa).HasColumnType("decimal(18, 2)");
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
                entity.Property(e => e.LoteId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Caducidad).HasColumnType("date");

                entity.Property(e => e.ProductoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lote_Producto");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.Property(e => e.MetodoPagoId)
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.CategoriaId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.ClaveCfdiId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'01010101')");

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CratedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CratedBy).HasMaxLength(50);

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.Property(e => e.LaboratorioId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LoteId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio1)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio2)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio3)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Precio4)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioCaja)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioCompra)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PresentacionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.RutaImg)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.UnidadCfdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'H87')");

                entity.Property(e => e.UnidadMedidaId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.Unidades).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Utilidad1)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Utilidad2)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Utilidad3)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Utilidad4)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Categoria");

                entity.HasOne(d => d.ClaveCfdi)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.ClaveCfdiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_ClaveSat");

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

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.SerieName)
                    .IsRequired()
                    .HasMaxLength(50);
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

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.AlmacenId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClienteId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'SYS')");

                entity.Property(e => e.ConceptoPago1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ConceptoPago2).HasMaxLength(50);

                entity.Property(e => e.ConceptoPago3).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DatosCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EstacionId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EstadoDocId)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'PEN')");

                entity.Property(e => e.FechaDoc)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImporteLetra).IsRequired();

                entity.Property(e => e.Impuesto)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MonedaId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'MXN')");

                entity.Property(e => e.NoPrecio).HasDefaultValueSql("((1))");

                entity.Property(e => e.Pago1).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Pago2).HasMaxLength(50);

                entity.Property(e => e.Pago3).HasMaxLength(50);

                entity.Property(e => e.RutaXml).HasMaxLength(250);

                entity.Property(e => e.SerieDoc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'TCK')");

                entity.Property(e => e.TipoDocId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'T')");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UuId).HasMaxLength(40);
            });

            modelBuilder.Entity<Ventap>(entity =>
            {
                entity.HasKey(e => e.Ventap1);

                entity.Property(e => e.Ventap1).HasColumnName("Ventap");

                entity.Property(e => e.CantImpuestos).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Impuesto1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Impuesto2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Impuesto3).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoteId).HasMaxLength(50);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 3)");
            });
        }
    }
}
