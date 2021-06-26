using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public string IdAdmin { get; set; }
        public string TenAdmin { get; set; }
        public string MatKhau { get; set; }
    }
}
