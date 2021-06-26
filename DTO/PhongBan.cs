using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    class PhongBan
    {
        public string IDPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public static PhongBan ViewPhongBan(DAL.PhongBan pb)
        {
            PhongBan x = new PhongBan
            {
                IDPhongBan = pb.IdPhongBan,
                TenPhongBan = pb.TenPhongBan
            };
            return x;
        }
        public static List<PhongBan> ListPhongBan(List<DAL.PhongBan> pb)
        {
            List<PhongBan> data = new List<PhongBan>();
            foreach (DAL.PhongBan i in pb)
                data.Add(ViewPhongBan(i));
            return data;
        }
    }
}
