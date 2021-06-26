using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCNPM
{
    public partial class FAdmin : Form
    {
        private string _iDlogin;

        public string IDlogin { get => _iDlogin; set => _iDlogin = value; }

        public FAdmin(string m)
        {
            IDlogin = m;
            InitializeComponent();
        }
        private void FAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDoiMatKhau f = new FDoiMatKhau(IDlogin, 2);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void FAdmin_Load(object sender, EventArgs e)
        {
            this.QLHS_cmbTenPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QLHS_cmbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            SetDGV_QLHS();
            SetCBBPhongBan();
            SetCBBChucVu();
            SetDGV_QLPB();
            SetDGV_RP();
            this.Cmb_DGNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Cmb_DGNV.SelectedIndex = 0;
            SetDGV_QLL();
            HDNV_cmbThang.SelectedIndex = 0;
            HDNV_cmbonloff.SelectedIndex = 0;
        }

        /*----------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------QUẢN LÍ HỒ SƠ------------------------------------------*/
        public void SetDGV_QLHS()
        {
            dgrviewQLHS.DataSource = BLL.BLL_QLHS.Instance.Show_QLHS();
        }
        public void SetCBBPhongBan()
        {
            if (QLHS_cmbTenPB.Items != null)
            {
                QLHS_cmbTenPB.Items.Clear();
            }
            foreach (DAL.PhongBan i in BLL.BLL_QLHS.Instance.SetPhongBan())
            {
                QLHS_cmbTenPB.Items.Add(new DTO.CBBItem
                {
                    Text = i.TenPhongBan,
                    Value = Convert.ToInt32(i.IdPhongBan)
                });
            }
        }
        public void SetCBBChucVu()
        {
            if (QLHS_cmbChucVu.Items != null)
            {
                QLHS_cmbChucVu.Items.Clear();
            }
            foreach (DAL.ChucVu i in BLL.BLL_QLHS.Instance.SetChucVu())
            {
                QLHS_cmbChucVu.Items.Add(new DTO.CBBItem
                {
                    Text = i.TenChucVu,
                    Value = i.IdChucVu
                });
            }
        }
        public void FormAdd_HS()
        {
            List<string> ms = new List<string>();
            int SoChen = 0;
            int MaSo = 0;
            List<string> get = new List<string>();
            get = BLL.BLL_QLHS.Instance.GetID();
            for (int i = 0; i < BLL.BLL_QLHS.Instance.GetID().Count; i++)
            {
                ms.Add(get[i]);
            }
            ms.Sort();
            for (int i = 1; i < ms.Count; i++)
            {
                int kc = Convert.ToInt32(ms[i]) - Convert.ToInt32(ms[i - 1]);
                if (kc == 1)
                {
                    MaSo = Convert.ToInt32(ms[ms.Count - 1]) + 1;
                }
                else
                {
                    SoChen = Convert.ToInt32(ms[i - 1]) + 1;
                    break;
                }
            }
            if (SoChen != 0)
                QLHS_txtbIDNhanVien.Text = SoChen.ToString();
            else
                QLHS_txtbIDNhanVien.Text = MaSo.ToString();
        }
        public void FormNull_HS()
        {
            QLHS_txtbIDNhanVien.Text = null;
            QLHS_txtbHoTenNV.Text = null;
            QLHS_dtNgaysinh.Value = DateTime.Today;
            QLHS_rbtnNam.Checked = false;
            QLHS_rbtnNu.Checked = false;
            QLHS_cmbTenPB.SelectedIndex = -1;
            QLHS_cmbChucVu.SelectedIndex = -1;
            QLHS_txtbSDT.Text = null;
            QLHS_txtbCMND.Text = null;
            QLHS_txtbDC.Text = null;
            QLHS_txtbQueQuan.Text = null;
            QLHS_txtbDanToc.Text = null;
            QLHS_txtbTongiao.Text = null;
            QLHS_txtbSDTnguoithan.Text = null;

        }
        public void FormUpdate_HS()
        {
            DataGridViewSelectedRowCollection r = dgrviewQLHS.SelectedRows;
            if (r.Count == 1)
            {
                string id = r[0].Cells[0].Value.ToString();
                DAL.NhanVien nv = BLL.BLL_QLHS.Instance.GetNV(id);
                QLHS_txtbIDNhanVien.Text = id.ToString();
                QLHS_txtbHoTenNV.Text = nv.TenNhanVien;
                QLHS_dtNgaysinh.Value = Convert.ToDateTime(nv.NgaySinh);
                if (Convert.ToBoolean(nv.GioiTinh))
                    QLHS_rbtnNam.Checked = true;
                else
                    QLHS_rbtnNu.Checked = true;
                foreach (DTO.CBBItem item in QLHS_cmbTenPB.Items)
                {
                    if (item.Value.ToString() == nv.IdPhongBan)
                        QLHS_cmbTenPB.SelectedIndex = QLHS_cmbTenPB.Items.IndexOf(item);
                }
                foreach (DTO.CBBItem item in QLHS_cmbChucVu.Items)
                {
                    if (item.Value == nv.IdChucVu)
                        QLHS_cmbChucVu.SelectedIndex = QLHS_cmbChucVu.Items.IndexOf(item);
                }
                QLHS_txtbSDT.Text = nv.SDT;
                QLHS_txtbCMND.Text = nv.CMND;
                QLHS_txtbDC.Text = nv.DiaChi;
                QLHS_txtbQueQuan.Text = nv.QueQuan;
                QLHS_txtbDanToc.Text = nv.DanToc;
                if (nv.TonGiao == false)
                    QLHS_txtbTongiao.Text = "Không";
                else
                    QLHS_txtbTongiao.Text = "Có";
                QLHS_txtbSDTnguoithan.Text = nv.SDTNguoiThan;
            }
        }
        private void QLHS_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection r = dgrviewQLHS.SelectedRows;
                if (r.Count == 0)
                    MessageBox.Show("Vui lòng chọn Nhân Viên bạn muốn xóa!");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        List<string> id = new List<string>();
                        foreach (DataGridViewRow i in r)
                            id.Add(i.Cells["Id"].Value.ToString());
                        BLL.BLL_QLHS.Instance.Del_HS(id);
                        MessageBox.Show("Xóa thành công!");
                        SetDGV_QLHS();
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
            }
            catch (Exception)
            { MessageBox.Show("Lỗi!"); }
            FAdmin_Load(sender, e);
        }
        bool checkadd_HS = false;
        bool checkupdate_HS = false;
        private void QLHS_btnThem_Click(object sender, EventArgs e)
        {
            bool openFAccount = false;
            string idNewAccount = "";
            int PhanQuyen = 0;
            if (checkadd_HS == false)
            {
                FormAdd_HS();
                checkadd_HS = true;
                checkupdate_HS = false;
            }
            else
            {
                try
                {
                    checkadd_HS = false;
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DAL.NhanVien nv = new DAL.NhanVien();
                        if (QLHS_dtNgaysinh.Value.Date > DateTime.Now)
                        {
                            MessageBox.Show("Lỗi ngày sinh! Vui lòng kiểm tra lại");
                            checkadd_HS = true;
                        }
                        else
                        {
                            nv.NgaySinh = QLHS_dtNgaysinh.Value;
                            nv.IdNhanVien = QLHS_txtbIDNhanVien.Text;
                            nv.TenNhanVien = QLHS_txtbHoTenNV.Text;
                            nv.GioiTinh = QLHS_rbtnNam.Checked;
                            int idpb = ((DTO.CBBItem)QLHS_cmbTenPB.SelectedItem).Value;
                            nv.IdPhongBan = idpb.ToString();
                            nv.IdChucVu = ((DTO.CBBItem)QLHS_cmbChucVu.SelectedItem).Value;
                            nv.SDT = QLHS_txtbSDT.Text;
                            nv.CMND = QLHS_txtbCMND.Text;
                            nv.DiaChi = QLHS_txtbDC.Text;
                            nv.QueQuan = QLHS_txtbQueQuan.Text;
                            nv.DanToc = QLHS_txtbDanToc.Text;
                            if (QLHS_txtbTongiao.Text == "Không")
                                nv.TonGiao = false;
                            else nv.TonGiao = true;
                            nv.SDTNguoiThan = QLHS_txtbSDTnguoithan.Text;
                            BLL.BLL_QLHS.Instance.Add_HS(nv);
                            idNewAccount = nv.IdNhanVien;
                            PhanQuyen = nv.IdChucVu;
                            MessageBox.Show("Thêm thành công!");
                            SetDGV_QLHS();
                            checkadd_HS = false;
                            openFAccount = true;
                            FormNull_HS();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { openFAccount = false; }
            }
                catch (Exception)
            { MessageBox.Show("Vui lòng kiểm tra lại dữ liệu!"); }
        }
            if (openFAccount == true)
            {
                FAccount f = new FAccount(idNewAccount, PhanQuyen);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            FAdmin_Load(sender, e);
        }
        private void QLHS_btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgrviewQLHS.SelectedRows;
            if (checkupdate_HS == false)
            {
                if (r.Count == 0)
                    MessageBox.Show("Vui lòng chọn Nhân Viên update!");
                else if (r.Count != 1)
                    MessageBox.Show("Vui lòng chỉ chọn 1 Nhân Viên!");
                else
                {
                    FormUpdate_HS();
                    checkupdate_HS = true;
                    checkadd_HS = false;
                }
            }
            else
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DAL.NhanVien nv = new DAL.NhanVien();
                        nv.IdNhanVien = QLHS_txtbIDNhanVien.Text;
                        nv.TenNhanVien = QLHS_txtbHoTenNV.Text;
                        nv.NgaySinh = QLHS_dtNgaysinh.Value;
                        nv.GioiTinh = QLHS_rbtnNam.Checked;
                        nv.IdChucVu = ((DTO.CBBItem)QLHS_cmbChucVu.SelectedItem).Value;
                        nv.IdPhongBan = ((DTO.CBBItem)QLHS_cmbTenPB.SelectedItem).Value.ToString();
                        nv.SDT = QLHS_txtbSDT.Text;
                        nv.CMND = QLHS_txtbCMND.Text;
                        nv.DiaChi = QLHS_txtbDC.Text;
                        nv.QueQuan = QLHS_txtbQueQuan.Text;
                        nv.DanToc = QLHS_txtbDanToc.Text;
                        if (QLHS_txtbTongiao.Text == "Không")
                            nv.TonGiao = false;
                        else
                            nv.TonGiao = true;
                        nv.SDTNguoiThan = QLHS_txtbSDTnguoithan.Text;
                        BLL.BLL_QLHS.Instance.Update_HS(nv);
                        MessageBox.Show("Sửa thành công!");
                        SetDGV_QLHS();
                        checkupdate_HS = false;
                        FormNull_HS();
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
            }
        }
        private void dgrviewQLHS_MouseClick(object sender, MouseEventArgs e)
        {
            FormNull_HS();
            checkupdate_HS = false;
            checkadd_HS = false;
        }
        private void QLHS_btnTiemKiem_Click(object sender, EventArgs e)
        {
            if (QLHS_txtbIDNVTK.Text == "")
                MessageBox.Show("Vui lòng nhập Nhân Viên muốn tìm kiếm!");
            else
                dgrviewQLHS.DataSource = BLL.BLL_QLHS.Instance.Search_HS(QLHS_txtbIDNVTK.Text);
        }

        /*----------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------QUẢN LÍ PHÒNG BAN------------------------------------------*/
        public void SetDGV_QLPB()
        {
            dgrviewQLPB.DataSource = BLL.BLL_QLPB.Instance.Show();
        }
        private void QLPB_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection r = dgrviewQLPB.SelectedRows;
                if (r.Count == 0)
                    MessageBox.Show("Vui lòng chọn Phòng Ban bạn muốn xóa!");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        List<string> id = new List<string>();
                        foreach (DataGridViewRow i in r)
                            id.Add(i.Cells[0].Value.ToString());
                        BLL.BLL_QLPB.Instance.Del(id);
                        MessageBox.Show("Xóa thành công!");
                        SetDGV_QLPB();
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
            }
            catch (Exception)
            { MessageBox.Show("Lỗi!"); }
            FAdmin_Load(sender, e);
        }
        public void FormAdd_QLPB()
        {
            List<string> ms = new List<string>();
            int SoChen = 0;
            int MaSo = 0;
            List<string> get = new List<string>();
            get = BLL.BLL_QLPB.Instance.GetID();
            for (int i = 0; i < BLL.BLL_QLPB.Instance.GetID().Count; i++)
            {
                ms.Add(get[i]);
            }
            ms.Sort();
            for (int i = 1; i < ms.Count; i++)
            {
                int kc = Convert.ToInt32(ms[i]) - Convert.ToInt32(ms[i - 1]);
                if (kc == 1)
                {
                    MaSo = Convert.ToInt32(ms[ms.Count - 1]) + 1;
                }
                else
                {
                    SoChen = Convert.ToInt32(ms[i - 1]) + 1;
                    break;
                }
            }
            if (SoChen != 0)
                QLPB_txtbIDPB.Text = SoChen.ToString();
            else
                QLPB_txtbIDPB.Text = MaSo.ToString();
        }
        public void FormUpdate_QLPB()
        {
            DataGridViewSelectedRowCollection r = dgrviewQLPB.SelectedRows;
            if (r.Count == 1)
            {
                string id = r[0].Cells[0].Value.ToString();
                DAL.PhongBan pb = BLL.BLL_QLPB.Instance.GetPB(id);
                QLPB_txtbIDPB.Text = pb.IdPhongBan.ToString();
                QLPB_txtbTenPB.Text = pb.TenPhongBan.ToString();
            }
        }
        public void FormNull_PB()
        {
            QLPB_txtbIDPB.Text = "";
            QLPB_txtbTenPB.Text = "";
        }
        bool checkadd_PB = false;
        bool checkupdate_PB = false;
        private void QLPB_btnThem_Click(object sender, EventArgs e)
        {
            if (checkadd_PB == false)
            {
                FormAdd_QLPB(); ;
                checkadd_PB = true;
                checkupdate_PB = false;
            }
            else
            {
                try
                {
                    checkadd_PB = false;
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DAL.PhongBan pb = new DAL.PhongBan();
                        pb.IdPhongBan = QLPB_txtbIDPB.Text.ToString();
                        pb.TenPhongBan = QLPB_txtbTenPB.Text;
                        BLL.BLL_QLPB.Instance.Add(pb);
                        MessageBox.Show("Thêm thành công!");
                        SetDGV_QLPB();
                        checkadd_PB = false;
                        FormNull_PB();
                    }
                    else if (dialogResult == DialogResult.No)
                    {}
                }
                catch (Exception)
                { MessageBox.Show("Vui lòng kiểm tra lại dữ liệu!"); }
            }
        }
        private void QLPB_btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgrviewQLPB.SelectedRows;
            if (checkupdate_PB == false)
            {
                if (r.Count == 0)
                    MessageBox.Show("Vui lòng chọn Phòng Ban update!");
                else if (r.Count != 1)
                    MessageBox.Show("Vui lòng chỉ chọn 1 Phòng Ban!");
                else
                {
                    FormUpdate_QLPB();
                    checkupdate_PB = true;
                    checkadd_PB = false;
                }
            }
            else
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DAL.PhongBan pb = new DAL.PhongBan();
                        pb.IdPhongBan = QLPB_txtbIDPB.Text;
                        pb.TenPhongBan = QLPB_txtbTenPB.Text;
                        BLL.BLL_QLPB.Instance.Update(pb);
                        MessageBox.Show("Sửa thành công!");
                        SetDGV_QLPB();
                        checkupdate_PB = false;
                        FormNull_PB();
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
            }
        }
        private void dgrviewQLPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormNull_PB();
            checkupdate_PB = false;
            checkadd_PB = false;
            string id = dgrviewQLPB.CurrentRow.Cells["IdPhongBan"].Value.ToString();
            dgrviewQLPB_NV.DataSource = BLL.BLL_QLPB.Instance.Show_NVPB(id);
        }
        /*----------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------Đánh Giá Nhân Viên----------------------------------------*/
        public void SetDGV_QLKT()
        {
            dgrviewDG.DataSource = BLL.BLL_QLKT.Instance.Show_QLKT_AD();
        }
        public void SetDGV_QLKL()
        {
            dgrviewDG.DataSource = BLL.BLL_QLKL.Instance.Show_QLKL_AD();
        }
        private void Cmb_DGNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_DGNV.Text == "Khen Thưởng")
                dgrviewDG.DataSource = BLL.BLL_QLKT.Instance.Show_QLKT_AD();
            else if (Cmb_DGNV.Text == "Kỉ Luật")
                dgrviewDG.DataSource = BLL.BLL_QLKL.Instance.Show_QLKL_AD();
        }
        public void FormAdd_DG()
        {
            DG_txtbIdNV.Text = "";
            DG_txtbHinhThuc.Text = "";
            DG_txtbLyDo.Text = "";
            DG_dtNgayDanhGia.Value = DateTime.Today;
        }
        public void FormUpdate_DG()
        {
            DataGridViewSelectedRowCollection r = dgrviewDG.SelectedRows;
            if (r.Count == 1)
            {
                if (Cmb_DGNV.Text == "Khen Thưởng")
                {
                    string id = r[0].Cells[0].Value.ToString();
                    DateTime dt = Convert.ToDateTime(r[0].Cells[2].Value.ToString());
                    string ld = r[0].Cells[3].Value.ToString();
                    string ht = r[0].Cells[4].Value.ToString();
                    DAL.KhenThuong kt = BLL.BLL_QLKT.Instance.GetKhenThuong(id, dt, ld, ht);
                    DG_txtbIdNV.Text = kt.IdNhanVien.ToString();
                    DG_dtNgayDanhGia.Value = kt.NgayKhenThuong;
                    DG_txtbLyDo.Text = kt.LyDoKhenThuong.ToString();
                    DG_txtbHinhThuc.Text = kt.HinhThucKhenThuong.ToString();
                }
                else if (Cmb_DGNV.Text == "Kỉ Luật")
                {
                    string id = r[0].Cells[0].Value.ToString();
                    DateTime dt = Convert.ToDateTime(r[0].Cells[2].Value.ToString());
                    string ld = r[0].Cells[3].Value.ToString();
                    string ht = r[0].Cells[4].Value.ToString();
                    DAL.KiLuat kt = BLL.BLL_QLKL.Instance.GetKiLuat(id, dt, ld, ht);
                    DG_txtbIdNV.Text = kt.IdNhanVien.ToString();
                    DG_dtNgayDanhGia.Value = kt.NgayKiLuat;
                    DG_txtbLyDo.Text = kt.LyDoKiLuat.ToString();
                    DG_txtbHinhThuc.Text = kt.HinhThucKiLuat.ToString();
                }
            }
        }
        bool checkadd_DG = true;
        bool checkupdate_DG = false;
        private void DG_btnThem_Click(object sender, EventArgs e)
        {
            if (DG_txtbIdNV.Text == "" || DG_txtbHinhThuc.Text == "" || DG_txtbLyDo.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else
            {
                if (checkadd_DG == false)
                {
                    FormAdd_DG();
                    checkadd_DG = true;
                    checkupdate_DG = false;
                }
                else
                {
                    if (Cmb_DGNV.Text == "Khen Thưởng")
                    {
                        if (BLL.BLL_QLKT.Instance.ID_inDB(DG_txtbIdNV.Text) == true)
                        {
                            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                DAL.KhenThuong kt = new DAL.KhenThuong();
                                kt.IdNhanVien = DG_txtbIdNV.Text.ToString();
                                kt.NgayKhenThuong = DG_dtNgayDanhGia.Value.Date;
                                kt.LyDoKhenThuong = DG_txtbLyDo.Text;
                                kt.HinhThucKhenThuong = DG_txtbHinhThuc.Text;
                                BLL.BLL_QLKT.Instance.Add_KT(kt);
                                SetDGV_QLKT();
                                FormAdd_DG();
                            }
                            else if (dialogResult == DialogResult.No)
                            { }
                        }
                        else
                        { MessageBox.Show("Lỗi dữ liệu!"); }
                    }
                    else if (Cmb_DGNV.Text == "Kỉ Luật")
                    {
                        if (BLL.BLL_QLKL.Instance.ID_inDB(DG_txtbIdNV.Text) == true)
                        {
                            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                DAL.KiLuat kl = new DAL.KiLuat();
                                kl.IdNhanVien = DG_txtbIdNV.Text.ToString();
                                kl.NgayKiLuat = DG_dtNgayDanhGia.Value.Date;
                                kl.LyDoKiLuat = DG_txtbLyDo.Text;
                                kl.HinhThucKiLuat = DG_txtbHinhThuc.Text;
                                BLL.BLL_QLKL.Instance.Add_KL(kl);
                                SetDGV_QLKL();
                                FormAdd_DG();
                            }
                            else if (dialogResult == DialogResult.No)
                            { }
                        }
                        else
                        { MessageBox.Show("Lỗi dữ liệu!"); }
                    }
                }
            }
        }

        private void DG_btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgrviewDG.SelectedRows;
            if (checkupdate_DG == false)
            {
                if (r.Count == 0)
                    MessageBox.Show("Vui lòng chọn row update!");
                else if (r.Count != 1)
                    MessageBox.Show("Vui lòng chỉ chọn 1 row!");
                else
                {
                    FormUpdate_DG();
                    checkupdate_DG = true;
                    checkadd_DG = false;
                }
            }
            else
            {
                if (Cmb_DGNV.Text == "Khen Thưởng")
                {
                    if (BLL.BLL_QLKT.Instance.ID_inDB(DG_txtbIdNV.Text) == true)
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string id = r[0].Cells[0].Value.ToString();
                            DateTime dt = Convert.ToDateTime(r[0].Cells[2].Value.ToString());
                            string ld = r[0].Cells[3].Value.ToString();
                            string ht = r[0].Cells[4].Value.ToString();
                            DAL.KhenThuong kt_chuaupdate = BLL.BLL_QLKT.Instance.GetKhenThuong(id, dt, ld, ht);
                            DAL.KhenThuong kt_update = new DAL.KhenThuong();
                            kt_update.IdNhanVien = DG_txtbIdNV.Text;
                            kt_update.NgayKhenThuong = DG_dtNgayDanhGia.Value.Date;
                            kt_update.LyDoKhenThuong = DG_txtbLyDo.Text;
                            kt_update.HinhThucKhenThuong = DG_txtbHinhThuc.Text;
                            BLL.BLL_QLKT.Instance.Update_KT(kt_update, kt_chuaupdate);
                            SetDGV_QLKT();
                            checkupdate_DG = false;
                            FormAdd_DG();
                        }
                        else if (dialogResult == DialogResult.No)
                        { }
                    }
                    else
                    { MessageBox.Show("Lỗi dữ liệu!"); }
                }
                else if (Cmb_DGNV.Text == "Kỉ Luật")
                {
                    if (BLL.BLL_QLKL.Instance.ID_inDB(DG_txtbIdNV.Text) == true)
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string id = r[0].Cells[0].Value.ToString();
                            DateTime dt = Convert.ToDateTime(r[0].Cells[2].Value.ToString());
                            string ld = r[0].Cells[3].Value.ToString();
                            string ht = r[0].Cells[4].Value.ToString();
                            DAL.KiLuat kl_chuaupdate = BLL.BLL_QLKL.Instance.GetKiLuat(id, dt, ld, ht);
                            DAL.KiLuat kl_update = new DAL.KiLuat();
                            kl_update.IdNhanVien = DG_txtbIdNV.Text;
                            kl_update.NgayKiLuat = DG_dtNgayDanhGia.Value.Date;
                            kl_update.LyDoKiLuat = DG_txtbLyDo.Text;
                            kl_update.HinhThucKiLuat = DG_txtbHinhThuc.Text;
                            BLL.BLL_QLKL.Instance.Update_KL(kl_update, kl_chuaupdate);
                            SetDGV_QLKL();
                            checkupdate_DG = false;
                            FormAdd_DG();
                        }
                        else if (dialogResult == DialogResult.No)
                        { }
                    }
                    else
                    { MessageBox.Show("Lỗi dữ liệu!"); }
                }
            }
        }
        private void dgrviewDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormAdd_DG();
            checkupdate_DG = false;
        }
        private void DG_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection r = dgrviewDG.SelectedRows;
                if (r.Count == 0)
                    MessageBox.Show("Vui lòng chọn row bạn muốn xóa!");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Cmb_DGNV.Text == "Khen Thưởng")
                        {
                            List<DAL.KhenThuong> data = new List<DAL.KhenThuong>();
                            foreach (DataGridViewRow i in r)
                            {
                                DAL.KhenThuong kt = new DAL.KhenThuong();
                                kt.IdNhanVien = i.Cells[0].Value.ToString();
                                kt.NgayKhenThuong = Convert.ToDateTime(i.Cells[2].Value.ToString());
                                kt.LyDoKhenThuong = i.Cells[3].Value.ToString();
                                kt.HinhThucKhenThuong = i.Cells[4].Value.ToString();
                                data.Add(kt);
                            }
                            BLL.BLL_QLKT.Instance.Del_KT(data);
                            MessageBox.Show("Xóa thành công!");
                            SetDGV_QLKT();
                        }
                        else if (Cmb_DGNV.Text == "Kỉ Luật")
                        {
                            List<DAL.KiLuat> data = new List<DAL.KiLuat>();
                            foreach (DataGridViewRow i in r)
                            {
                                DAL.KiLuat kl = new DAL.KiLuat();
                                kl.IdNhanVien = i.Cells[0].Value.ToString();
                                kl.NgayKiLuat = Convert.ToDateTime(i.Cells[1].Value.ToString());
                                kl.LyDoKiLuat = i.Cells[2].Value.ToString();
                                kl.HinhThucKiLuat = i.Cells[3].Value.ToString();
                                data.Add(kl);
                            }
                            BLL.BLL_QLKL.Instance.Del_KL(data);
                            MessageBox.Show("Xóa thành công!");
                            SetDGV_QLKL();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
            }
            catch (Exception)
            { MessageBox.Show("Lỗi!"); }
        }
        private void DG_btnTimKiem_Click(object sender, EventArgs e)
        {
            if (DG_txtbIDNVTK.Text == "")
                MessageBox.Show("Vui lòng nhập Nhân Viên muốn tìm kiếm!");
            else
            {
                if (Cmb_DGNV.Text == "Khen Thưởng")
                    dgrviewDG.DataSource = BLL.BLL_QLKT.Instance.Search_KT_QL(DG_txtbIDNVTK.Text);
                else if (Cmb_DGNV.Text == "Kỉ Luật")
                    dgrviewDG.DataSource = BLL.BLL_QLKL.Instance.Search_KL_QL(DG_txtbIDNVTK.Text);
            }
        }
        /*----------------------------------------------------------------------------------------------------------------*/
        /*-------------------------------------------QUẢN LÍ LƯƠNG--------------------------------------------------------*/
        public void SetDGV_QLL()
        {
            dgrviewQLL.DataSource = BLL.BLL_QLL.Instance.Show_QLL_AD();
        }
        public void FormNull_QLL()
        {
            QLL_txtbIDNV.Text = null;
            QLL_txtbMucLuong.Text = null;
            QLL_txtbTongNgayLam.Text = null;
            QLL_txtbTongTienLuong.Text = null;
        }
        public void FormUpdate_QLL()
        {
            DataGridViewSelectedRowCollection r = dgrviewQLL.SelectedRows;
            if (r.Count == 1)
            {
                string id = r[0].Cells["IdNhanVien"].Value.ToString();
                DAL.BangLuong bl = BLL.BLL_QLL.Instance.GetBangLuong(id);
                QLL_txtbIDNV.Text = id.ToString();
                QLL_txtbMucLuong.Text = bl.MucLuongCoBan.ToString();
                QLL_txtbTongNgayLam.Text = bl.SoNgayLam.ToString();
                QLL_txtbTongTienLuong.Text = (Convert.ToInt32(bl.MucLuongCoBan.ToString()) * Convert.ToInt32(bl.SoNgayLam.ToString())).ToString();
            }
        }
        private void dgrviewQLL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormUpdate_QLL();
        }
        private void QLL_btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DAL.BangLuong bl = new DAL.BangLuong();
                    bl.IdNhanVien = QLL_txtbIDNV.Text.ToString();
                    bl.MucLuongCoBan = Convert.ToInt32(QLL_txtbMucLuong.Text.ToString());
                    bl.SoNgayLam = Convert.ToInt32(QLL_txtbTongNgayLam.Text.ToString());
                    bl.TongTienLuong = Convert.ToInt32(QLL_txtbMucLuong.Text.ToString()) * Convert.ToInt32(QLL_txtbTongNgayLam.Text.ToString());
                    BLL.BLL_QLL.Instance.Update(bl);
                    SetDGV_QLL();
                    FormNull_QLL();
                }
                else if (dialogResult == DialogResult.No)
                { }
            }
            catch (Exception)
            { MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập!"); }
        }

        private void QLL_btnTimKiem_Click(object sender, EventArgs e)
        {
            if (QLL_txtbIDNVTK.Text == "")
                MessageBox.Show("Vui lòng nhập Nhân Viên muốn tìm kiếm!");
            else
                dgrviewQLL.DataSource = BLL.BLL_QLL.Instance.Search_AD(QLL_txtbIDNVTK.Text);
        }

        private void QLL_btnTinh_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn tính lương cho tháng này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int tong = 0;
                foreach (DataGridViewRow i in dgrviewQLL.Rows)
                {
                    DAL.BangLuong bl = BLL.BLL_QLL.Instance.GetBangLuong(i.Cells[0].Value.ToString());
                    BLL.BLL_QLL.Instance.TinhLuong(bl);
                    tong = tong + Convert.ToInt32(i.Cells["TongTienLuong"].Value.ToString());
                }
                MessageBox.Show("Tổng tiền lương tháng này là: " + tong.ToString());
            }
            else if (dialogResult == DialogResult.No)
            { }
            FAdmin_Load(sender, e);
        }

        private void clearQTT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn clear QTT?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BLL.BLL_QLL.Instance.Del_QTT();
                MessageBox.Show("Xong!");
            }
            else if (dialogResult == DialogResult.No)
            { }
        }

        /*----------------------------------------------------------------------------------------------------------------*/
        /*-------------------------------------------QUẢN LÍ HOẠT ĐỘNG NHÂN VIÊN------------------------------------------*/
        bool month = false;
        bool lam = false;
        private void HDNV_cmbonloff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HDNV_cmbonloff.SelectedItem.ToString() == "Onl")
                lam = true;
            else
                lam = false;
            SetDGV_HDNV();
        }

        private void HDNV_cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HDNV_cmbThang.SelectedItem.ToString() == "Tháng nay")
                month = true;
            else
                month = false;
            SetDGV_HDNV();
        }
        public void SetDGV_HDNV()
        {
            if(lam == true && month == true)
                dgrviewHDNV.DataSource = BLL.BLL_HDNV.Instance.GetDayOnl_ThangNay();
            else if(lam == true && month == false)
                dgrviewHDNV.DataSource = BLL.BLL_HDNV.Instance.GetDayOnl_ThangTruoc();
            else if (lam == false && month == false)
                dgrviewHDNV.DataSource = BLL.BLL_HDNV.Instance.GetDayOff_ThangTruoc();
            else
                dgrviewHDNV.DataSource = BLL.BLL_HDNV.Instance.GetDayOff_ThangNay();
        }

        private void HDNV_btnSearch_Click(object sender, EventArgs e)
        {
            if (HDNV_txtNV.Text == "")
                MessageBox.Show("Vui lòng nhập tên Nhân Viên muốn tìm kiếm!");
            else
            {
                List<DTO.DayOnl> dayonl = new List<DTO.DayOnl>();
                foreach (DataGridViewRow i in dgrviewHDNV.Rows)
                {
                    if (i.Cells[1].Value.ToString().Contains(HDNV_txtNV.Text))
                        dayonl.Add(new DTO.DayOnl
                        {
                            IdNhanVien = i.Cells[0].Value.ToString(),
                            TenNhanVien = i.Cells[1].Value.ToString(),
                            NgayOnl = Convert.ToDateTime(i.Cells[2].Value),
                        });
                }
                dgrviewHDNV.DataSource = dayonl;
            }
        }
        //Xem Report-----------------------------------------------------------------------------------------------------------------
        public void SetDGV_RP()
        {
            dgrviewXR.DataSource = BLL.BLL_Report.Instance.Show().Select(p => new { p.IdNhanVien, p.NhanVien.TenNhanVien, p.NoiDung, p.NgayBaoCao }).ToList();
        }
        private void XR_btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgrviewXR.SelectedRows;
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow i in r)
                {
                    string nd = i.Cells["NoiDung"].Value.ToString();
                    DateTime ngaybc = Convert.ToDateTime(i.Cells["NgayBaoCao"].Value.ToString());
                    string id = i.Cells["IdNhanVien"].Value.ToString();
                    BLL.BLL_Report.Instance.Del(id, nd, ngaybc);
                }
                BLL.BLL_Report.Instance.SaveDB();
                MessageBox.Show("Xóa thành công!");
                SetDGV_RP();
            }
            else if (dialogResult == DialogResult.No)
            { }
        }
    }
}
