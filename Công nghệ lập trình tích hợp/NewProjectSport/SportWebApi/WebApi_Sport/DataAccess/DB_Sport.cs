namespace WebApi_Sport.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_Sport : DbContext
    {
        public DB_Sport()
            : base("name=DB_Sport")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAILs { get; set; }
        public virtual DbSet<ORDERSTATU> ORDERSTATUS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<PROPERTy> PROPERTIES { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.PRODUCTs)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERSTATU>()
                .HasMany(e => e.ORDERs)
                .WithOptional(e => e.ORDERSTATU)
                .HasForeignKey(e => e.OrderStatusID);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.ProductPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.PROPERTIES)
                .WithOptional(e => e.PRODUCT)
                .WillCascadeOnDelete();
        }
    }
}
