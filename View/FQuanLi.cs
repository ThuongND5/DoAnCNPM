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
    public partial class FQuanLi : Form
    {
        private string _iDlogin;

        public string IDlogin { get => _iDlogin; set => _iDlogin = value; }

        public FQuanLi(string m)
        {
            IDlogin = m;
            InitializeComponent();
        }
        private void FQuanLi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private void doimatkhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDoiMatKhau f = new FDoiMatKhau(IDlogin, 1);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void MenuHoTro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ 0971504302 để được hổ trợ thêm!");
        }
        private void MenuReport_Click(object sender, EventArgs e)
        {
            FReport f = new FReport(IDlogin);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void FQuanLi_Load(object sender, EventArgs e)
        {
            this.QLHS_cmbTenPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QLHS_cmbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            SetDGV_QLHS();
            SetCBBPhongBan();
            SetCBBChucVu();
            this.Cmb_DGNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DKNL_txtNghi.Text = "Lý do nghỉ làm!";
            this.DKNL_cmbOnlOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DKNL_cmbOnlOff.SelectedIndex = 0;
            Cmb_DGNV.SelectedIndex = 0;
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
                QLHS_dtNgaysinh.Value = nv.NgaySinh;
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
                            id.Add(i.Cells[0].Value.ToString());
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
            FQuanLi_Load(sender, e);
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
                        else if (QLHS_cmbChucVu.SelectedItem.ToString() == "Quản Lí")
                        {
                            MessageBox.Show("Bạn là Quản Lí, chỉ được thêm Nhân Viên!");
                            checkadd_HS = true;
                        }
                        else
                        {
                            nv.NgaySinh = QLHS_dtNgaysinh.Value.Date;
                            nv.IdNhanVien = QLHS_txtbIDNhanVien.Text;
                            nv.TenNhanVien = QLHS_txtbHoTenNV.Text;
                            nv.GioiTinh = QLHS_rbtnNam.Checked;
                            nv.IdPhongBan = ((DTO.CBBItem)QLHS_cmbTenPB.SelectedItem).Value.ToString();
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
            if(openFAccount == true)
            {
                FAccount f = new FAccount(idNewAccount,PhanQuyen);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            FQuanLi_Load(sender, e);
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
                        if (QLHS_cmbChucVu.SelectedItem.ToString() == "Quản Lí")
                        { MessageBox.Show("Bạn không thể sửa Nhân Viên thành Quản Lí"); }
                        else
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
        /*-------------------------------------------Đánh Giá Nhân Viên--------------------------------------------------*/
        public void SetDGV_QLKT()
        {
            dgrviewDG.DataSource = BLL.BLL_QLKT.Instance.Show_QLKT_QL();
        }
        public void SetDGV_QLKL()
        {
            dgrviewDG.DataSource = BLL.BLL_QLKL.Instance.Show_QLKL_QL();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Cmb_DGNV.Text == "Khen Thưởng")
                dgrviewDG.DataSource = BLL.BLL_QLKT.Instance.Show_QLKT_QL();
            else if (Cmb_DGNV.Text == "Kỉ Luật")
                dgrviewDG.DataSource = BLL.BLL_QLKL.Instance.Show_QLKL_QL();
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
        private void QLKT_btnThem_Click(object sender, EventArgs e)
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
                        bool ktr_QL = true;
                        foreach (string i in BLL.BLL_QLKT.Instance.ID_QL())
                        {
                            if (DG_txtbIdNV.Text == i.ToString())
                            {
                                ktr_QL = false;
                                break;
                            }
                        }
                        bool addxong = false;
                        if (ktr_QL == true)
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
                                    addxong = true;
                                }
                                else if (dialogResult == DialogResult.No)
                                { }
                            }
                            else
                            { MessageBox.Show("Lỗi dữ liệu!"); }
                        }
                        else
                        {
                            MessageBox.Show("Quản Lí không thể tự khen thưởng Quản Lí!");
                            DG_txtbIdNV.Text = "";
                        }
                        if (addxong == true)
                        {
                            FormAdd_DG();
                        }
                    }
                    else if (Cmb_DGNV.Text == "Kỉ Luật")
                    {
                        bool ktr_QL = true;
                        foreach (string i in BLL.BLL_QLKL.Instance.ID_QL())
                        {
                            if (DG_txtbIdNV.Text == i.ToString())
                            {
                                ktr_QL = false;
                                break;
                            }
                        }
                        if (ktr_QL == true)
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
                        else
                        {
                            MessageBox.Show("Quản Lí không thể tự kỉ luật Quản Lí!");
                            DG_txtbIdNV.Text = "";
                        }
                    }
                }
            }
        }
        private void QLKT_btnSua_Click(object sender, EventArgs e)
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
                    bool ktr_QL = true;
                    foreach (string i in BLL.BLL_QLKT.Instance.ID_QL())
                    {
                        if (DG_txtbIdNV.Text == i.ToString())
                        {
                            ktr_QL = false;
                            break;
                        }
                    }
                    bool updatexong = false;
                    if (ktr_QL == true)
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
                                updatexong = true;
                            }
                            else if (dialogResult == DialogResult.No)
                            { }
                        }
                        else
                        { MessageBox.Show("Lỗi dữ liệu!"); }
                    }
                    else
                    {
                        MessageBox.Show("Quản Lí không thể tự khen thưởng Quản Lí!");
                        FormAdd_DG();
                        checkupdate_DG = false;
                    }
                    if (updatexong == true)
                    {
                        FormAdd_DG();
                    }
                }
                else if (Cmb_DGNV.Text == "Kỉ Luật")
                {
                    bool ktr_QL = true;
                    foreach (string i in BLL.BLL_QLKL.Instance.ID_QL())
                    {
                        if (DG_txtbIdNV.Text == i.ToString())
                        {
                            ktr_QL = false;
                            break;
                        }
                    }
                    if (ktr_QL == true)
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
                    else
                    {
                        MessageBox.Show("Quản Lí không thể tự kỉ luật Quản Lí!");
                        FormAdd_DG();
                        checkupdate_DG = false;
                    }
                }
            }
        }
        private void dgrviewQLKT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormAdd_DG();
            checkupdate_DG = false;
        }
        private void QLKT_btnTimKiem_Click(object sender, EventArgs e)
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
        private void QLKT_btnXoa_Click(object sender, EventArgs e)
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
        /*----------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------ĐĂNG KÍ NGÀY LÀM-------------------------------------------------*/
        private void DKNL_rbtnNghi_CheckedChanged(object sender, EventArgs e)
        {
            if (DKNL_rbtnNghi.Checked == true)
                DKNL_txtNghi.Visible = true;
            else
                DKNL_txtNghi.Visible = false;
        }
        private void DKNL_txtNghi_MouseClick(object sender, MouseEventArgs e)
        {
            if (DKNL_txtNghi.Text == "Lý do nghỉ làm!")
                DKNL_txtNghi.Clear();
        }
        private void DKNL_txtNghi_Leave(object sender, EventArgs e)
        {
            if (DKNL_txtNghi.Text == "")
                DKNL_txtNghi.Text = "Lý do nghỉ làm!";
        }
        public void ShowDGVOnl()
        {
            dgrviewDKNL.DataSource = BLL.BLL_DKLam.Instance.ShowNgayOnl(IDlogin);
        }
        public void ShowDGVOff()
        {
            dgrviewDKNL.DataSource = BLL.BLL_DKLam.Instance.ShowNgayOff(IDlogin);
        }
        private void DKNL_btnSave_Click(object sender, EventArgs e)
        {
            bool next = false;
            if (DKNL_rbtnLAm.Checked == false && DKNL_rbtnNghi.Checked == false)
                MessageBox.Show("Vui lòng chọn Làm hay Nghỉ!");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn lưu?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DAL.DayOff dayoff = new DAL.DayOff();
                    dayoff.IdNhanVien = IDlogin;
                    dayoff.NgayOff = DKNL_dtNgayCong.Value.Date;
                    dayoff.LyDo = DKNL_txtNghi.Text;
                    DAL.DayOnl dayonl = new DAL.DayOnl();
                    dayonl.IdNhanVien = IDlogin;
                    dayonl.NgayOnl = DKNL_dtNgayCong.Value.Date;

                    if (DKNL_rbtnLAm.Checked == true)
                    {
                        if (BLL.BLL_DKLam.Instance.CheckOff(IDlogin, DKNL_dtNgayCong.Value.Date) == false)
                        {
                            MessageBox.Show("Bạn đã đăng kí off cho ngày hôm nay rồi!");
                            ShowDGVOff();
                            next = true;
                        }
                    }
                    else if (DKNL_rbtnNghi.Checked == true)
                    {
                        if (DKNL_txtNghi.Text == "Lý do nghỉ làm!")
                        {
                            MessageBox.Show("Vui lòng nhập lí do!");
                            next = true;
                        }
                        else if (BLL.BLL_DKLam.Instance.CheckOnl(IDlogin, DKNL_dtNgayCong.Value.Date) == false)
                        {
                            MessageBox.Show("Bạn đã đăng kí onl cho ngày hôm nay rồi!");
                            ShowDGVOnl();
                            next = true;
                        }
                    }

                    if (next == false)
                    {
                        if (DKNL_rbtnLAm.Checked == true)
                        {
                            if (BLL.BLL_DKLam.Instance.CheckDaDKOnl(IDlogin, DKNL_dtNgayCong.Value.Date) == true)
                            {
                                BLL.BLL_DKLam.Instance.AddNgayOnl(dayonl, IDlogin);
                                MessageBox.Show("Đăng kí thành công!");
                                ShowDGVOnl();
                            }
                            else
                                MessageBox.Show("Bạn đã đăng kí ngày hôm nay rồi!");
                        }
                        else if (DKNL_rbtnLAm.Checked == false)
                        {
                            if (DKNL_txtNghi.Text == "Lý do nghỉ làm!")
                                MessageBox.Show("Vui lòng nhập lí do!");
                            else
                            {
                                if (BLL.BLL_DKLam.Instance.CheckDaDKOff(IDlogin, DKNL_dtNgayCong.Value.Date) == true)
                                {
                                    BLL.BLL_DKLam.Instance.AddNgayOff(dayoff);
                                    MessageBox.Show("Đăng kí thành công!");
                                    ShowDGVOff();
                                }
                                else
                                    MessageBox.Show("Bạn đã đăng kí ngày hôm nay rồi!");
                            }
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
            }
        }
        private void DKNL_cmbOnlOff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DKNL_cmbOnlOff.SelectedItem.ToString() == "Onl")
            {
                ShowDGVOnl();
            }
            else if (DKNL_cmbOnlOff.SelectedItem.ToString() == "Off")
            {
                ShowDGVOff();
            }
        }

        private void QLHS_btnBaoCao_Click(object sender, EventArgs e)
        {

        }
    }
}
