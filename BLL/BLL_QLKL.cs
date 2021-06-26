using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_QLKL
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_QLKL _Instance;

        internal static BLL_QLKL Instance 
        { 
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLKL();
                return _Instance;
            }
            private set => _Instance = value; 
        }
        private BLL_QLKL()
        { }

        public List<DTO.KiLuat> Show_QLKL_QL()
        {
            return DTO.KiLuat.ListKiLuat(db.KiLuats.Where(p => p.NhanVien.IdChucVu != 1).Select(p => p).ToList());
        }
        public List<DTO.KiLuat> Show_QLKL_AD()
        {
            return DTO.KiLuat.ListKiLuat(db.KiLuats.Select(p => p).ToList());
        }
        public DAL.KiLuat GetKiLuat(string id, DateTime date, string ld, string ht)
        {
            DAL.KiLuat kl = db.KiLuats.Where(p => p.IdNhanVien == id && p.NgayKiLuat == date && p.LyDoKiLuat == ld && p.HinhThucKiLuat == ht).FirstOrDefault();
            return kl;
        }
        public bool ID_inDB(string id)
        {
            DAL.NhanVien nv = db.NhanViens.Where(p => p.IdNhanVien == id).FirstOrDefault();
            if (nv == null)
                return false;
            else
                return true;
        }
        public List<string> ID_QL()
        {
            List<string> data = new List<string>();
            data = db.NhanViens.Where(p => p.IdChucVu == 1).Select(p => p.IdNhanVien).ToList();
            return data;
        }
        public bool Add_KL(DAL.KiLuat kl)
        {
            try
            {
                db.KiLuats.Add(kl);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public void Update_KL(DAL.KiLuat kl_update, DAL.KiLuat kl_chuaupdate)
        {
            try
            {
                var klupdate = db.KiLuats.
                    Where(p => p.IdNhanVien == kl_chuaupdate.IdNhanVien && p.NgayKiLuat == kl_chuaupdate.NgayKiLuat
                    && p.LyDoKiLuat == kl_chuaupdate.LyDoKiLuat && p.HinhThucKiLuat == kl_chuaupdate.HinhThucKiLuat)
                    .FirstOrDefault();
                klupdate.IdNhanVien = kl_update.IdNhanVien;
                klupdate.NgayKiLuat = kl_update.NgayKiLuat;
                klupdate.LyDoKiLuat = kl_update.LyDoKiLuat;
                klupdate.HinhThucKiLuat = kl_update.HinhThucKiLuat;
                db.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public void Del_KL(List<DAL.KiLuat> kl)
        {
            foreach (DAL.KiLuat i in kl)
            {
                string id = i.IdNhanVien;
                string ht = i.HinhThucKiLuat;
                string ld = i.LyDoKiLuat;
                DateTime date = i.NgayKiLuat;
                DAL.KiLuat data = db.KiLuats.Where(p => p.IdNhanVien == id && p.LyDoKiLuat == ld && p.HinhThucKiLuat == ht && p.NgayKiLuat == date).FirstOrDefault();
                db.KiLuats.Remove(data);
            }
            db.SaveChanges();
        }
        public List<DTO.KiLuat> Search_KL_QL(string name)
        {
            return DTO.KiLuat.ListKiLuat(db.KiLuats.Where(p => p.NhanVien.TenNhanVien.Contains(name) && p.NhanVien.IdChucVu != 1).Select(p => p).ToList());
        }
        public List<DTO.KiLuat> Search_KL_AD(string name)
        {
            return DTO.KiLuat.ListKiLuat(db.KiLuats.Where(p => p.NhanVien.TenNhanVien.Contains(name)).Select(p => p).ToList());
        }
    }
}
