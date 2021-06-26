using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_NV_TTL
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_NV_TTL _Instance;

        internal static BLL_NV_TTL Instance
        {
            get 
            {
                if (_Instance == null)
                    _Instance = new BLL_NV_TTL();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_NV_TTL()
        { }
        public List<DTO.QuaTrinhLuong> ShowQTL(string ID)
        {
            try
            {
                return DTO.QuaTrinhLuong.ListTTL(db.QuaTrinhLuongs.Where(p => p.IdNhanVien == ID).Select(p => p).ToList());
            }catch (Exception)
            { return null; }
        }
        public DAL.BangLuong GetTTBL(string ID)
        {
            try
            {
                DAL.BangLuong get = db.BangLuongs.Where(p => p.IdNhanVien == ID).FirstOrDefault();
                return get;
            }catch (Exception)
            { return null; }
        }
    }
}
