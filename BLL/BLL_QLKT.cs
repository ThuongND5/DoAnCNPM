using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_QLKT
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_QLKT _Instance;

        internal static BLL_QLKT Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLKT();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_QLKT()
        { }
        public List<DTO.KhenThuong> Show_QLKT_QL()
        {
            return DTO.KhenThuong.ListKhenThuong(db.KhenThuongs.Where(p=> p.NhanVien.IdChucVu != 1).Select(p=>p).ToList());
        }
        public List<DTO.KhenThuong> Show_QLKT_AD()
        {
            return DTO.KhenThuong.ListKhenThuong(db.KhenThuongs.Select(p => p).ToList());
        }
        public DAL.KhenThuong GetKhenThuong(string id, DateTime date, string ld, string ht)
        {
            DAL.KhenThuong kt = db.KhenThuongs.Where(p => p.IdNhanVien == id && p.NgayKhenThuong == date && p.LyDoKhenThuong == ld && p.HinhThucKhenThuong == ht).FirstOrDefault();
            return kt;
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
        public bool Add_KT(DAL.KhenThuong kt)
        {
            try
            {
                db.KhenThuongs.Add(kt);
                db.SaveChanges();
                return true;
            }catch(Exception)
            { return false; }
        }
        public void Update_KT(DAL.KhenThuong kt_update, DAL.KhenThuong kt_chuaupdate)
        {
            try
            {
                var ktupdate = db.KhenThuongs.
                    Where(p => p.IdNhanVien == kt_chuaupdate.IdNhanVien && p.NgayKhenThuong == kt_chuaupdate.NgayKhenThuong
                    && p.LyDoKhenThuong == kt_chuaupdate.LyDoKhenThuong && p.HinhThucKhenThuong == kt_chuaupdate.HinhThucKhenThuong)
                    .FirstOrDefault();
                ktupdate.IdNhanVien = kt_update.IdNhanVien;
                ktupdate.NgayKhenThuong = kt_update.NgayKhenThuong;
                ktupdate.LyDoKhenThuong = kt_update.LyDoKhenThuong;
                ktupdate.HinhThucKhenThuong = kt_update.HinhThucKhenThuong;
                db.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public void Del_KT(List<DAL.KhenThuong> kt)
        {
                foreach (DAL.KhenThuong i in kt)
                {
                    string id = i.IdNhanVien;
                    string ht = i.HinhThucKhenThuong;
                    string ld = i.LyDoKhenThuong;
                    DateTime date = i.NgayKhenThuong;
                    DAL.KhenThuong data = db.KhenThuongs.Where(p => p.IdNhanVien == id && p.LyDoKhenThuong == ld && p.HinhThucKhenThuong == ht &&p.NgayKhenThuong == date).FirstOrDefault();
                    db.KhenThuongs.Remove(data);
                }
                db.SaveChanges();
        }
        public List<DTO.KhenThuong> Search_KT_QL(string name)
        {
            return DTO.KhenThuong.ListKhenThuong(db.KhenThuongs.Where(p => p.NhanVien.TenNhanVien.Contains(name) && p.NhanVien.IdChucVu != 1).Select(p => p).ToList());
        }
        public List<DTO.KhenThuong> Search_KT_AD(string name)
        {
            return DTO.KhenThuong.ListKhenThuong(db.KhenThuongs.Where(p => p.NhanVien.TenNhanVien.Contains(name)).Select(p => p).ToList());
        }
    }
}
