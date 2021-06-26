using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class DayOff
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public System.DateTime NgayOff { get; set; }
        public string LyDo { get; set; }
        public static DayOff ViewDayOff(DAL.DayOff off)
        {
            DayOff x = new DayOff
            {
                IdNhanVien = off.IdNhanVien,
                TenNhanVien = off.NhanVien.TenNhanVien,
                NgayOff = off.NgayOff,
                LyDo = off.LyDo
            };
            return x;
        }
        public static List<DayOff> ListDayOff(List<DAL.DayOff> off)
        {
            List<DayOff> data = new List<DayOff>();
            foreach (DAL.DayOff i in off)
                data.Add(ViewDayOff(i));
            return data;
        }
    }
}
