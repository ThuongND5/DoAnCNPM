using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("DayOnl")]
    public class DayOnl
    {
        [Key]
        public int Id { get; set; }
        public string IdNhanVien { get; set; }
        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayOnl { get; set; }
    }
}
