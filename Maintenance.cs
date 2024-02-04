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
    public partial class Maintenance : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        public Maintenance()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "Cancel")
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to Cancel?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    button12.Enabled = true;
                    button12.Text = "New";
                    button11.Enabled = true;
                    button11.Text = "Close";
                    textBox1.Enabled = false;
                    textBox25.Enabled = false;
                    textBox1.Clear();
                    textBox25.Clear();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "New")
            {
                dataGridView8.Enabled = true;
                textBox1.Enabled = true;
                textBox25.Enabled = true;
                button12.Enabled = true;
                button11.Enabled = true;
                button12.Text = "Add";
                button11.Text = "Cancel";

            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter description!");
                }
                else if (textBox25.Text == "")
                {
                    MessageBox.Show("Enter Price!");
                }
                else
                {
                    con.Close();
                    string sql2 = "SELECT * FROM laboratory where labdescription='" + textBox1.Text + "'";
                    con.Open();
                    MySqlCommand dbcomm2 = new MySqlCommand(sql2, con);
                    MySqlDataReader dbread2;
                    dbread2 = dbcomm2.ExecuteReader();
                    dbread2.Read();
                    if (dbread2.HasRows)
                    {
                        MessageBox.Show("Laboratory Description already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox6.Clear();
                    }
                    else
                    {
                        bi_Codes bi = new bi_Codes();
                        bi.laboratory(textBox1.Text, textBox25.Text);
                        MessageBox.Show("Laboratory Added!");
                        dataGridView8.DataSource = bi.viewlab();
                        button12.Enabled = true;
                        button12.Text = "New";
                        button11.Enabled = true;
                        button11.Text = "Close";
                        textBox1.Enabled = false;
                        textBox25.Enabled = false;
                        textBox1.Clear();
                        textBox25.Clear();
                    }
                }
            }

        }

        private void bi_Maintenance_Load(object sender, EventArgs e)
        {
          textBox1.Enabled = false;
            bi_Codes bi = new bi_Codes();
            dataGridView2.DataSource = bi.viewmedicine();
            button2.Text = "New";
            bi_Codes b3 = new bi_Codes();
           //dataGridView1.DataSource = b3.viewpxhistory(label1.Text);
            //dataGridView1.Columns[0].Visible =false;
            bi_Codes b2 = new bi_Codes();
            dataGridView8.DataSource = b2.viewlab();

            this.treeView1.HotTracking = true;
            TreeNode root = new TreeNode("Patient Records");
            root.Name = "root";
            treeView1.Nodes.Add(root);
            TreeNode rp = new TreeNode("In Patients");
            rp.Name = "ipx";
            TreeNode outpx = new TreeNode("Out Patients");
            outpx.Name = "opx";
            root.Nodes.Add(outpx);
            root.Nodes.Add(rp);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "root")
            {

                string trysql5 = "SELECT * from registration";
                cmd = new MySqlCommand(trysql5, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "registration");

                dt = ds.Tables["registration"];
                dataGridView10.DataSource = dt;

            }
            else if (e.Node.Name == "ipx")
            {
                string trysql5 = "SELECT * from admit where status= ' '";
                cmd = new MySqlCommand(trysql5, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "admit");

                dt = ds.Tables["admit"];
                dataGridView10.DataSource = dt;
            }
            else if (e.Node.Name == "opx")
            {
                string trysql5 = "SELECT * from consultation";
                cmd = new MySqlCommand(trysql5, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "consultation");

                dt = ds.Tables["consultation"];
                dataGridView10.DataSource = dt;
            }
        }

        private void dataGridView10_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //bi_PatientInformation bip = new bi_PatientInformation();
            //bip.MdiParent = this.MdiParent;
            //bip.Dock = DockStyle.Fill;
            //int jdl = dataGridView10.SelectedCells[0].RowIndex;
            //bip.label1.Text = dataGridView10["admitid", jdl].Value.ToString();
            ////bip.label2.Text = dataGridView10["Status", jdl].Value.ToString();
            //bip.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // int a = dataGridView1.SelectedCells[0].RowIndex;
           // string b = dataGridView1["Patient No.",a].Value.ToString();
           //label3.Text = dataGridView1["Patient Type",a].Value.ToString();
           //label4.Text = dataGridView1["Date", a].Value.ToString();
           // label5.Text = dataGridView1["Time", a].Value.ToString();
           // string sql = "UPDATE admit SET status=?a";
           // con.Open();
           // cmd = new MySqlCommand(sql, con);
           // cmd.Parameters.AddWithValue("?a", "");
           // cmd.ExecuteNonQuery();
           // con.Close();

           // if (label3.Text == "INpatient")
           // {
           //     string sql2 = "Update admit set status=?a where admissiondate='" + label4.Text + "'and admissiontime='" + label5.Text + "'";
           //     con.Open();
           //     cmd = new MySqlCommand(sql2, con);
           //     cmd.Parameters.AddWithValue("?a", "current");
           //     cmd.ExecuteNonQuery();
           //     con.Close();
                
           //     MessageBox.Show("haahahaha");
           //     this.Close();
           //     ////bi_PatientInformation bip = new bi_PatientInformation();
           //     ////bip.label3.Text = label3.Text;
           //     //bip.MdiParent = this.MdiParent;
           //     //bip.Dock = DockStyle.Fill;
           //     //bip.Show();
           //     //this.Close();
           // }
           // else if (label3.Text == "OUTpatient")
           // {
           //     string sql2 = "Update consultation set status=?a where condate='" + label4.Text + "'and contime='" + label5.Text + "'";
           //     con.Open();
           //     cmd = new MySqlCommand(sql2, con);
           //     cmd.Parameters.AddWithValue("?a", "current");
           //     cmd.ExecuteNonQuery();
           //     con.Close();
                
           //     MessageBox.Show("huhuuhuhuhhuh");
           //     this.Close();
           //     //bi_PatientInformation bip = new bi_PatientInformation();
           //     //bip.label3.Text = label3.Text;
           //     //bip.MdiParent = this.MdiParent;
           //     //bip.Dock = DockStyle.Fill;
           //     //bip.Show();
           //     //this.Close();
           // }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (button2.Text == "New")
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                dataGridView2.Enabled = true;
                button2.Text = "Add";
            }
            else if (button2.Text == "Add")
            {
                string sql2;
                con.Close();
                sql2 = "SELECT * FROM medicine where medname='" + textBox3.Text + "'";
                con.Open();
                MySqlCommand dbcomm2 = new MySqlCommand(sql2, con);
                MySqlDataReader dbread2;
                dbread2 = dbcomm2.ExecuteReader();
                dbread2.Read();
                if (dbread2.HasRows)
                {
                    MessageBox.Show("Medicine already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox6.Clear();
                }

                else
                {
                    bi_Codes bi = new bi_Codes();
                    dataGridView2.DataSource = bi.viewmedicine();
                    bi.medicine(textBox3.Text, textBox4.Text, textBox6.Text);
                    dataGridView2.DataSource = bi.viewmedicine();
                    MessageBox.Show("Medicine Added!");
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox6.Clear();
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox6.Enabled = false;
                    dataGridView2.Enabled = false;
                    button2.Text = "New";
                }
                dbread2.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
