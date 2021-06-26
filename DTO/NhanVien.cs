using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class NhanVien
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu{ get; set; }
        public string SDT { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string DanToc { get; set; }
        public bool TonGiao { get; set; }
        public string SDTNguoiThan { get; set; }
        public static NhanVien ViewNhanVien(DAL.NhanVien nv)
        {
            NhanVien x = new NhanVien
            {
                IdNhanVien = nv.IdNhanVien,
                TenNhanVien = nv.TenNhanVien,
                NgaySinh = Convert.ToDateTime(nv.NgaySinh),
                GioiTinh = nv.GioiTinh,
                PhongBan = nv.PhongBan.TenPhongBan,
                ChucVu = nv.ChucVu.TenChucVu,
                SDT = nv.SDT,
                CMND = nv.CMND,
                DiaChi = nv.DiaChi,
                QueQuan = nv.QueQuan,
                DanToc = nv.DanToc,
                TonGiao = nv.TonGiao,
                SDTNguoiThan = nv.SDTNguoiThan
            };
            return x;
        }
        public static List<NhanVien> ListNhanVien(List<DAL.NhanVien> nv)
        {
            List<NhanVien> data = new List<NhanVien>();
            foreach (DAL.NhanVien i in nv)
                data.Add(ViewNhanVien(i));
            return data;
        }
    }
}
