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
            if(txtTenDangNhap.Text == "" && txtbMatKhau.Text == "")
                MessageBox.Show("Bạn chưa nhập tài khoản!");
            else if ((txtTenDangNhap.Text == "admin" && txtbMatKhau.Text == "admin") ||
                (txtTenDangNhap.Text == "ql" && txtbMatKhau.Text == "ql"))
            {
                FQuanLi f = new FQuanLi();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if (txtTenDangNhap.Text == "nv" && txtbMatKhau.Text == "nv")
            {
                FNhanVien f = new FNhanVien();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
        }

    }
}
