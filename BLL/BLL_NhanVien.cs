using DoAnCNPM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCNPM.BLL
{
    class BLL_NhanVien
    {
        private static BLL_NhanVien _Instance;

        public static BLL_NhanVien Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_NhanVien();
                }
                return _Instance;
            }
            set => _Instance = value;
        }
        public BLL_NhanVien() { }
        public void showBLL(DataGridView d)
        {
            QLNS db = new QLNS();
            var query = db.NhanViens.Select(p => new { p.IdNhanVien, p.TenNhanVien, p.QueQuan, p.NgaySinh, p.GioiTinh, p.IdChucVu, p.IdPhongBan, p.SDT, p.CMND, p.TonGiao, p.ChucVu.TenChucVu, p.PhongBan.TenPhongBan });
            d.DataSource = query.ToList();
        }
        public List<NhanVien> queryBLL(string msnv)
        {
            QLNS db = new QLNS();
            return db.NhanViens.Where(p => p.IdNhanVien == msnv).Select(p => p).ToList();
        }
        public bool addNV_BLL(NhanVien nv)
        {
            QLNS db = new QLNS();
            try
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void deleteNV_BLL(DataGridViewSelectedRowCollection r)
        {
            QLNS db = new QLNS();
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                foreach (DataGridViewRow j in r)
                {
                    if (i.IdNhanVien == j.Cells["Id"].Value.ToString())
                    {
                        NhanVien temp = i;
                        db.NhanViens.Remove(i);
                        db.SaveChanges();
                    }
                }
            }
        }
        public bool updateNV_BLL(NhanVien nv)
        {
            QLNS db = new QLNS();
            try
            {
                NhanVien nv1 = db.NhanViens.Where(p => p.IdNhanVien == nv.IdNhanVien).FirstOrDefault();
                nv1.IdChucVu = nv.IdChucVu;
                nv1.IdPhongBan = nv.IdPhongBan;
                nv1.NgaySinh = nv.NgaySinh;
                nv1.CMND = nv.CMND;
                nv1.SDT = nv.SDT;
                nv1.QueQuan = nv.QueQuan;
                nv1.SDTNguoiThan = nv.SDTNguoiThan;
                nv1.TenNhanVien = nv.TenNhanVien;
                nv1.TonGiao = nv.TonGiao;
                nv1.DanToc = nv.DanToc;
                nv1.DiaChi = nv.DiaChi;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public List<NhanVien> searchBLL(string search)
        {
            try
            {
                QLNS db = new QLNS();
                return db.NhanViens.Where(p => p.TenNhanVien.Contains(search)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
