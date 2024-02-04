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
    public partial class Login : Form
    {
        
           

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        int jdl;
        bi_Codes bicode;
        bi_Codes loghist;

        public Login()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
            bicode = new bi_Codes();
            loghist = new bi_Codes();
        }

        private void loghistcode()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date);
            string trysql1 = "insert into loginhistory(userid, timelogin) values(?a, ?a2)";
            con.Open();
            cmd = new MySqlCommand(trysql1, con);
            cmd.Parameters.AddWithValue("?a", label1.Text);
            cmd.Parameters.AddWithValue("?a2", date);
            cmd.ExecuteNonQuery();
          
        }
        public void hospitaln()
        {
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter username of password!", "Access denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (textBox1.Text != textBox3.Text || textBox2.Text != textBox4.Text)
            {
                MessageBox.Show("Invalid username of password!", "Access denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                if(textBox5.Text =="CPRBS-ADM")
                {
                    dataGridView1.DataSource = bicode.logincode1(textBox1.Text);
                    bi_Codes bi = new bi_Codes();
                    dataGridView1.DataSource = bi.hname();

                    int a = dataGridView1.SelectedCells[0].RowIndex;
                    string b = dataGridView1["hname", a].Value.ToString();

                   

                Main bim = new Main();
                bim.IsMdiContainer = true;
                bim.WindowState = FormWindowState.Maximized;
                bim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                bim.BackgroundImage = new Bitmap(@"Resources\admin_bg.jpg");
                bim.adm_file.Visible = true;
                bim.adm_help.Visible = true;
                bim.adm_options.Visible = true;
                bim.tshh.Text = b;
                //bim.tsb1.Visible = false;
                //bim.tsb2.Visible = false;
                //bim.tsb4.Visible = true;
                //bim.tsb7.Visible = false;
                //bim.tsb8.Visible = true;
                //bim.prsett.Visible = false;
                //bim.prrep.Visible = false;
                bim.utype.Text = "Administrator";
                //bim.panel1.Hide();
                //bim.twindow.Text = "Window: Administrator";
               
               
                //bim.splitContainer1.Visible = false;
                //bim.splitContainer2.Visible = false;
                //bim.tsrecordmanager.Visible = false;
                bim.Text = "Computerized Patient Records and Billing System (Administrator)";

                bim.displayname.Text = label2.Text;
                bi_Codes.usertype = label6.Text;
                bim.Show();
                loghistcode();
                this.Hide();
                }
                else if (textBox5.Text == "CPRBS-PR")
                {

                    dataGridView1.DataSource = bicode.logincode1(textBox1.Text);
                    bi_Codes bi = new bi_Codes();
                    dataGridView1.DataSource = bi.hname();

                    int a = dataGridView1.SelectedCells[0].RowIndex;
                    string b = dataGridView1["hname", a].Value.ToString();
   //bi_AdmissionBilling biv = new bi_AdmissionBilling();
                   
                    Main bim = new Main();
                    bim.IsMdiContainer = true;
                    bim.WindowState = FormWindowState.Maximized;
                    bim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    bim.BackgroundImage = new Bitmap(@"Resources\patientrecords_bg.jpg");
                    bim.adm_file.Visible = false;
                    bim.adm_help.Visible = false;
                    bim.adm_options.Visible = false;
                    bim.tshh.Text = b;
                    bim.utype.Text = "Clerk";
                    //bim.tsb3.Visible = false;
                    //bim.tsb4.Visible = false;
                    //bim.tsb6.Visible = false;
                    //bim.prsett.Visible = true;
                    //bim.prrep.Visible = true;
                    //bim.tsb7.Visible = false;
                    bim.menuStrip1.Visible = true;
                    //bim.panel1.Dock = DockStyle.Left;
                    //bim.tsb8.Visible = false;
                    //bim.tsb9.Visible = false;
                    //bim.splitContainer1.Visible = false;
                    //bim.splitContainer2.Visible = false;
                    //bim.pnl2.Visible = true;
                    //biv.MdiParent = bim;
                    bim.Text = "Computerized Patient Records and Billing System (Patient Records)";
                    //biv.Dock = DockStyle.Fill;
                    //biv.Show();
                    bim.displayname.Text = label2.Text;
                    bim.Show();
                    this.Hide();
                    loghistcode();
                 
                   
                }
                else if (textBox5.Text == "CPRBS-BS")
                {

                    dataGridView1.DataSource = bicode.logincode1(textBox1.Text);
                    bi_Codes bi = new bi_Codes();
                    dataGridView1.DataSource = bi.hname();

                    int a = dataGridView1.SelectedCells[0].RowIndex;
                    string b = dataGridView1["hname", a].Value.ToString();

                    Main bim = new Main();
                    bim.IsMdiContainer = true;
                    bim.WindowState = FormWindowState.Maximized;
                    bim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    //bim.BackgroundImage = global::bi_CPRBS.Properties.Resources.AAA;
                    bi_Codes.username = label2.Text;
                    bi_Codes.usertype = label6.Text;
                    bim.adm_file.Visible = false;
                    bim.adm_help.Visible = false;
                    bim.adm_options.Visible = false;
                    bim.tshh.Text = b;
                    bim.utype.Text = "Cashier";
                    //bim.tsb3.Visible = false;
                    //bim.tsb1.Visible = false;
                    //bim.tsb2.Visible = false;
                    //bim.splitContainer1.Visible = false;
                    //bim.splitContainer2.Visible = false;
                    //bim.tsrecordmanager.Visible = false;
                    //bim.tsb4.Visible = false;
                    //bim.tsb6.Visible = false;
                    //bim.prsett.Visible = false;
                    //bim.prrep.Visible = false;
                    bim.menuStrip1.Visible = true;                                                                                            
                    //bim.tsb7.Visible = true;
                    //bim.tsb8.Visible = true;
                    //bim.tsb9.Visible = false;
                    bim.Text = "Computerized Patient Records and Billing System (Billing System)";
                    bim.displayname.Text = label2.Text;
                    bim.Show();
                   
                    this.Hide();
                    loghistcode();
                   
                }
            }
               
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a;
            dataGridView1.DataSource = bicode.logincode1(textBox1.Text);
            try
            {
                a=dataGridView1.SelectedCells[0].RowIndex;
                textBox3.Text = dataGridView1["username", a].Value.ToString();
                textBox4.Text = dataGridView1["password", a].Value.ToString();
                textBox5.Text = dataGridView1["access", a].Value.ToString();
                label1.Text = dataGridView1["userid", a].Value.ToString();
                label2.Text = dataGridView1["fullname", a].Value.ToString();


            }
            catch (ArgumentOutOfRangeException)
            { }
        }


        private void bi_Login_Load(object sender, EventArgs e)
        {
             textBox1.Focus();
             dataGridView1.DataSource = bicode.logincode1(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Forgot bif = new Forgot();
            //bif.Show();
            //this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_StyleChanged(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

       

        
       
    }
}
