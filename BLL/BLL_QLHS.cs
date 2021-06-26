using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_QLHS
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_QLHS _Instance;

        internal static BLL_QLHS Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLHS();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_QLHS()
        { }

        public List<DTO.NhanVien> Show_QLHS()
        {
            return DTO.NhanVien.ListNhanVien(db.NhanViens.Select(p=>p).ToList());
        }
        public List<DAL.PhongBan> SetPhongBan()
        {
            return db.PhongBans.ToList();
        }
        public List<DAL.ChucVu> SetChucVu()
        {
            return db.ChucVus.ToList();
        }
        public DAL.NhanVien GetNV(string id)
        {
            DAL.NhanVien nv = db.NhanViens.Where(p => p.IdNhanVien == id).FirstOrDefault();
            return nv;
        }
        public List<string> GetID()
        {
            List<DAL.NhanVien> nv = new List<DAL.NhanVien>();
            nv = db.NhanViens.Select(p => p).ToList();
            List<string> data = new List<string>();
            foreach (DAL.NhanVien i in nv)
                data.Add(i.IdNhanVien);
            return data;
        }
        public void Del_HS(List<string> id)
        {
            foreach (string i in id)
            {
                DAL.NhanVien nv = db.NhanViens.Where(p => p.IdNhanVien == i).FirstOrDefault();
                db.NhanViens.Remove(nv);
                DAL.Account ac = db.Accounts.Where(p => p.IdNhanVien == i).FirstOrDefault();
                if(ac != null)
                    db.Accounts.Remove(ac);
                DAL.BangLuong bl = db.BangLuongs.Where(p => p.IdNhanVien == i).FirstOrDefault();
                if (bl != null)
                    db.BangLuongs.Remove(bl);
                List<DAL.KhenThuong> list_kt = db.KhenThuongs.Where(p => p.IdNhanVien == i).Select(p => p).ToList();
                if(list_kt.Count != 0)
                    db.KhenThuongs.RemoveRange(list_kt);
                List<DAL.KiLuat> list_kl = db.KiLuats.Where(p => p.IdNhanVien == i).Select(p => p).ToList();
                if (list_kl.Count != 0)
                    db.KiLuats.RemoveRange(list_kl);
                List<DAL.DayOnl> list_onl = db.DayOnls.Where(p => p.IdNhanVien == i).Select(p => p).ToList();
                if (list_onl.Count != 0)
                    db.DayOnls.RemoveRange(list_onl);
                List<DAL.DayOff> list_off = db.DayOffs.Where(p => p.IdNhanVien == i).Select(p => p).ToList();
                if (list_off.Count != 0)
                    db.DayOffs.RemoveRange(list_off);
                List<DAL.QuaTrinhLuong> list_qtl = db.QuaTrinhLuongs.Where(p => p.IdNhanVien == i).Select(p => p).ToList();
                if (list_qtl.Count != 0)
                    db.QuaTrinhLuongs.RemoveRange(list_qtl);
            }
            db.SaveChanges();
        }
        public void Add_HS(DAL.NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }
        public void Update_HS(DAL.NhanVien nv)
        {
            try
            {
                var nvupdate = db.NhanViens.Where(p => p.IdNhanVien == nv.IdNhanVien).FirstOrDefault();
                nvupdate.IdNhanVien = nv.IdNhanVien;
                nvupdate.TenNhanVien = nv.TenNhanVien;
                nvupdate.NgaySinh = nv.NgaySinh;
                nvupdate.GioiTinh = nv.GioiTinh;
                nvupdate.IdPhongBan = nv.IdPhongBan;
                nvupdate.IdChucVu = nv.IdChucVu;
                nvupdate.SDT = nv.SDT;
                nvupdate.CMND = nv.CMND;
                nvupdate.DiaChi = nv.DiaChi;
                nvupdate.QueQuan = nv.QueQuan;
                nvupdate.DanToc = nv.DanToc;
                nvupdate.TonGiao = nv.TonGiao;
                nvupdate.SDTNguoiThan = nv.SDTNguoiThan;
                db.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public List<DTO.NhanVien> Search_HS(string name)
        {
            return DTO.NhanVien.ListNhanVien(db.NhanViens.Where(p=>p.TenNhanVien.Contains(name)).Select(p=>p).ToList());
        }
    }
}
