    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    public class BLL_Login
    {
        
        private static BLL_Login _Instance;

        public static BLL_Login Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_Login();
                return _Instance;
            }
            private set => _Instance = value;
        }
        private BLL_Login()
        {}
        public void TaoDB()
        {
            DAL.QLNS db = new DAL.QLNS();
        }
        public int CheckLogin(string TenDangNhap, string MatKhau)
        {
            int check = 3;
            try
            {
                DAL.QLNS db = new DAL.QLNS();
                DAL.Account user = db.Accounts.Where(p => p.IdNhanVien == TenDangNhap && p.MatKhau == MatKhau).FirstOrDefault();
                DAL.Admin admin = db.Admins.Where(p => p.IdAdmin == TenDangNhap && p.MatKhau == MatKhau).FirstOrDefault();
                if (admin == null && user == null)
                    check = 3;
                else if (admin != null)
                    check = 2;
                else if (user.KieuPhanQuyen == 1)
                    check = 1;
                else if (user.KieuPhanQuyen == 2)
                    check = 0;
                return check;
            }
            catch (Exception)
            { return check; }
        }
    }
}
