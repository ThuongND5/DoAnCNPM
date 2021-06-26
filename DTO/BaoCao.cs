using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class BaoCao
    {
        public string IdNhanVien { get; set; }
        public System.DateTime NgayBaoCao { get; set; }
        public string NoiDung { get; set; }
        public static BaoCao ViewBaoCao (DAL.BaoCao bc)
        {
            BaoCao x = new BaoCao
            {
                IdNhanVien = bc.IdNhanVien,
                NgayBaoCao = Convert.ToDateTime(bc.NgayBaoCao),
                NoiDung = bc.NoiDung
            };
            return x;
        }
        public static List<BaoCao> ListBaoCao(List<DAL.BaoCao> bc)
        {
            List<BaoCao> data = new List<BaoCao>();
            foreach (DAL.BaoCao i in bc)
                data.Add(ViewBaoCao(i));
            return data;
        }
    }
}
