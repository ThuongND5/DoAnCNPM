using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_QLL
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_QLL _Instance;

        internal static BLL_QLL Instance 
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLL();
                return _Instance; 
            }
            private set => _Instance = value; 
        }
        private BLL_QLL()
        { }

        public List<DTO.BangLuong> Show_QLL_QL()
        {
            return DTO.BangLuong.ListBangLuong(db.BangLuongs.Where(p => p.NhanVien.IdChucVu != 1).Select(p => p).ToList());
        }
        public List<DTO.BangLuong> Show_QLL_AD()
        {
            return DTO.BangLuong.ListBangLuong(db.BangLuongs.Select(p => p).ToList());
        }
        public DAL.BangLuong GetBangLuong(string id)
        {
            DAL.BangLuong data = db.BangLuongs.Where(p => p.IdNhanVien == id).FirstOrDefault();
            return data;
        }
        public void Update(DAL.BangLuong bl)
        {
            DAL.BangLuong upd = db.BangLuongs.Where(p => p.IdNhanVien == bl.IdNhanVien).FirstOrDefault();
            upd.IdNhanVien = bl.IdNhanVien;
            upd.MucLuongCoBan = bl.MucLuongCoBan;
            upd.SoNgayLam = bl.SoNgayLam;
            upd.TongTienLuong = bl.TongTienLuong;
            db.SaveChanges();
        }
        public List<DTO.BangLuong> Search_QL(string name)
        {
            return DTO.BangLuong.ListBangLuong(db.BangLuongs.Where(p => p.NhanVien.TenNhanVien.Contains(name) && p.NhanVien.IdChucVu != 1).Select(p => p).ToList());
        }
        public List<DTO.BangLuong> Search_AD(string name)
        {
            return DTO.BangLuong.ListBangLuong(db.BangLuongs.Where(p => p.NhanVien.TenNhanVien.Contains(name)).Select(p => p).ToList());
        }
        public void TinhLuong(DAL.BangLuong bl)
        {
            DAL.QuaTrinhLuong data = new DAL.QuaTrinhLuong();
            data.IdNhanVien = bl.IdNhanVien;
            data.NgayNhan = DateTime.Today;
            data.TienLuong = bl.MucLuongCoBan*bl.SoNgayLam;
            db.QuaTrinhLuongs.Add(data);
            DAL.BangLuong bl_update = db.BangLuongs.Where(p => p.IdNhanVien == bl.IdNhanVien).FirstOrDefault();
            bl_update.SoNgayLam = 0;
            bl_update.TongTienLuong = 0;

            //List<DAL.DayOnl> dayonl = db.DayOnls.Select(p => p).ToList();
            //db.DayOnls.RemoveRange(dayonl);
            //List<DAL.DayOff> dayoff = db.DayOffs.Select(p => p).ToList();
            //db.DayOffs.RemoveRange(dayoff);

            db.SaveChanges();
        }
        public void Del_QTT()
        {
            var qtl = db.QuaTrinhLuongs.Select(p => p).ToList();
            db.QuaTrinhLuongs.RemoveRange(qtl);
            db.SaveChanges();
        }
    }
}
