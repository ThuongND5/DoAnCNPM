namespace DoAnCNPM.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class QLNS : DbContext
    {
        // Your context has been configured to use a 'QLNS' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DoAnCNPM.DAL.QLNS' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLNS' 
        // connection string in the application configuration file.
        public QLNS()
             : base("name=QLNS")
        {
            Database.SetInitializer<QLNS>(new TaoRecords());
        }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BangLuong> BangLuongs { get; set; }
        public virtual DbSet<BaoCao> BaoCaos { get; set; }
        public virtual DbSet<DayOff> DayOffs { get; set; }
        public virtual DbSet<DayOnl> DayOnls { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<KiLuat> KiLuats { get; set; }
        public virtual DbSet<QuaTrinhLuong> QuaTrinhLuongs { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}