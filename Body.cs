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
    public partial class Body : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        bi_Codes pxinfo;
        
        const int LEADING_SPACE = 12;
        const int CLOSE_SPACE = 15;
        const int CLOSE_AREA = 15;

        public void myupdate(string newValue)
        {
            label6.Text = newValue;
        }
        public void Update(string newValue)
        {
            label1.Text = newValue;
            
            bool found = false;
            foreach (TabPage tab in tabControl1.TabPages)
            {
               
                if (newValue.Equals(tab.Text))
                {
                    tabControl1.SelectedTab = tab;
                    found = true;
                }
            }
            if (!found)
            {
                if (label1.Text == "System General Records")
                {
                    this.Text = label1.Text;
                    SystemGeneralRecords sgr = new SystemGeneralRecords();
                    TabPage page = new TabPage();
                    page.Text = "System General Records";
                    sgr.TopLevel = false;
                    sgr.Visible = true;
                    sgr.FormBorderStyle = FormBorderStyle.None;
                    sgr.Dock = DockStyle.Fill;
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    page.Controls.Add(sgr);
                    sgr.Show();
                }
                else if (label1.Text == "Account Settings")
                {
                    this.Text = label1.Text;
                    gSettings sgr = new gSettings();
                    TabPage page = new TabPage();
                    page.Text = "Settings";
                    sgr.TopLevel = false;
                    sgr.Visible = true;
                    sgr.FormBorderStyle = FormBorderStyle.None;
                    sgr.Dock = DockStyle.Fill;
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    page.Controls.Add(sgr);
                    sgr.Show();
                }
                else if (label1.Text == "Login History")
                {
                    this.Text = label1.Text;
                    gSettings bis = new gSettings();
                    TabPage page = new TabPage();
                    page.Text = "Login History";
                    bis.TopLevel = false;
                    bis.Visible = true;
                    bis.FormBorderStyle = FormBorderStyle.None;
                    bis.Dock = DockStyle.Fill;
                    bis.dataGridView1.Dock = DockStyle.Fill;
                    bis.tabControl1.Hide();
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    page.Controls.Add(bis);
                    bis.Show();
                }
                else if (label1.Text == "Patients List")
                {
                    Patient pm = new Patient();
                    TabPage page = new TabPage();
                    page.Text = "Patients List";
                    pm.TopLevel = false;
                    pm.Visible = true;
                    pm.FormBorderStyle = FormBorderStyle.None;
                    pm.Dock = DockStyle.Fill;
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    page.Controls.Add(pm);
                    pm.panel1.Hide();
                    pm.panel2.Hide();
                    pm.panel3.Dock = DockStyle.Fill;
                    pm.dataGridView2.Dock = DockStyle.Fill;
                    pm.Show();
                    con.Close();
                    string mysql = "SELECT  Medrecordno as 'RECORD NUMBER',concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as 'PATIENT FULLNAME', room as 'ROOM',PtTelno as 'TELEPHONE NO.',Sex as 'GENDER',CivilStatus as 'CIVIL STATUS',Birthdate as 'BIRTH DATE', Age as 'AGE',Birthplace as 'PLACE OF BIRTH',Nationality as 'NATIONALITY',Religion as 'RELIGION',Occupation as 'OCCUPATION', PatientAddress as 'ADDRESS' from registration";
                    con.Open();
                    cmd = new MySqlCommand(mysql, con);
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable dt = new DataTable();
                    da.Fill(ds, "registration");
                    dt = ds.Tables["registration"];
                    pm.dataGridView2.DataSource = dt;

                }
                else if (label1.Text == "Add Patient")
                {
                    Patient pm = new Patient();
                    TabPage page = new TabPage();
                    page.Text = "Add Patient";
                    pm.TopLevel = false;
                    pm.Visible = true;
                    pm.FormBorderStyle = FormBorderStyle.None;
                    pm.Dock = DockStyle.Fill;
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    page.Controls.Add(pm);
                    pm.panel1.Hide();
                    pm.panel3.Hide();
                    pm.panel2.Dock = DockStyle.Fill;
                    pm.Show();
                    

                }
                else
                {
                    Patient px = new Patient();
                    TabPage page = new TabPage();
                    page.Text = label1.Text;
                    px.TopLevel = false;
                    px.Visible = true;
                    px.FormBorderStyle = FormBorderStyle.None;
                    px.Dock = DockStyle.Fill;
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    page.Controls.Add(px);

                    con.Close();
                    string trysql9 = "SELECT * from patienthistory where pxname='" + label1.Text + "'";
                    con.Open();
                    cmd = new MySqlCommand(trysql9, con);
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable dt9 = new DataTable();
                    da.Fill(ds, "patienthistory");
                    dt9 = ds.Tables["patienthistory"];
                    px.dataGridView1.DataSource = dt9;
                }
            }
        }

        public Body()
        {

            InitializeComponent(); 
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
            pxinfo = new bi_Codes();
        }

        private Point _imageLocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);

       

        
        private void PatientInformation_Load(object sender, EventArgs e)
        {
            tabControl1.Padding = new System.Drawing.Point(21, 3);
           
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - CLOSE_AREA, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + LEADING_SPACE, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = tabControl1.GetTabRect(this.tabControl1.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
            if (closeButton.Contains(e.Location))
            {
                this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
            }
        }
       
      
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabCount == 0)
            {
                this.Close();
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {

            bool found = false;
            foreach (TabPage tab in tabControl1.TabPages)
            {

                if ("Patient Chart [ " + label4.Text + " ]" == tab.Text)
                {
                    tabControl1.SelectedTab = tab;
                    found = true;
                }
            }
            if (!found)
            {
                Patient px = new Patient();
                TabPage page = new TabPage();
                page.Text = "Patient Chart [ " + label4.Text + " ]";
                px.TopLevel = false;
                px.Visible = true;
                px.FormBorderStyle = FormBorderStyle.None;
                px.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(page);
                tabControl1.SelectedTab = page;
                px.label1.Text = label4.Text;
                page.Controls.Add(px);
                px.panel3.Hide();
                px.panel2.Hide();
                con.Close();
                string trysql9 = "SELECT pxname,pxno,date from patienthistory where pxno='"+label4.Text+"'";
                con.Open();
                cmd = new MySqlCommand(trysql9, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt9 = new DataTable();
                da.Fill(ds, "patienthistory");
                dt9 = ds.Tables["patienthistory"];
                px.dataGridView1.DataSource = dt9;

                int a = px.dataGridView1.SelectedCells[0].RowIndex;
                px.label2.Text = px.dataGridView1["pxno", a].Value.ToString();
                //px.label3.Text = "Gender : " + px.dataGridView1["Sex", a].Value.ToString();
                //px.label4.Text = "Birthday : " + px.dataGridView1["Birthdate", a].Value.ToString();
                //px.label6.Text = "Status : " + px.dataGridView1["CivilStatus", a].Value.ToString();
                //px.label5.Text = "Address : " + px.dataGridView1["PatientAddress", a].Value.ToString();
                //px.lblpxname.Text = px.dataGridView1["PatientName", a].Value.ToString();

                    
                
            }
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            //bool found = false;
            //foreach (TabPage tab in tabControl1.TabPages)
            //{
            //    if ("Patients List" == tab.Text)
            //    {
            //        tabControl1.SelectedTab = tab;
            //        found = true;
            //    }
            //}
            //if (!found)
            //{
            //    PatientMgnt pm = new PatientMgnt();
            //    TabPage page = new TabPage();
            //    page.Text = "Patients List";
            //    pm.TopLevel = false;
            //    pm.Visible = true;
            //    pm.FormBorderStyle = FormBorderStyle.None;
            //    pm.Dock = DockStyle.Fill;
            //    tabControl1.TabPages.Add(page);
            //    tabControl1.SelectedTab = page;
            //    page.Controls.Add(pm);
            //    pm.Show();
            //    con.Close();
            //    string mysql = "SELECT  Medrecordno as 'RECORD NUMBER',concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as 'PATIENT DISPLAY NAME', room as 'ROOM',PtTelno as 'TELEPHONE NO.',Sex as 'GENDER',CivilStatus as 'CIVIL STATUS',Birthdate as 'BIRTH DATE', Age as 'AGE',Birthplace as 'PLACE OF BIRTH',Nationality as 'NATIONALITY',Religion as 'RELIGION',Occupation as 'OCCUPATION', PatientAddress as 'ADDRESS' from registration where PtLastName like '" + label6.Text + "%'";
            //    con.Open();
            //    cmd = new MySqlCommand(mysql, con);
            //    da = new MySqlDataAdapter(cmd);
            //    ds = new DataSet();
            //    DataTable dt = new DataTable();
            //    da.Fill(ds, "registration");
            //    dt = ds.Tables["registration"];
            //    pm.dataGridView1.DataSource = dt;
            //}
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
