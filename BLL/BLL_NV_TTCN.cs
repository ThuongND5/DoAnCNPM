using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_NV_TTCN
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_NV_TTCN _Instance;

        internal static BLL_NV_TTCN Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_NV_TTCN();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_NV_TTCN()
        { }

        public DAL.NhanVien GetTTCN(string ID)
        {
            try
            {
                DAL.NhanVien nv = db.NhanViens.Where(p => p.IdNhanVien == ID).FirstOrDefault();
                return nv;
            }catch(Exception)
            { return null; }
        }

        public void UpdateTTCN(DAL.NhanVien nv)
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
            }catch(Exception)
            { }
        }
        public List<DAL.PhongBan> SetPhongBan()
        {
            return db.PhongBans.ToList();
        }
        public List<DAL.ChucVu> SetChucVu()
        {
            return db.ChucVus.ToList();
        }
    }
}
