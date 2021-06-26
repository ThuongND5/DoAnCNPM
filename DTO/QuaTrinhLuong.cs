using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    class QuaTrinhLuong
    {
        public string IdNhanVien { get; set; }
        public int TienLuong { get; set; }
        public System.DateTime NgayNhan { get; set; }
        public static QuaTrinhLuong ViewThongTinLuong(DAL.QuaTrinhLuong qtl)
        {
            QuaTrinhLuong x = new QuaTrinhLuong
            {
                IdNhanVien = qtl.IdNhanVien,
                TienLuong = Convert.ToInt32(qtl.TienLuong),
                NgayNhan = qtl.NgayNhan
            };
            return x;
        }
        public static List<QuaTrinhLuong> ListTTL(List<DAL.QuaTrinhLuong> qtl)
        {
            List<QuaTrinhLuong> data = new List<QuaTrinhLuong>();
            foreach (DAL.QuaTrinhLuong i in qtl)
                data.Add(ViewThongTinLuong(i));
            return data;
        }
    }
}
