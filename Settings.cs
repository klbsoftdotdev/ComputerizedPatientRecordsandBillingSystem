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

    public partial class Settings : Form
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        bi_Codes account;
        bi_Codes account2;
        bi_Codes assign;
        bi_Codes account3;
        bi_Codes uaccount;
        public Settings()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
            account = new bi_Codes();
            account2 = new bi_Codes();
            assign = new bi_Codes();
            account3 = new bi_Codes();
            uaccount = new bi_Codes();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
         
        private void bi_Settings_Load(object sender, EventArgs e)
        {


            //user account
            string sql = "SELECT accountID as 'ACCOUNTID', lastname as 'LAST NAME', firstname as 'FIRST NAME', middlename as 'MIDDLE NAME', username as USERNAME, password as PASSWORD, securityquestion as 'SECURITY QUESTION', securityanswer as 'SECURITY ANSWER',status as STATUS FROM useraccount";
            con.Open();
            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            dt = new DataTable();
            da.Fill(ds, "useraccount");

            DataGridViewImageColumn imgs = new DataGridViewImageColumn();
            imgs.HeaderText = "";
            imgs.Name = "icon";
            //imgs.Image = global::bi_CPRBS.Properties.Resources.images_066;

            dt = ds.Tables["useraccount"];
            dataGridView5.Columns.Add(imgs);
            dataGridView5.DataSource = dt;
            dataGridView5.Columns[0].Width = 30;
            dataGridView5.Columns[9].ReadOnly =true;

            //foreach (DataRow dr in dt.Rows)
            //{
            //    label2.Text = dr["status"].ToString();
            //    if (label2.Text == "Deactivated")
            //    {
            //        dr.DefaultCellStyle.BackColor = Color.Red;
            //    }
            //}

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "";
            img.Name = "icon";
            //img.Image = global::bi_CPRBS.Properties.Resources.images_066;
            dataGridView3.Columns.Add(img);
            dataGridView3.DataSource = assign.assignuser();
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[0].Width = 30;
            dataGridView3.Columns[2].Width = 100;
           // dataGridView2.DataSource = account.loghistcode();
            button1.Text = "Close";
            button2.Text = "New";
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.HeaderText = "";
            img2.Name = "icon";
            //img2.Image = global::bi_CPRBS.Properties.Resources.images_066;
            dataGridView1.Columns.Add(img2);
            //dataGridView1.DataSource = account2.useraccountcode3();
            dataGridView1.Columns[0].Width=20;
            //dataGridView1.Columns[1].Visible=false;
        }
        private void validatepassword()
        {
            //if (textBox5.Text == "")
            //{
            //    label10.Hide();
            //    label9.ForeColor = System.Drawing.Color.Red;
            //    label9.Text = "*8 - 12 Characters";
            //}
            //else
            //{
            //    if ((textBox5.TextLength > 4) || (textBox5.TextLength < 6))
            //    {
            //        label9.Text = "Weak";
            //        label9.ForeColor = System.Drawing.Color.Red;
            //    }
            //    if ((textBox5.TextLength > 6) || (textBox5.TextLength > 10))
            //    {
            //        label9.Text = "Medium";
            //        label9.ForeColor = System.Drawing.Color.Yellow;
            //    }
            //    if (textBox5.TextLength > 12)
            //    {
            //        label9.Text = "Strong";
            //        label9.ForeColor = System.Drawing.Color.Green;
            //    }
            //}
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "New")
            {
                dataGridView5.AllowUserToAddRows = true;
                int i = dt.Rows.Count;
                string cnt = Convert.ToString(i + 1);
                string b = "ACCID" + DateTime.Now.ToString("yyyyMMdd0") + cnt;
                dataGridView5.Columns[1].Visible = false;
                
                button2.Text = "Save";
                button1.Text = "Cancel";
            }
            else if (button2.Text == "Save")
            {
                string sql3 = "INSERT INTO useraccount(lastname, firstname,middlename,username,password,securityquestion,securityanswer,status) VALUES (@1, @2, @3,@4,@5,@6,@7,@8)";
                MySqlCommand dbcomm1 = new MySqlCommand(sql3, con);
                dbcomm1.Parameters.AddWithValue("@1", dataGridView5[1, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@2", dataGridView5[2, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@3", dataGridView5[3, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@4", dataGridView5[4, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@5", dataGridView5[5, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@6", dataGridView5[6, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@7", dataGridView5[7, dataGridView5.CurrentCell.RowIndex].Value.ToString());
                dbcomm1.Parameters.AddWithValue("@8", "Activated");
                dbcomm1.ExecuteNonQuery();

                MessageBox.Show("New Account Created!");
                dataGridView5.Columns[1].Visible = true;
                con.Close();
                string sql = "SELECT lastname as 'LAST NAME', firstname as 'FIRST NAME', middlename as 'MIDDLE NAME', username as USERNAME, password as PASSWORD, securityquestion as 'SECURITY QUESTION', securityanswer as 'SECURITY ANSWER',status as STATUS FROM useraccount";
                con.Open();
                cmd = new MySqlCommand(sql, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "useraccount");

                dt = ds.Tables["useraccount"];
                dataGridView5.DataSource = dt;
                dataGridView5.Columns[8].ReadOnly = true;
            }
            else if (button2.Text == "Deactivate")
            {
                DialogResult dr = MessageBox.Show("Deactivate " + label14.Text + "?", " ", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    Deactivateuser();
                    MessageBox.Show("Account Deactivated!");
                   
                    button2.Text = "A&dd Account";
                    button1.Text = "Close";
                }
            }
         
            



                //if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
                //{
                //     MessageBox.Show("Please fill out all information!", "Adding error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else if(textBox5.Text!=textBox6.Text)
                //{
                //    MessageBox.Show("Password did not match!");
                //}
                //else if (textBox6.TextLength < 4)
                //{
                //    MessageBox.Show("Password must have atleast 4 characters!");
                //}
                //else
                //{
                //    account.useraccountcode2(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text,comboBox2.Text, comboBox1.Text, textBox7.Text);
                //    dataGridView1.DataSource = account3.useraccountcode3();
                //    MessageBox.Show("Account successfully added!");
                //    dataGridView1.Height = 324;
                //    button2.Text = "A&dd Account";
                //    button1.Text = "Close";
                //    }
                //}

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Close")
            {
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    dataGridView5.AllowUserToAddRows = false;
                    button2.Text = "New";
                    button1.Text = "Close";
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label10.Show();
            validatepassword();
        }
       
        private void Activateuser()
        {
            account.Activate(label12.Text);

        }
        private void Deactivateuser()
        {
            account.Deactivate(label12.Text);
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int a;
            a = dataGridView1.SelectedCells[0].RowIndex;
            label12.Text = dataGridView1["userid", a].Value.ToString();
            label11.Text = dataGridView1["Status", a].Value.ToString();
            label14.Text = dataGridView1["User Full Name", a].Value.ToString();

            if (label11.Text == "Activated")
            {
                DialogResult dr = MessageBox.Show("Deactivate " + label14.Text + "?", " ", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    Deactivateuser();
                    MessageBox.Show("Account Deactivated!");
                    //dataGridView1.DataSource = account2.useraccountcode3();
                    button2.Text = "A&dd Account";
                    button1.Text = "Close";
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Activate " + label14.Text + "?", " ", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    Activateuser();
                    MessageBox.Show("Account Activated!");
                    //dataGridView1.DataSource = account2.useraccountcode3();
                    button2.Text = "A&dd Account";
                    button1.Text = "Close";
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int a;
            a = dataGridView3.SelectedCells[0].RowIndex;
            label12.Text = dataGridView3["User Full Name", a].Value.ToString();
            label11.Text = dataGridView3["User Access", a].Value.ToString();
            label10.Text = dataGridView3["Status", a].Value.ToString();
            label1.Text = dataGridView3["userid", a].Value.ToString();
            
            DialogResult dr = MessageBox.Show("Assign "+label12.Text+"?"," " ,MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (label10.Text == "Deactivated")
                {
                    MessageBox.Show("Can't Assign "+label12.Text+" Account is "+label10.Text);
                }
                else
                {
                    Prompt bip = new Prompt();
                    bip.label1.Text = label12.Text;
                    bip.label2.Text = label11.Text;
                    bip.label3.Text = label1.Text;
                    bip.ShowDialog();
                    dataGridView3.DataSource = assign.assignuser();
                }
            }
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
           
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            

        }

        private void button12_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
         
            string trysql2 = "SELECT Medrecordno as 'Record Number', concat(PtGivenName,' ',PtMiddleName,' ',PtLastname)as 'Patient Full Name',Age as 'Age', Sex as Gender, CivilStatus as 'Civil Status', PatientAddress as 'Patient Address', Birthdate as 'Date Of Birth',FathersName as 'Father Name', MothersName as 'Mother Name', Status,remarks  FROM registration where PtLastName like'%" + textBox28.Text + "%' and PtGivenName like'%" + textBox29.Text + "%'";

            cmd = new MySqlCommand(trysql2, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            dt = new DataTable();
            da.Fill(ds, "registration");

            dt = ds.Tables["registration"];
            dataGridView1.DataSource = dt;
            try
            {
                int  jdl = dataGridView7.SelectedCells[0].RowIndex;
                label5.Text = dataGridView7["Record Number", jdl].Value.ToString();
                label6.Text = dataGridView7["Status", jdl].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            { }
            //label1.Text = dataGridView1.Rows.Count.ToString();
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                label49.Text = Convert.ToString(i);

            }
            if (label49.Text == "0")
            {
               
                MessageBox.Show("       No Existing records for \n         " + textBox28.Text + " " + textBox29.Text, "Records not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
            

                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "";
                img.Name = "icon";
                //img.Image = global::bi_CPRBS.Properties.Resources.px1;
                
                Settings s = new Settings();
                s.MdiParent = this.MdiParent;
                s.Dock = DockStyle.Bottom;
                s.panel11.Dock = DockStyle.Fill;
                s.Width = 560;
                s.Height = 249;
                s.dataGridView7.Columns.Add(img);
                s.dataGridView7.DataSource = dt;
                s.dataGridView7.Columns[0].Width = 20;

                for (int i = 0; i < dataGridView7.Rows.Count; i++)
                {
                    s.tsl1.Text = Convert.ToString(i);

                }
                s.Show();
                label49.Text = "0";
                this.Close();

            }
        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sql3 = "select * from admit order by admitid desc";
            //con.Open();
            //cmd = new MySqlCommand(sql3, con);
            //cmd.Parameters.AddWithValue("?a", "");
            //cmd.ExecuteNonQuery();
            //con.Close();
            int a = dataGridView7.SelectedCells[0].RowIndex;
            string b = dataGridView7["Record Number",a].Value.ToString();
             string c = dataGridView7["Patient Full Name",a].Value.ToString();

            //bi_PatientInformation bip = new bi_PatientInformation();
            //bip.MdiParent = this.MdiParent;
            //bip.label1.Text = b;
            ////bip.tabPage1.Text = c + " Medical History";
            //bip.Dock = DockStyle.Fill;
            //bip.Show();
            this.Close();
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void dataGridView10_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView5.AllowUserToAddRows = false;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //button2.Text = "Update";
            //button1.Text = "Cancel";
        }

        private void dataGridView5_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView5.SelectedCells[0].RowIndex;
            string b = dataGridView5["STATUS",a].Value.ToString();
            if (b == "Activated")
            {
                button2.Text = "Deactivate";
                button1.Text = "Cancel";
            }
            else
            {
                button2.Text = "Activate";
                button1.Text = "Cancel";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Brush _TextBrush;

            //// Get the item from the collection.
            //TabPage _TabPage = tabControl1.TabPages[e.Index];

            //// Get the real bounds for the tab rectangle.
            //Rectangle _TabBounds = tabControl1.GetTabRect(e.Index);

            //if (e.State == DrawItemState.Selected)
            //{
            //    // Draw a different background color, and don't paint a focus rectangle.
            //    _TextBrush = new SolidBrush(Color.Black);
            //    g.FillRectangle(Brushes.White, e.Bounds);
            //}
            //else
            //{
            //    _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
            //    e.DrawBackground();
            //}

            //// Use our own font. Because we CAN.
            //Font _TabFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            //// Draw string. Center the text.
            //StringFormat _StringFlags = new StringFormat();
            //_StringFlags.Alignment = StringAlignment.Center;
            //_StringFlags.LineAlignment = StringAlignment.Center;
            //g.DrawString(_TabPage.Text, _TabFont, _TextBrush,
            //             _TabBounds, new StringFormat(_StringFlags));
        }

   
        //private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //tabControl1.DrawItem Dim g As Graphics();
        //}

  


    }
   }
        
   