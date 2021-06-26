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
    public partial class FDoiMatKhau : Form
    {
        private string _iDlogin;
        private int _type;
        public string IDlogin { get => _iDlogin; set => _iDlogin = value; }
        public int Type { get => _type; set => _type = value; }
        public FDoiMatKhau(string m, int n)
        {
            IDlogin = m;
            Type = n;
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (txt_MKHT.Text == "" || txt_MKM.Text == "" || txt_NLMKM.Text == "")
                MessageBox.Show("Vui lòng nhập thông tin!");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn lưu?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (Type == 1)
                    {

                        if (BLL.BLL_Account.Instance.CheckMatKhau_NV(IDlogin, BLL.BLL_MaHoaMK.MD5Hash(txt_MKHT.Text)) == false)
                            MessageBox.Show("Mật khẩu hiện tại không đúng!");
                        else
                        {
                            if (txt_MKM.Text != txt_NLMKM.Text)
                                MessageBox.Show("Mật Khẩu Mới không trùng khớp! Vui lòng kiểm tra lại!");
                            else
                            {
                                check = true;
                                BLL.BLL_Account.Instance.UpdateAccNV(IDlogin, BLL.BLL_MaHoaMK.MD5Hash(txt_MKM.Text));
                            }
                        }
                    }
                    else if (Type == 2)
                    {
                        if (BLL.BLL_Account.Instance.CheckMatKhau_Admin(IDlogin, BLL.BLL_MaHoaMK.MD5Hash(txt_MKHT.Text)) == false)
                            MessageBox.Show("Mật khẩu hiện tại không đúng!");
                        else
                        {
                            if (txt_MKM.Text != txt_NLMKM.Text)
                                MessageBox.Show("Mật Khẩu Mới không trùng khớp! Vui lòng kiểm tra lại!");
                            else
                            {
                                check = true;
                                BLL.BLL_Account.Instance.UpdateAdmin(IDlogin, BLL.BLL_MaHoaMK.MD5Hash(txt_MKM.Text));
                            }
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                { }
            }
            if (check == true)
            {
                this.Close();
                MessageBox.Show("Lưu thành công!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn hủy?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            { }
        }
    }
}
