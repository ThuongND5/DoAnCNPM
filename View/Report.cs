using DoAnCNPM.DAL;
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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void RP_gui_Click(object sender, EventArgs e)
        {
            QLNS db = new QLNS();
            var query = db.ChucVus.Select(p => p);
            cx.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
