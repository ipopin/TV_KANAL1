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

namespace TV
{
    public partial class Form1 : Form
    {

        DataTable TV_KANAL = new DataTable();

        int rows = 0;
        string cs = "Data source = LAPTOP-3F2S3EF; Initial catalog = TV_KANAL";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("insert into TV_KANAL (ID , NAZIV, BROJ_KANALA, JEZIK, VREME_OD, VREME_DO) values (" + textBox1.Text + ", '" + textBox2.Text + "' ,'" + textBox3.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "' ,'" + textBox6.Text + "' ) ", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TV_KANAL", veza);
            TV_KANAL.Clear();
            adapter.Fill(TV_KANAL);
            refresh(rows);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Update TV_KANAL Set NAZIV= '" + textBox2.Text + "' , BROJ_KANALA= '" + textBox3.Text + "', JEZIK= '" + textBox4.Text + "' , VREME_OD= '" + textBox5.Text + "' , VREME_DO= '" + textBox6.Text + "'  where ID= " + textBox1.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TV_KANAL", veza);
            TV_KANAL.Clear();
            adapter.Fill(TV_KANAL);
            refresh(rows);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("delete from TV_KANAL where ID=" + textBox1.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TV_KANAL", veza);
            TV_KANAL.Clear();
            adapter.Fill(TV_KANAL);
            if (rows == TV_KANAL.Rows.Count) rows = rows - 1;
            if (rows == 0)
            {
                button2.Enabled = false;
            }
            if (TV_KANAL.Rows.Count > 1)
            {
                button3.Enabled = true;
            }
            if (rows == TV_KANAL.Rows.Count - 1)
            {
                button3.Enabled = false;
            }

            refresh(rows);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rows = 0;
            refresh(rows);
            button2.Enabled = false;
            button3.Enabled = true;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (rows > 0)
            {
                rows--;
                refresh(rows);
                button3.Enabled = true;
            }
            if (rows == 0)
            {
                button2.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rows = TV_KANAL.Rows.Count - 1;
            refresh(rows);
            button2.Enabled = true;
            button3.Enabled = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (rows < TV_KANAL.Rows.Count - 1)
            {
                rows++;
                refresh(rows);
                button2.Enabled = true;
            }
            if (rows == TV_KANAL.Rows.Count - 1)
            {
                button3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from info ", veza);
            adapter.Fill(TV_KANAL);

            refresh(rows);

            if (rows == 0)
            {
                button1.Enabled = false;
            }
            if (rows == TV_KANAL.Rows.Count - 1)
            {
                button4.Enabled = false;
            }
        }
        private void refresh(int x)
        {
            textBox1.Text = TV_KANAL.Rows[x]["ID"].ToString();
            textBox2.Text = TV_KANAL.Rows[x]["NAZIV"].ToString();
            textBox3.Text = TV_KANAL.Rows[x]["BROJ_KANALA"].ToString();
            textBox4.Text = TV_KANAL.Rows[x]["JEZIK"].ToString();
            textBox5.Text = TV_KANAL.Rows[x]["VREME_OD"].ToString();
            textBox6.Text = TV_KANAL.Rows[x]["VREME_DO"].ToString();

        }
    }
}
