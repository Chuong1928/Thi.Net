namespace NgoQuyTruong.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLDANHBADBContext : DbContext
    {
        public QLDANHBADBContext()
            : base("name=QLDANHBADBContext")
        {
        }

        public virtual DbSet<LIENLAC> LIENLACs { get; set; }
        public virtual DbSet<NHOM> NHOMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
