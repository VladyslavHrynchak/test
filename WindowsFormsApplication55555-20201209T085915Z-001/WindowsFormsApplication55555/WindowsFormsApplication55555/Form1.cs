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
using System.Drawing.Printing;

namespace WindowsFormsApplication55555
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        public string connectionString;
        string tablProduct_groups = "SELECT * FROM Product_groups";
        string tablProducts = "SELECT * FROM Products";
        string tablStorage = "SELECT * FROM Storage";
        string tablСonsumption = "SELECT * FROM Сonsumption";
 

   

        public Form1()
        {
            InitializeComponent();
            Fill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text="Підключення до бази даних";
            this.Width = 400;
            this.Height = 300;
            
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tabControl1.Visible = false;

          


            label1.Text = "Для підключення до SQL Server введіть свій логін і пароль";
            label2.Text = "Логін";
            label3.Text = "Пароль";
            label4.Text = "База даних магазину";
            button1.Text = "Приєднатись";
            textBox2.PasswordChar = '*';

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           connectionString = "Data Source=91.225.200.84,1433;Initial Catalog="+textBox3.Text+";User ID="+textBox1.Text+";Password="+textBox2.Text; connectionString = "Data Source=91.225.200.84,1433;Initial Catalog="+textBox3.Text+";User ID="+textBox1.Text+";Password="+textBox2.Text;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();
                adapter = new SqlDataAdapter(tablProduct_groups, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                adapter = new SqlDataAdapter(tablProducts, connection);
                    ds = new DataSet();
                    adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];

                adapter = new SqlDataAdapter(tablStorage, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];

                adapter = new SqlDataAdapter(tablСonsumption, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView4.DataSource = ds.Tables[0];

            }
            
            this.Width = 1000;
            this.Height = 550;
         
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            dataGridView4.Visible = true;

            tabControl1.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false; 
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            FillSource(tablProduct_groups, 0);
            FillSource(tablProducts, 1);
            FillSource(tablStorage, 2);
            FillSource(tablСonsumption, 3);

        }
        private void FillSource(string tabl, int a)

        {
            connectionString = "Data Source=91.225.200.84,1433;Initial Catalog = KursovaGrinchak ;User ID= Hrynchak ; Password= 123456*";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(tabl, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                switch (a)

                {
                    case 0:
                        dataGridView1.DataSource = ds.Tables[0];
                        break;
                    case 1:
                        dataGridView2.DataSource = ds.Tables[0];
                        break;
                    case 2:
                        dataGridView3.DataSource = ds.Tables[0];
                        break;
                    case 3:
                        dataGridView4.DataSource = ds.Tables[0];
                        break;


                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Чи бажаєте вийти з програми?", "Вийти з програми?", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel) MessageBox.Show("Ви залишились в програмі");
            if (res == DialogResult.Yes) Close();
        }

        static SqlConnection con = new SqlConnection("Data Source = 91.225.200.84,1433; Initial Catalog = KursovaGrinchak; Persist Security Info = True; User ID = Hrynchak; Password = 123456*");
        static SqlCommand cmd = new SqlCommand("select * from Product_groups ", con);
        static SqlCommand cmd1 = new SqlCommand("select * from Products ", con);
        static SqlCommand cmd2 = new SqlCommand("select * from Storage ", con);
        static SqlCommand cmd3 = new SqlCommand("select * from Сonsumption ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        private void GetData()
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            dataGridView4.Visible = true;

            da.Fill(ds, "Product_groups");
            da1.Fill(ds, "Products");
            da2.Fill(ds, "Storage");
            da3.Fill(ds, "Сonsumption");
            dataGridView1.DataSource = ds.Tables["Product_groups"];
            dataGridView2.DataSource = ds.Tables["Products"];
            dataGridView3.DataSource = ds.Tables["Storage"];
            dataGridView4.DataSource = ds.Tables["Сonsumption"];
            MessageBox.Show("Данні отримано");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            SqlCommandBuilder cmd1 = new SqlCommandBuilder(da1);
            SqlCommandBuilder cmd2 = new SqlCommandBuilder(da2);
            SqlCommandBuilder cmd3 = new SqlCommandBuilder(da3);

            try
            {
                da.Update(ds, "Product_groups");
                da1.Update(ds, "Products");
                da2.Update(ds, "Storage");
                da2.Update(ds, "Сonsumption");
                MessageBox.Show("Данні збережено");


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Видалити запис?", "Видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Видалити запис?", "Видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Видалити запис?", "Видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView4_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Видалити запис?", "Видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
