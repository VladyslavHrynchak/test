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

namespace WindowsFormsApplication55555
{
    public partial class Form2 : Form
    {
        public string connectionString = " Data Source=91.225.200.84,1433;Initial Catalog=KursovaGrinchak;User ID=Hrynchak; Password=123456* ";
        public Form2()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            InsertAuto(textBox2.Text);
        }
        public void InsertAuto(string groupname)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Оператор SQL
            string sql = string.Format("Insert Into Product_groups" +
                  "(GroupName)" +
                  "Values (@GroupName)");

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                    cmd.Parameters.AddWithValue("@GroupName", groupname);
                    cmd.ExecuteNonQuery();
                MessageBox.Show("Дані додано в таблицю");
            
            }
                conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertAuto2(Convert.ToInt32(numericUpDown2.Value), textBox5.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value));
        }
        public void InsertAuto2(int groupid, string name, int unit_of_measure, int purchase_price, int selling_price)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
           
            string sql = string.Format("Insert Into Products" +
                  "(GroupID,Name,Unit_of_measure, Purchase_price, Selling_price)" +
                  "Values (@GroupID, @Name, @Unit_of_measure, @Purchase_price, @Selling_price)");

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@GroupID", groupid);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Unit_of_measure", unit_of_measure);
                cmd.Parameters.AddWithValue("@Purchase_price", purchase_price);
                cmd.Parameters.AddWithValue("@Selling_price", selling_price);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Дані додано в таблицю");

            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertAuto3(Convert.ToInt32(numericUpDown5.Value),Convert.ToInt32(numericUpDown6.Value), Convert.ToInt32(numericUpDown7.Value),textBox12.Text);
        }
        public void InsertAuto3(int productid, int purchase_price, int selling_price, string numberofsales)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = string.Format("Insert Into Storage" +
                  "(ProductID,Purchase_price, Selling_price, NumberOfSales)" +
                  "Values (@ProductID, @Purchase_price, @Selling_price, @NumberOfSales)");

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", productid);
                cmd.Parameters.AddWithValue("@Purchase_price", purchase_price);
                cmd.Parameters.AddWithValue("@Selling_price", selling_price);
                cmd.Parameters.AddWithValue("@NumberOfSales", numberofsales);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Дані додано в таблицю");

            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertAuto4(Convert.ToInt32(numericUpDown8.Value), Convert.ToInt32(numericUpDown9.Value), Convert.ToInt32(numericUpDown10.Value), dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }
        public void InsertAuto4(int checkid, int productid, int count, string dateofcheck)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = string.Format("Insert Into Сonsumption" +
                  "(CheckID, ProductID, Count, DateOfCheck)" +
                  "Values (@CheckID, @ProductID, @Count, @DateOfCheck)");

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CheckID", checkid);
                cmd.Parameters.AddWithValue("@ProductID", productid);
                cmd.Parameters.AddWithValue("@Count", count);
                cmd.Parameters.AddWithValue("@DateOfCheck", dateofcheck);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Дані додано в таблицю");

            }
            conn.Close();
        }

       
    }

}

