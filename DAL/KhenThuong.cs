using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("KhenThuong")]
    public class KhenThuong
    {
        [Key]
        public int Id { get; set; }
        public string IdNhanVien { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayKhenThuong { get; set; }
        public string LyDoKhenThuong { get; set; }
        public string HinhThucKhenThuong { get; set; }
    }
}
