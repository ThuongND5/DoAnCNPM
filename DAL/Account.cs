using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [ForeignKey("NhanVien")]
        public string IdNhanVien { get; set; }
        public string MatKhau { get; set; }
        public int KieuPhanQuyen { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
