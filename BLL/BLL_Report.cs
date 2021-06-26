using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    public class BLL_Report
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_Report _Instance;

        internal static BLL_Report Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_Report();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_Report()
        { }

        public void Add(DAL.BaoCao bc)
        {
            try
            {
                db.BaoCaos.Add(bc);
                db.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public void Del(string id, string nd, DateTime ngaybc)
        {
            DAL.BaoCao bc = db.BaoCaos.Where(p => p.IdNhanVien == id && p.NoiDung == nd && p.NgayBaoCao == ngaybc).FirstOrDefault();
            db.BaoCaos.Remove(bc);
        }
        public void SaveDB()
        {
            db.SaveChanges();
        }
        public List<DAL.BaoCao> Show()
        {
            var bc = db.BaoCaos.Select(p =>p).ToList();
            return bc;
        }
    }
}
