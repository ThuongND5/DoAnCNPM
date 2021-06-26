using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class DayOnl
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public System.DateTime NgayOnl { get; set; }
        public static DayOnl ViewDayOnl(DAL.DayOnl onl)
        {
            DayOnl x = new DayOnl
            {
                IdNhanVien = onl.IdNhanVien,
                TenNhanVien = onl.NhanVien.TenNhanVien,
                NgayOnl = Convert.ToDateTime(onl.NgayOnl)
            };
            return x;
        }
        public static List<DayOnl> ListDayOnl(List<DAL.DayOnl> onl)
        {
            List<DayOnl> data = new List<DayOnl>();
            foreach (DAL.DayOnl i in onl)
                data.Add(ViewDayOnl(i));
            return data;
        }
    }
}
