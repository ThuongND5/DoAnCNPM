using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DAL
{
    public class TaoRecords : DropCreateDatabaseIfModelChanges<QLNS>// CreateDatabaseIfNotExists<QLNS>
    {
        protected override void Seed(QLNS context)
        {
            context.ChucVus.Add(new ChucVu
            {
                IdChucVu = 1,
                TenChucVu = "Quản Lí"
            });
            context.ChucVus.Add(new ChucVu
            {
                IdChucVu = 2,
                TenChucVu = "Nhân Viên"
            });

            //Khởi Tạo Phòng Ban
            context.PhongBans.Add(new PhongBan
            {
                IdPhongBan = "1",
                TenPhongBan = "Ban Quản Lý"
            });
            context.PhongBans.Add(new PhongBan
            {
                IdPhongBan = "2",
                TenPhongBan = "Tổ Nhân Viên"
            });
            context.PhongBans.Add(new PhongBan
            {
                IdPhongBan = "3",
                TenPhongBan = "Tổ Bảo Vệ"
            });

            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien="102001",
                TenNhanVien = "Ho Quang Thang",
                GioiTinh = true,
                NgaySinh = DateTime.ParseExact("20/11/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "033467216",
                CMND = "033687",
                IdChucVu = 1,
                IdPhongBan = "2",
                SDTNguoiThan = "078187",
                DanToc = "Kinh",
                TonGiao = true,
                DiaChi = "Đà Nẵng",
                QueQuan = "Quảng Nam",

            });
            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien = "102002",
                TenNhanVien = "Nguyen Phương Nam",
                GioiTinh = true,
                NgaySinh = DateTime.ParseExact("17/08/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "03323788",
                CMND = "0625587",
                IdChucVu = 1,
                IdPhongBan = "1",
                SDTNguoiThan = "078187",
                DanToc = "Kinh",
                TonGiao = true,
                DiaChi = "Đà Nẵng",
                QueQuan = "Quảng Nam",

            });
            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien = "102003",
                TenNhanVien = "Ho Thi Thuy",
                GioiTinh = false,
                NgaySinh = DateTime.ParseExact("20/7/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "033467216",
                CMND = "033687",
                IdChucVu = 1,
                IdPhongBan = "3",
                SDTNguoiThan = "078187",
                DanToc = "Kinh",
                TonGiao = false,
                DiaChi = "Đà Nẵng",
                QueQuan = "Quảng Nam",

            });
            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien = "102004",
                TenNhanVien = "Hoàng Huy Cường",
                GioiTinh = false,
                NgaySinh = DateTime.ParseExact("28/11/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "03902386",
                CMND = "033837",
                IdChucVu = 1,
                IdPhongBan = "2",
                SDTNguoiThan = "783263297",
                DanToc = "Kinh",
                TonGiao = false,
                DiaChi = "Đà Nẵng",
                QueQuan = "Đà Nẵng",

            });
            
            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien = "102005",
                TenNhanVien = "Trần Huy Tùng",
                GioiTinh = false,
                NgaySinh = DateTime.ParseExact("07/12/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "073283806",
                CMND = "073297",
                IdChucVu = 2,
                IdPhongBan = "2",
                SDTNguoiThan = "06383",
                DanToc = "Kinh",
                TonGiao = true,
                DiaChi = "Đà Nẵng",
                QueQuan = "Đà Nẵng",

            });

            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien = "102006",
                TenNhanVien = "Nguyễn Quang Huy",
                GioiTinh = false,
                NgaySinh = DateTime.ParseExact("02/01/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "785324",
                CMND = "63873",
                IdChucVu = 2,
                IdPhongBan = "2",
                SDTNguoiThan = "062297",
                DanToc = "Kinh",
                TonGiao = false,
                DiaChi = "Đà Nẵng",
                QueQuan = "Đà Nẵng",
            });
            context.NhanViens.Add(new NhanVien
            {
                IdNhanVien = "102007",
                TenNhanVien = "Nguyễn Duy Thuong",
                GioiTinh = false,
                NgaySinh = DateTime.ParseExact("01/11/2000", "d/M/yyyy", CultureInfo.InvariantCulture),
                SDT = "785324",
                CMND = "63873",
                IdChucVu = 1,
                IdPhongBan = "1",
                SDTNguoiThan = "062297",
                DanToc = "Kinh",
                TonGiao = false,
                DiaChi = "Đà Nẵng",
                QueQuan = "Quang Nam",
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102001",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 1
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102002",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 2
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102003",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 2
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102004",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 2
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102005",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 2
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102006",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 2
            });
            context.Accounts.Add(new Account
            {
                IdNhanVien = "102007",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("123"),
                KieuPhanQuyen = 2
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102001",
                MucLuongCoBan = 250000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102002",
                MucLuongCoBan = 100000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102003",
                MucLuongCoBan = 120000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102004",
                MucLuongCoBan = 130000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102005",
                MucLuongCoBan = 90000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102006",
                MucLuongCoBan = 200000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.BangLuongs.Add(new BangLuong
            {
                IdNhanVien = "102007",
                MucLuongCoBan = 250000,
                SoNgayLam = 0,
                TongTienLuong = 0,
            });
            context.Admins.Add(new Admin
            {
                IdAdmin = "999",
                TenAdmin = "Hoai Phuong Dang",
                MatKhau = BLL.BLL_MaHoaMK.MD5Hash("999")
            });
        }
    }
}
