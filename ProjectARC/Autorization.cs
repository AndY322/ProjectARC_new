using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectARC
{
    public partial class Autorization : Form
    {
        string[,] autorize = new string[2,6];
        public Autorization()
        {
            InitializeComponent();
            Password_tb.PasswordChar = '*';
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("users.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            int i = 0, j = 0;
            foreach (XmlElement xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "login")
                    {
                        autorize[i, j] = childnode.InnerText;
                        i = 1;
                    }
                    if (childnode.Name == "password")
                    {
                        autorize[i, j] = childnode.InnerText;
                        i = 0;
                    }
                }
                j++;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            bool check = false;
            for(int i = 0; i< 6; i++)
            {
                if (Login_tb.Text == autorize[0, i] && Password_tb.Text == autorize[1, i])
                    check = true;
            }
            if (check)
            {
                MainForm MF = new MainForm();
                MF.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
