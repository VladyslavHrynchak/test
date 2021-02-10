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

namespace БД_магазину
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string ConnectionString = "Data Source=91.225.200.84,1433;Initial Catalog=KursovaGrinchak;Persist Security Info=True;User ID=Hrynchak;Password=123456*";
              
            //"Data Source=91.225.200.84,1433;Initial Catalog=" + textBox3.Text + ";User ID=" + textBox1.Text + ";Password=" + textBox2.Text;
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            myConnection.Open();
            string query = "SELECT * FROM Product_groups ORDER BY GroupID";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();
            myConnection.Close();
            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaGrinchakDataSet.Product_groups". При необходимости она может быть перемещена или удалена.
            //this.product_groupsTableAdapter.Fill(this.kursovaGrinchakDataSet.Product_groups);

        }
    }
}
