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
    public partial class FReport : Form
    {
        private string _iDlogin;
        public string IDlogin { get => _iDlogin; set => _iDlogin = value; }
        public FReport(string m)
        {
            IDlogin = m;
            InitializeComponent();
        }

        private void RP_gui_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                MessageBox.Show("Vui lòng nhập Report!");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn gửi?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DAL.BaoCao bc = new DAL.BaoCao();
                    bc.IdNhanVien = IDlogin;
                    bc.NgayBaoCao = DateTime.Now.Date;
                    bc.NoiDung = richTextBox1.Text;
                    BLL.BLL_Report.Instance.Add(bc);
                    this.Close();
                    MessageBox.Show("Report thành công!");
                }
                else if (dialogResult == DialogResult.No)
                { this.Close(); }
            }
        }

        private void Btn_Huy_Click(object sender, EventArgs e)
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
