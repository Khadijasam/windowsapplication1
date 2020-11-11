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

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        public Form4()
        {

            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                cn.Open();
                cmd=new SqlCommand("Select * from student WHERE roll =  '" + comboBox1.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["name"].ToString();
                    textBox2.Text = dr["marks"].ToString();
                    textBox3.Text = dr["grade"].ToString();


                }

                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("something went wrong" + ex);
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
             SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand("select roll from student", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            comboBox1.Text = "select";

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["roll"]);
            }
            cn.Close();
        }
    }
}
