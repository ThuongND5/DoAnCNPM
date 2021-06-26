using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("QuaTrinhLuong")]
    public class QuaTrinhLuong
    {
        [Key]
        public int Id { get; set; }
        public string IdNhanVien { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public int TienLuong { get; set; }
        public DateTime NgayNhan { get; set; }
    }
}
