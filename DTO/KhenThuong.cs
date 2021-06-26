using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class KhenThuong
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public System.DateTime NgayKhenThuong { get; set; }
        public string LyDoKhenThuong { get; set; }
        public string HinhThucKhenThuong { get; set; }
        public static KhenThuong ViewKhenThuong(DAL.KhenThuong kt)
        {
            KhenThuong x = new KhenThuong
            {
                IdNhanVien = kt.IdNhanVien,
                TenNhanVien = kt.NhanVien.TenNhanVien,
                NgayKhenThuong = Convert.ToDateTime(kt.NgayKhenThuong),
                LyDoKhenThuong = kt.LyDoKhenThuong,
                HinhThucKhenThuong = kt.HinhThucKhenThuong
            };
            return x;
        }
        public static List<KhenThuong> ListKhenThuong(List<DAL.KhenThuong> kt)
        {
            List<KhenThuong> data = new List<KhenThuong>();
            foreach (DAL.KhenThuong i in kt)
                data.Add(ViewKhenThuong(i));
            return data;
        }
    }
}
