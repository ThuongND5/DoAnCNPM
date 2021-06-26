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
    public partial class Flogin : Form
    {
        public Flogin()
        {
            InitializeComponent();
            BLL.BLL_Login.Instance.TaoDB();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string m = txtTenDangNhap.Text;
            int check = BLL.BLL_Login.Instance.CheckLogin(m, BLL.BLL_MaHoaMK.MD5Hash(txtbMatKhau.Text));
            if (txtTenDangNhap.Text == "" || txtbMatKhau.Text == "")
                MessageBox.Show("Bạn chưa nhập tài khoản!");
            else if (check == 3)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            else if (check == 2)
            {
                FAdmin f = new FAdmin(m);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if (check == 1)
            {
                FQuanLi f = new FQuanLi(m);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if (check == 0)
            {
                FNhanVien f = new FNhanVien(m);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }
    }
}
