using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("PhongBan")]
    public class PhongBan
    {
        [Key]
        public string IdPhongBan { get; set; }
        public string TenPhongBan { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public PhongBan()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }
    }
}
