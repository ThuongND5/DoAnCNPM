using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public int IdChucVu { get; set; }
        public string TenChucVu { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public ChucVu()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }
    }
}
