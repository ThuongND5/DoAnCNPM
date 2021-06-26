using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class KiLuat
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public System.DateTime NgayKiLuat { get; set; }
        public string LyDoKiLuat { get; set; }
        public string HinhThucKiLuat { get; set; }
        public static KiLuat ViewKiLuat(DAL.KiLuat kl)
        {
            KiLuat x = new KiLuat
            {
                IdNhanVien = kl.IdNhanVien,
                TenNhanVien = kl.NhanVien.TenNhanVien,
                NgayKiLuat = Convert.ToDateTime(kl.NgayKiLuat),
                LyDoKiLuat = kl.LyDoKiLuat,
                HinhThucKiLuat = kl.HinhThucKiLuat
            };
            return x;
        }
        public static List<KiLuat> ListKiLuat(List<DAL.KiLuat> kl)
        {
            List<KiLuat> data = new List<KiLuat>();
            foreach (DAL.KiLuat i in kl)
                data.Add(ViewKiLuat(i));
            return data;
        }
    }
}