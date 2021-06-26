using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("NhanVien")]
    public class NhanVien
    {
        public NhanVien()
        {
            this.BaoCaos = new HashSet<BaoCao>();
            this.DayOffs = new HashSet<DayOff>();
            this.DayOnls = new HashSet<DayOnl>();
            this.KhenThuongs = new HashSet<KhenThuong>();
            this.KiLuats = new HashSet<KiLuat>();
            this.QuaTrinhLuongs = new HashSet<QuaTrinhLuong>();
        }

        [Key]
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string IdPhongBan { get; set; }
        [ForeignKey("IdPhongBan")]
        public virtual PhongBan PhongBan { get; set; }

        public int IdChucVu { get; set; }
        [ForeignKey("IdChucVu")]
        public virtual ChucVu ChucVu { get; set; }

        public string SDT { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string DanToc { get; set; }
        public bool TonGiao { get; set; }
        public string SDTNguoiThan { get; set; }

        public virtual Account Account { get; set; }
        public virtual BangLuong BangLuongs { get; set; }
        public virtual ICollection<BaoCao> BaoCaos { get; set; }
        public virtual ICollection<DayOff> DayOffs { get; set; }
        public virtual ICollection<DayOnl> DayOnls { get; set; }
        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
        public virtual ICollection<KiLuat> KiLuats { get; set; }
        public virtual ICollection<QuaTrinhLuong> QuaTrinhLuongs { get; set; }

    }
}
