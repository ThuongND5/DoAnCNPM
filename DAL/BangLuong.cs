using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("BangLuong")]
    public class BangLuong
    {
        [Key]
        [ForeignKey("NhanVien")]
        public string IdNhanVien { get; set; }
        public int MucLuongCoBan { get; set; }
        public int SoNgayLam { get; set; }
        public Nullable<int> TongTienLuong { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
