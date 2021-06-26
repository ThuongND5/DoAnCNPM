using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_Account
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_Account _Instance;

        internal static BLL_Account Instance 
        { 
            get 
            {
                if (_Instance == null)
                    _Instance = new BLL_Account();
                return _Instance;
            } 
            private set => _Instance = value; 
        }
        private BLL_Account()
        { }

        public void Add_Acc(DAL.Account ac)
        {
            try
            {
                db.Accounts.Add(ac);
                db.SaveChanges();
            }
            catch(Exception)
            {}
        }
        public void Add_BangLuong(DAL.BangLuong bl)
        {
            try
            {
                db.BangLuongs.Add(bl);
                db.SaveChanges();
            }
            catch(Exception)
            {}
        }

        //DoiMatKhau
        public void UpdateAccNV(string id, string pass)
        {
            var acc = db.Accounts.Where(p => p.IdNhanVien == id).FirstOrDefault();
            acc.MatKhau = pass;
            db.SaveChanges();
        }
        public void UpdateAdmin(string id, string pass)
        {
            var admin = db.Admins.Where(p => p.IdAdmin == id).FirstOrDefault();
            admin.MatKhau = pass;
            db.SaveChanges();
        }
        public bool CheckMatKhau_NV(string id, string pass)
        {
            var acc = db.Accounts.Where(p => p.IdNhanVien == id).FirstOrDefault();
            string pass_acc = acc.MatKhau;
            if (pass_acc == pass)
                return true;
            else
                return false;
        }
        public bool CheckMatKhau_Admin(string id, string pass)
        {
            var acc = db.Admins.Where(p => p.IdAdmin == id).FirstOrDefault();
            string pass_acc = acc.MatKhau;
            if (pass_acc == pass)
                return true;
            else
                return false;
        }
    }
}
