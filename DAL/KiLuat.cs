using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("KiLuat")]
    public class KiLuat
    {
        [Key]
        public int Id { get; set; }
        public string IdNhanVien { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }
        public DateTime NgayKiLuat { get; set; }
        public string LyDoKiLuat { get; set; }
        public string HinhThucKiLuat { get; set; }
    }
}
