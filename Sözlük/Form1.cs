using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sözlük
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\BERKAN\Desktop\Yeni klasör\Sözlük\dbSozluk.mdb");
        void listeing()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from sozluk", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                listBox1.Items.Add(dr["ingilizce"].ToString());
                listBox2.Items.Add(dr["turkce"].ToString());
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listeing();
            BackColor = Color.GreenYellow;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox2.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from sozluk where ingilizce like '" + textBox1.Text + "%'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["ingilizce"]);
                listBox2.Items.Add(dr["turkce"]);
            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            con.Open();
            OleDbCommand cmd = new OleDbCommand("select *from sozluk where turkce like '" + textBox2.Text + "%'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["ingilizce"]);
                listBox2.Items.Add(dr["turkce"]);

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("insert into sozluk(turkce,ingilizce)values('" + textBox2.Text + "','" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

}
