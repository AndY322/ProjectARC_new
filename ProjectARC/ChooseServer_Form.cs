using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectARC
{
    public partial class ChooseServer_Form : Form
    {
        string ServerFile = "ServerName.dat";
        public ChooseServer_Form()
        {
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveServer_btn_Click(object sender, EventArgs e)
        {
            
            using (BinaryWriter writer = new BinaryWriter(File.Open(ServerFile, FileMode.Truncate)))
            {
                writer.Write(ServerName_tb.Text);
                writer.Close();
            }
            this.Close();
        }
    }
}
