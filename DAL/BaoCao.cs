using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("BaoCao")]
    public class BaoCao
    {
        [Key]
        public int Id { get; set; }
        public string IdNhanVien { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayBaoCao { get; set; }
        public string NoiDung { get; set; }
    }
}
