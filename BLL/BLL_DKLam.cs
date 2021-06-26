using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_DKLam
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_DKLam _Instance;

        internal static BLL_DKLam Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_DKLam();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_DKLam()
        { }
        public List<DTO.DayOnl> ShowNgayOnl(string ID)
        {
            return DTO.DayOnl.ListDayOnl(db.DayOnls.Where(p => p.IdNhanVien == ID).Select(p => p).ToList());
        }
        public List<DTO.DayOff> ShowNgayOff(string ID)
        {
            
            return DTO.DayOff.ListDayOff(db.DayOffs.Where(p => p.IdNhanVien == ID).Select(p => p).ToList());
        }
        public void AddNgayOnl(DAL.DayOnl dayonl, string ID)
        {
            db.DayOnls.Add(dayonl);
            DAL.BangLuong id = db.BangLuongs.Where(p => p.IdNhanVien == ID).FirstOrDefault();
            id.SoNgayLam += 1;
            id.TongTienLuong = id.SoNgayLam * id.MucLuongCoBan;
            db.SaveChanges();
        }
        public void AddNgayOff(DAL.DayOff dayoff)
        {
            db.DayOffs.Add(dayoff);
            db.SaveChanges();
        }
        public bool CheckDaDKOnl(string ID, DateTime date)
        {
            try
            {
                if (db.DayOnls.Where(p => p.IdNhanVien == ID && p.NgayOnl == date).FirstOrDefault() == null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckDaDKOff(string ID, DateTime date)
        {
            try
            {
                if (db.DayOffs.Where(p => p.IdNhanVien == ID && p.NgayOff == date).FirstOrDefault() == null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckOnl(string ID, DateTime date)
        {
            DAL.DayOnl onl = db.DayOnls.Where(p => p.IdNhanVien == ID && p.NgayOnl == date).FirstOrDefault();
            if (onl != null)
                return false;
            else
                return true;
        }
        public bool CheckOff(string ID, DateTime date)
        {
            DAL.DayOff off = db.DayOffs.Where(p => p.IdNhanVien == ID && p.NgayOff == date).FirstOrDefault();
            if (off != null)
                return false;
            else
                return true;
        }
    }
}
