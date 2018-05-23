using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectARC
{
    public partial class PDF_Check : Form
    {
        int CurrentRowIndex;
        MainForm mf = new MainForm();
        public PDF_Check(int CurrentRowIndex)
        {
            InitializeComponent();
            this.CurrentRowIndex = CurrentRowIndex;
        }

        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            mf.dataGridView1[11, CurrentRowIndex].Value = filename;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
