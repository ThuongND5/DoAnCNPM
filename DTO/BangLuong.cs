using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class BangLuong
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int MucLuongCoBan { get; set; }
        public int SoNgayLam { get; set; }
        public int TongTienLuong { get; set; }
        public static BangLuong ViewBangLuong(DAL.BangLuong bl)
        {
            BangLuong x = new BangLuong
            {
                IdNhanVien = bl.IdNhanVien,
                TenNhanVien = bl.NhanVien.TenNhanVien,
                MucLuongCoBan = bl.MucLuongCoBan,
                SoNgayLam = bl.SoNgayLam,
                TongTienLuong = bl.MucLuongCoBan * bl.SoNgayLam
            };
            return x;
        }
        public static List<BangLuong> ListBangLuong (List<DAL.BangLuong> bt)
        {
            List<BangLuong> data = new List<BangLuong>();
            foreach (DAL.BangLuong i in bt)
                data.Add(ViewBangLuong(i));
            return data;
        }
    }
}
