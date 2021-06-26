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
    public partial class FAccount : Form
    {
        private string _iDNewAccount;
        private int _phanQuyen;

        public string IDNewAccount { get => _iDNewAccount; set => _iDNewAccount = value; }
        public int PhanQuyen { get => _phanQuyen; set => _phanQuyen = value; }

        public FAccount(string m, int n)
        {
            IDNewAccount = m;
            PhanQuyen = n;
            InitializeComponent();
            SetCBBPhanQuyen();
            SetForm();
        }
        public void SetCBBPhanQuyen()
        {
            if (cmbPQ != null)
                cmbPQ.Items.Clear();
            foreach(DAL.ChucVu i in BLL.BLL_QLHS.Instance.SetChucVu())
            {
                cmbPQ.Items.Add(new DTO.CBBItem
                {
                    Text = i.TenChucVu,
                    Value = i.IdChucVu
                });
            }
        }
        public void SetForm()
        {
            txtbIDNV.Text = IDNewAccount.ToString();
            txtPass1.Text = "";
            txtMucLuong.Text = "";
            foreach (DTO.CBBItem i in cmbPQ.Items)
            {
                if (i.Value == PhanQuyen)
                    cmbPQ.SelectedIndex = cmbPQ.Items.IndexOf(i);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Account ac = new DAL.Account();
                ac.IdNhanVien = IDNewAccount;
                ac.MatKhau = txtMucLuong.Text;
                ac.KieuPhanQuyen = PhanQuyen;
                BLL.BLL_Account.Instance.Add_Acc(ac);
                DAL.BangLuong bl = new DAL.BangLuong();
                bl.IdNhanVien = IDNewAccount;
                bl.MucLuongCoBan = Convert.ToInt32(txtMucLuong.Text);
                bl.SoNgayLam = 0;
                bl.TongTienLuong = 0;
                BLL.BLL_Account.Instance.Add_BangLuong(bl);
                MessageBox.Show("Thêm thành công!");
                this.Close();
                }catch(Exception)
            { MessageBox.Show("Vui lòng kiểm tra lại dữ liệu!"); }
        }
    }
}
