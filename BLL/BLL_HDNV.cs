using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_HDNV
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_HDNV _Instance;

        internal static BLL_HDNV Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_HDNV();
                return _Instance;
            }
            set => _Instance = value;
        }
        private BLL_HDNV()
        { }

        public List<DTO.DayOnl> GetDayOnl_ThangNay()
        {
            return DTO.DayOnl.ListDayOnl(db.DayOnls.Where(p => p.NgayOnl.Month == DateTime.Now.Month).Select(p => p).ToList());
        }
        public List<DTO.DayOnl> GetDayOnl_ThangTruoc()
        {
            return DTO.DayOnl.ListDayOnl(db.DayOnls.Where(p => p.NgayOnl.Month == DateTime.Now.Month - 1).Select(p => p).ToList());
        }
        public List<DTO.DayOff> GetDayOff_ThangNay()
        {
            return DTO.DayOff.ListDayOff(db.DayOffs.Where(p => p.NgayOff.Month == DateTime.Now.Month).Select(p => p).ToList());
        }
        public List<DTO.DayOff> GetDayOff_ThangTruoc()
        {
            return DTO.DayOff.ListDayOff(db.DayOffs.Where(p => p.NgayOff.Month == DateTime.Now.Month - 1).Select(p => p).ToList());
        }
    }
}
