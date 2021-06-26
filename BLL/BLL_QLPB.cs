using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.BLL
{
    class BLL_QLPB
    {
        DAL.QLNS db = new DAL.QLNS();
        private static BLL_QLPB _Instance;

        internal static BLL_QLPB Instance 
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLPB();
                return _Instance;
            }
            private set => _Instance = value; 
        }
        private BLL_QLPB()
        {}

        public List<DTO.PhongBan> Show()
        {
            return DTO.PhongBan.ListPhongBan(db.PhongBans.Select(p => p).ToList());
        }
        public void Del(List<string> id)
        {
            try
            {
                foreach(string i in id)
                {
                    DAL.PhongBan pb_del = db.PhongBans.Where(p => p.IdPhongBan == i).FirstOrDefault();
                    if (pb_del != null)
                        db.PhongBans.Remove(pb_del);
                    List<DAL.NhanVien> nv_inPB = db.NhanViens.Where(p => p.IdPhongBan == i).Select(p => p).ToList();
                    if (nv_inPB.Count != 0)
                        db.NhanViens.RemoveRange(nv_inPB);
                    List<DAL.Account> acc_inPB = db.Accounts.Where(p => p.NhanVien.IdPhongBan == i).Select(p => p).ToList();
                    if (acc_inPB.Count != 0)
                        db.Accounts.RemoveRange(acc_inPB);
                    List<DAL.BangLuong> bl_inPB = db.BangLuongs.Where(p => p.NhanVien.IdPhongBan == i).Select(p => p).ToList();
                    if (bl_inPB.Count != 0)
                        db.BangLuongs.RemoveRange(bl_inPB);
                    List<DAL.QuaTrinhLuong> qtl_inPB = db.QuaTrinhLuongs.Where(p => p.NhanVien.IdPhongBan == i).Select(p => p).ToList();
                    if (qtl_inPB.Count != 0)
                        db.QuaTrinhLuongs.RemoveRange(qtl_inPB);
                }
                db.SaveChanges();
            }catch(Exception)
            { }
        }
        public List<string> GetID()
        {
            List<DAL.PhongBan> pb = new List<DAL.PhongBan>();
            pb = db.PhongBans.Select(p => p).ToList();
            List<string> data = new List<string>();
            foreach (DAL.PhongBan i in pb)
                data.Add(i.IdPhongBan);
            return data;
        }
        public DAL.PhongBan GetPB(string id)
        {
            DAL.PhongBan pb = db.PhongBans.Where(p => p.IdPhongBan == id).FirstOrDefault();
            return pb;
        }
        public void Add(DAL.PhongBan pb)
        {
            db.PhongBans.Add(pb);
            db.SaveChanges();
        }
        public void Update(DAL.PhongBan pb)
        {
            try
            {
                var pb_update = db.PhongBans.Where(p => p.IdPhongBan == pb.IdPhongBan).FirstOrDefault();
                pb_update.IdPhongBan = pb.IdPhongBan;
                pb_update.TenPhongBan = pb.TenPhongBan;
                db.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public List<DTO.NhanVien> Show_NVPB(string idpb)
        {
            return DTO.NhanVien.ListNhanVien(db.NhanViens.Where(p => p.IdPhongBan == idpb).Select(p => p).ToList());
        }
    }
}
