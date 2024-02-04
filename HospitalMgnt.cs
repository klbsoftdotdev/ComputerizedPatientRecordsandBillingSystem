using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bi_CPRBS
{
    public partial class HospitalMgnt : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        public HospitalMgnt()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
        }
        private void numfld(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button8.Enabled = true;
            textBox18.Enabled = true;
            textBox19.Enabled = true;
            textBox20.Enabled = true;
            comboBox3.Enabled = true;
            bi_Codes bi = new bi_Codes();
            dataGridView5.DataSource = bi.viewroom();
            DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
            textBox18.Text = row.Cells["Room Name"].Value.ToString();
            comboBox3.Text = row.Cells["Room Type"].Value.ToString();
            textBox19.Text = row.Cells["Room Capacity"].Value.ToString();
            textBox20.Text = row.Cells["Room Price"].Value.ToString();
            button8.Text = "Update";
            button7.Enabled = true;
            button7.Text = "Cancel";
        }
        private void updatehospital()
        {
            try
            {
                string sql;
                int a = dataGridView4.SelectedCells[0].RowIndex;
              string b= dataGridView4["Hospital Name", a].Value.ToString();
              con.Close();
                sql = "SELECT * FROM hospital WHERE hname='"+b+"'";
                con.Open();
                MySqlCommand dbcomm2 = new MySqlCommand(sql, con);
                MySqlDataReader dbread2;
                dbread2 = dbcomm2.ExecuteReader();
                dbread2.Read();

                if (dbread2.HasRows)
                {
                    textBox13.Text = dbread2["hname"].ToString();
                    textBox12.Text = dbread2["hcode"].ToString() + "";
                    richTextBox1.Text = dbread2["haddress"].ToString() + "";
                    textBox14.Text = dbread2["hcountry"].ToString() + "";
                    textBox15.Text = dbread2["hstate"].ToString() + "";
                    textBox16.Text = dbread2["hzip"].ToString() + "";
                    textBox17.Text = dbread2["city"].ToString() + "";
                }

                dbread2.Close();
            }
            catch (ArgumentOutOfRangeException)
            { }
        }
        private void bi_HospitalMgnt_Load(object sender, EventArgs e)
        {
            bi_Codes b3 = new bi_Codes();
            dataGridView9.DataSource = b3.viewinsurance();
            bi_Codes bi3 = new bi_Codes();
            dataGridView6.DataSource = bi3.viewphysician();
            button7.Enabled = true;
            bi_Codes bi = new bi_Codes();
            dataGridView5.DataSource = bi.viewroom();
            bi_Codes bi2 = new bi_Codes();
            dataGridView4.DataSource = bi2.viewhospital();
            dataGridView4.Columns[0].Width = 100;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Update")
            {
                bi_Codes bi = new bi_Codes();
                bi.updateroom(textBox18.Text, comboBox3.Text, textBox19.Text, textBox20.Text);
                MessageBox.Show("Room Updated!", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView5.DataSource = bi.viewroom();
                button8.Text = "New";
                button7.Enabled = true;
                button7.Text = "Close";
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                comboBox3.Text = "";
            }
            else if (button8.Text == "New")
            {
                button8.Enabled = true;
                button7.Enabled = true;
                textBox18.Enabled = true;
                textBox19.Enabled = true;
                textBox20.Enabled = true;
                comboBox3.Enabled = true;
                button8.Text = "Add";
                button7.Text = "Cancel";

            }
            else if(button8.Text =="Add")
            {
             
                bi_Codes bi = new bi_Codes();
                bi.roomcode(textBox18.Text);
                con.Close();
                string roomcode = "SELECT * FROM room where roomname ='" + textBox18.Text + "'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(roomcode, con);
                MySqlDataReader dtr;
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    MessageBox.Show("Room " + textBox18.Text + " is already in records!", "Room failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox18.Text == "" || textBox19.Text == "" || textBox20.Text == "" || comboBox3.Text == "")
                    {
                        MessageBox.Show("Fill up all neccessary fields!", "failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bi_Codes b2 = new bi_Codes();
                        b2.addroom(textBox18.Text, comboBox3.Text, textBox19.Text, textBox20.Text);
                        MessageBox.Show("Room "+textBox18.Text+" successfully added!", "New Room Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView5.DataSource = b2.viewroom();
                        button8.Enabled = true;
                        button8.Text = "New";
                        button7.Text = "Close";
                        button7.Enabled = true;
                        textBox18.Enabled = false;
                        textBox19.Enabled = false;
                        textBox20.Enabled = false;
                        comboBox3.Enabled = false;
                        textBox18.Clear();
                        textBox19.Clear();
                        textBox20.Clear();
                        comboBox3.Text = "";
                    }
                }
            }
            
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Cancel")
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    button7.Enabled = true;
                    button7.Text = "Close";
                    button8.Enabled = true;
                    button8.Text = "New";
                    textBox18.Enabled = false;
                    textBox19.Enabled = false;
                    textBox20.Enabled = false;
                    comboBox3.Enabled = false;
                    textBox18.Clear();
                    textBox19.Clear();
                    textBox20.Clear();
                    comboBox3.Text = "";

                }
            }
            else
            {
                this.Close();
            }

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57)
             || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57)
             || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "&Cancel")
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    textBox13.Enabled = false;
                    textBox14.Enabled = false;
                    textBox15.Enabled = false;
                    textBox16.Enabled = false;
                    textBox17.Enabled = false;
                    richTextBox1.Enabled = false;
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
                    textBox17.Clear();
                    dataGridView4.Enabled = false;
                    richTextBox1.Clear();
                    button5.Text = "&Close";
                    button6.Text = "N&ew";
                }
            }
            else
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "&Add")
            {
                if (textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "")
                {
                    MessageBox.Show("Please fill all neccessary blanks!");
                }
                else
                {
                    bi_Codes bi = new bi_Codes();
                    bi.hostat();
                    bi.addhospital(textBox13.Text, richTextBox1.Text, textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text, textBox12.Text);
                    MessageBox.Show("Hospital successfully Added!", "Add successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bi_Codes bi2 = new bi_Codes();
                    dataGridView4.DataSource = bi2.viewhospital();
                    dataGridView4.Columns[0].Width = 100;
                    dataGridView4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
                    textBox17.Clear();
                    richTextBox1.Clear();
                
                    textBox13.Enabled = false;
                    textBox14.Enabled = false;
                    textBox15.Enabled = false;
                    textBox16.Enabled = false;
                    textBox17.Enabled = false;
                    richTextBox1.Enabled = false;
                    button6.Text = "N&ew";
                    button5.Text = "&Close";
                }
            }
            else if (button6.Text == "N&ew")
            {

                string trysql = "select hcode as 'Hospital Code', hname as 'Hospital Name', haddress as 'Address' from hospital";
                cmd = new MySqlCommand(trysql, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "hospital");

                dt = ds.Tables["hospital"];
                dataGridView4.DataSource = dt;
                dataGridView4.Columns[0].Width = 100;
                int i = dt.Rows.Count;
                string cnt = Convert.ToString(i + 1);
                dataGridView4.Enabled = true;
                textBox12.Text = "00" + cnt;
               
                textBox13.Enabled = true;
                textBox14.Enabled = true;
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                textBox17.Enabled = true;
                richTextBox1.Enabled = true;
            
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                richTextBox1.Clear();
                button6.Text = "&Add";
                button5.Text = "&Cancel";
            }
            else
            {
                bi_Codes bi = new bi_Codes();
                bi.updatehospital(textBox13.Text,richTextBox1.Text,textBox14.Text,textBox15.Text,textBox16.Text,textBox17.Text,textBox12.Text);
                MessageBox.Show("Hospital successfully updated!", "Update successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView4.DataSource = bi.viewhospital();
                dataGridView4.Columns[0].Width = 100;
            }
           
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updatehospital();
            button6.Text = "&Update";
            button5.Text = "&Cancel";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bi_Codes bi = new bi_Codes();
            bi.addphysician(textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text, dateTimePicker1.Text, textBox1.Text, textBox2.Text);
            MessageBox.Show("New Physician added!");
            dataGridView6.DataSource = bi.viewphysician();
            button10.Enabled = true;
            button9.Enabled = true;
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            dateTimePicker1.Update();
            textBox1.Clear();
            textBox2.Clear();
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            textBox23.Enabled = false;
            textBox24.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            button10.Enabled = false;
            textBox21.Enabled = true;
            textBox22.Enabled = true;
            textBox23.Enabled = true;
            textBox24.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bi_Codes bi = new bi_Codes();
            bi.insurance(textBox26.Text, textBox27.Text);
            MessageBox.Show("New Insurance added!");
            dataGridView9.DataSource = bi.viewinsurance();
        }

    }
}
