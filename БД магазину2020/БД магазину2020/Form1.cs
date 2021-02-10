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

namespace БД_магазину2020
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        public string connectionString;
        string tablProduct_groups = "SELECT * FROM Product_groups";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Підключення до бази даних";
            this.Width = 400;
            this.Height = 300;


            label1.Text = "Для підключення до SQL Server введіть свій логін і пароль";
            label2.Text = "Логін";
            label3.Text = "Пароль";
            label4.Text = "Назва бази даних бібліотека";
            button1.Text = "Приєднатись";
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
           connectionString = "Data Source=91.225.200.84,1433;Initial Catalog=" + textBox3.Text + ";User ID=" + textBox1.Text + ";Password=" + textBox2.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(tablProduct_groups, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
        }
    }
}
