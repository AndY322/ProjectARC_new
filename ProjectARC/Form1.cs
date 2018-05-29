using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ProjectARC
{
    public partial class MainForm : Form
    {
        SqlDataAdapter adapter, app_adapter;
        SqlCommandBuilder commandBuilder, app_CB;
        DataSet ds = new DataSet();
        DataSet app_ds = new DataSet();
        int i = 0;
        string ServerFile = "ServerName.dat";
        string conString1 = "Data Source=";
        string conString2;
        string conString3 = ";Initial Catalog=ProjectARC;Integrated Security=True";
        List<int> width = new List<int>() {30, 185, 280, 70, 70, 70, 70, 100, 100, 100, 775};
        List<string> names = new List<string>() {"Исполнитель","Подразделение", "Ответ", "Дата передачи", "Крайний срок", "Дата согласования", "Утвердил", "Номер объекта", "Номер документа", "Замечание"};
        string connectionString;
        string sql = "SELECT * FROM MainTable";
        string sql_app = "SELECT * FROM Approval_table";
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(DataGridView1_DataError);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.DataError += new DataGridViewDataErrorEventHandler(DataGridView1_DataError);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;
            //dataGridView1.RowTemplate.Height = 36; // zadaet visoty vseh ryadov
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;//sho-to nerabotaet. N E P O N Y A T N O
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            MenuItem refresh = new MenuItem("Обновить", new System.EventHandler(refresh_Click));
            MenuItem save = new MenuItem("Сохранить", new System.EventHandler(save_Click));
            MenuItem delete = new MenuItem("удалить", new System.EventHandler(delete_Click));
            MenuItem add = new MenuItem("Добавить", new System.EventHandler(add_Click));
            MenuItem file = new MenuItem("Операции", new MenuItem[] { refresh, save, delete, add });
            MenuItem Open_PDF = new MenuItem("Открыть", new System.EventHandler(open_Click));
            MenuItem Add_PDF = new MenuItem("Добавить", new System.EventHandler(Add_PDF_Click));
            MenuItem PDF = new MenuItem("Файл", new MenuItem[] {Open_PDF, Add_PDF });
            Menu = new MainMenu(new MenuItem[] { file, PDF });

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ServerFile, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                        conString2 = reader.ReadString();
                    reader.Close();
                }
                connectionString = string.Format(@"{0}{1}{2}", conString1, conString2, conString3);
                ConnectionFunc();
            }
            catch(Exception)
            {
                ChooseServer_Form cs = new ChooseServer_Form();
                cs.ShowDialog();
                
                using (BinaryReader reader = new BinaryReader(File.Open(ServerFile, FileMode.Open)))
                {

                    while (reader.PeekChar() > -1)
                        conString2 = reader.ReadString();
                    reader.Close();
                }
                connectionString = string.Format(@"{0}{1}{2}", conString1, conString2, conString3);
                try
                {
                    ConnectionFunc();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
            foreach (string s in names)
            {
                i++;
                dataGridView1.Columns[i].HeaderText = s;
            }
            i = 0;
            foreach (int j in width)
            {
                dataGridView1.Columns[i].Width = j;
                i++;
            }

        }

        private void open_Click(object sender, EventArgs e)
        {
            //int x = dataGridView1.CurrentRow.Index;
            //if (dataGridView1[11, x].Value.ToString() != "")
            //{
            //    string filename = dataGridView1[11, x].Value.ToString();
            //    string filePath = filename;
            //    this.axAcroPDF1.LoadFile(filePath);
            //    this.axAcroPDF1.src = filePath;
            //    this.axAcroPDF1.setShowToolbar(false);
            //    this.axAcroPDF1.setView("FitH");
            //    this.axAcroPDF1.setLayoutMode("DontCare");
            //    this.axAcroPDF1.Show();

            //    SaveFunc();
            //}
            //else
            //    MessageBox.Show("Не выбран PDF файл для текущего поля");
        }

        private void Add_PDF_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentRow.Index;
            if (dataGridView1[11, x].Value.ToString() == null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;

                dataGridView1[11, x].Value = filename;
            }
            else
            {
                PDF_Check pdfc = new PDF_Check(x);
                pdfc.ShowDialog();
            }

            SaveFunc();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            ReserveUpdateForm ReserveForm = new ReserveUpdateForm();
            ReserveForm.ShowDialog();
            //SaveFunc();
            this.Visible = false;
            this.Close();
            Application.Exit();
        }
        private void save_Click(object sender, EventArgs e)
        {
            SaveFunc();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            SaveFunc();
        }
        private void add_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
            SaveFunc();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        internal void SaveFunc()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("ProcARC5", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@executor", SqlDbType.VarChar, 20, "Executor"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@subdivision", SqlDbType.VarChar, 50, "Subdivision"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@itemnumber", SqlDbType.VarChar, 10, "ItemNumber"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@documentnumber", SqlDbType.Int, 0, "DocumentNumber"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@comment", SqlDbType.VarChar, 200, "Comment"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@currentstate", SqlDbType.VarChar, 15, "CurrentState"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@registrationdate", SqlDbType.DateTime, 0, "RegistrationDate"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@deadline", SqlDbType.DateTime, 0, "DeadLine"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@approvaldate", SqlDbType.DateTime, 0, "ApprovalDate"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@approvedthe", SqlDbType.VarChar, 15, "ApprovedThe"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@pdf_string", SqlDbType.VarChar, 250, "PDF_String"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                parameter.Direction = ParameterDirection.Output;
                try
                {
                    adapter.Update(ds);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Ошибка. Длина строки превышает допустимую величину.");
                }
                catch(DBConcurrencyException)
                {
                    MessageBox.Show("Ваши данные устарели, нажмите кнопку обновить для корректной работы программы.");
                }
                connection.Close();

            }
        }
        public void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            MessageBox.Show("Неверный ввод даты.\nВведите дату в формате дд.мм.гг");
            anError.ThrowException = false;
        }
        private void ConnectionFunc()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["ID"].ReadOnly = true;
                dataGridView1.Columns["PDF_String"].Visible = false;


                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                app_adapter = new SqlDataAdapter(sql_app, connection);
                app_adapter.Fill(app_ds);
                dataGridView2.DataSource = app_ds.Tables[0];
                dataGridView2.Columns["Key"].Visible = false;


                connection.Close();
            }

        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {

        }
    }

}