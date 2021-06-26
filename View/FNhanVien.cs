using DoAnCNPM.DTO;
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
    public partial class FNhanVien : Form
    {
        private string _iDlogin;

        public string IDlogin { get => _iDlogin; set => _iDlogin = value; }

        public FNhanVien(string m)
        {
            IDlogin = m;
            InitializeComponent();
        }

        private void FNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private void HoTroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ 0971504302 để được hổ trợ thêm!");
        }
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FReport f = new FReport(IDlogin);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void doimatkhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDoiMatKhau f = new FDoiMatKhau(IDlogin, 1);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void FNhanVien_Load(object sender, EventArgs e)
        {
            DKNL_txtNghi.Text = "Lý do nghỉ làm!";
            DKNL_cmbOnlOff.SelectedIndex = 0;
            this.DKNL_cmbOnlOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TTCN_cmbTenPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TTCN_cmbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            SetTTL();
            SetCBBPhongBan();
            SetCBBChucVu();
            SetTTCN();
        }

        /*---------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------THÔNG TIN CÁ NHÂN-----------------------------------------------*/
        private void TTCN_btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DAL.NhanVien nv = new DAL.NhanVien();
                    nv.IdNhanVien = IDlogin;
                    nv.TenNhanVien = TTCN_txtbHoTenNV.Text;
                    nv.NgaySinh = TTCN_dtNgaysinh.Value;
                    if (TTCN_rbtnNam.Checked == true)
                        nv.GioiTinh = true;
                    else
                        nv.GioiTinh = false;
                    nv.IdPhongBan = ((CBBItem)TTCN_cmbTenPB.SelectedItem).Value.ToString();
                    nv.IdChucVu = ((CBBItem)TTCN_cmbChucVu.SelectedItem).Value;
                    nv.SDT = TTCN_txtbSDT.Text;
                    nv.CMND = TTCN_txtbCMND.Text;
                    nv.DiaChi = TTCN_txtbDC.Text;
                    nv.QueQuan = TTCN_txtbQueQuan.Text;
                    nv.DanToc = TTCN_txtbDanToc.Text;
                    if (TTCN_txtbTongiao.Text == "Không")
                        nv.TonGiao = false;
                    else
                        nv.TonGiao = true;
                    nv.SDTNguoiThan = TTCN_txtbSDTNguoiThan.Text;
                    BLL.BLL_NV_TTCN.Instance.UpdateTTCN(nv);
                    MessageBox.Show("Sửa thành công!");
                }
                else if (dialogResult == DialogResult.No)
                { 
                
                }
            }
            catch (Exception Loi)
            {
                MessageBox.Show("Lỗi!" + Loi);
            }
        }
        public void SetCBBPhongBan()
        {
            if (TTCN_cmbTenPB.Items != null)
            {
                TTCN_cmbTenPB.Items.Clear();
            }
            foreach (DAL.PhongBan i in BLL.BLL_NV_TTCN.Instance.SetPhongBan())
            {
                TTCN_cmbTenPB.Items.Add(new CBBItem
                {
                    Text = i.TenPhongBan,
                    Value = Convert.ToInt32(i.IdPhongBan)
                });
            }
        }
        public void SetCBBChucVu()
        {
            if (TTCN_cmbChucVu.Items != null)
            {
                TTCN_cmbChucVu.Items.Clear();
            }
            foreach (DAL.ChucVu i in BLL.BLL_NV_TTCN.Instance.SetChucVu())
            {
                TTCN_cmbChucVu.Items.Add(new CBBItem
                {
                    Text = i.TenChucVu,
                    Value = i.IdChucVu
                });
            }
        }
        public void SetTTCN()
        {
            DAL.NhanVien nv = BLL.BLL_NV_TTCN.Instance.GetTTCN(IDlogin);
            TTCN_txtbIDNhanVien.Text = IDlogin.ToString();
            TTCN_txtbHoTenNV.Text = nv.TenNhanVien.ToString();
            TTCN_dtNgaysinh.Value = nv.NgaySinh;
            foreach (CBBItem i in TTCN_cmbTenPB.Items)
            {
                if (i.Value.ToString() == nv.IdPhongBan)
                    TTCN_cmbTenPB.SelectedIndex = TTCN_cmbTenPB.Items.IndexOf(i);
            }
            foreach (CBBItem i in TTCN_cmbChucVu.Items)
            {
                if (i.Value == nv.IdChucVu)
                    TTCN_cmbChucVu.SelectedIndex = TTCN_cmbChucVu.Items.IndexOf(i);
            }
            if (nv.TonGiao == false)
                TTCN_txtbTongiao.Text = "Không";
            else
                TTCN_txtbTongiao.Text = "Có";
            if (nv.GioiTinh == true)
                TTCN_rbtnNam.Checked = true;
            else
                TTCN_rbtnNu.Checked = true;
            TTCN_txtbDanToc.Text = nv.DanToc.ToString();
            TTCN_txtbQueQuan.Text = nv.QueQuan.ToString();
            TTCN_txtbSDT.Text = nv.SDT.ToString();
            TTCN_txtbSDTNguoiThan.Text = nv.SDTNguoiThan.ToString();
            TTCN_txtbDC.Text = nv.DiaChi.ToString();
            TTCN_txtbCMND.Text = nv.CMND.ToString();
        }

        /*---------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------THÔNG TIN LƯƠNG-------------------------------------------------*/
        private void TTL_btnShow_Click(object sender, EventArgs e)
        {
            dgrviewTTL.DataSource = BLL.BLL_NV_TTL.Instance.ShowQTL(IDlogin);
        }
        public void SetTTL()
        {
            DAL.BangLuong show = BLL.BLL_NV_TTL.Instance.GetTTBL(IDlogin);
            TTL_txtbIDNV.Text = IDlogin.ToString();
            TTL_txtbTenNV.Text = show.NhanVien.TenNhanVien.ToString();
            TTL_txtbMucLuong.Text = show.MucLuongCoBan.ToString();
            TTL_txtbTongNgayLam.Text = show.SoNgayLam.ToString();
            TTL_txtbTongTien.Text = (Convert.ToInt32(show.MucLuongCoBan) * Convert.ToInt32(show.SoNgayLam)).ToString();
        }

        /*----------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------ĐĂNG KÍ NGÀY LÀM-------------------------------------------------*/
        private void DKNL_txtNghi_MouseClick(object sender, MouseEventArgs e)
        {
            if (DKNL_txtNghi.Text == "Lý do nghỉ làm!")
                DKNL_txtNghi.Clear();
        }
        private void DKNL_rbtnNghi_CheckedChanged(object sender, EventArgs e)
        {
            if (DKNL_rbtnNghi.Checked == true)
                DKNL_txtNghi.Visible = true;
            else
                DKNL_txtNghi.Visible = false;
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
                                MessageBox.Show("Đã đăng kí ngày hôm nay rồi!");
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
                                    MessageBox.Show("Đã đăng kí ngày hôm nay rồi!");
                            }
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
            }
            FNhanVien_Load(sender, e);
        }
    }
}
