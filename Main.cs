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
    public partial class Main : Form
    {
        private Body myaction { get; set; }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        int jdl;
        public Main()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null)
            {
                this.IsMdiContainer = false;
            }
            date.Text = DateTime.Now.ToString("MM/dd/yyyy");
            time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void logHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                myaction.Update("Account Settings");
            }
            else
            {
                this.IsMdiContainer = true;
                myaction = new Body();
                myaction.MdiParent = this;
                myaction.Update("Account Settings");
                myaction.WindowState = FormWindowState.Maximized;
                myaction.Show();
            }
            //gSettings bi = new gSettings();
            //bi.tabControl1.SelectedTab = bi.tabPage1;
            //bi.ShowDialog();
        }

        private void bi_Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = false;

            //Form2Instance = new PatientInformation();
            //Form2Instance.Show();
            //this.IsMdiContainer = false;

            //string trysql9 = "SELECT pxname from patienthistory";
            //con.Open();
            //cmd = new MySqlCommand(trysql9, con);
            //da = new MySqlDataAdapter(cmd);
            //ds = new DataSet();
            //DataTable dt9 = new DataTable();
            //da.Fill(ds, "pxname");
            //dt9 = ds.Tables["pxname"];

            //TreeNode phy = new TreeNode();
            //phy.Name = "phy";
            //foreach (DataRow dr5 in dt9.Rows)
            //{

            //    phy.Nodes.Add(dr5["pxname"].ToString());
            //}

            //phy.ImageIndex = 2;
            //phy.SelectedImageIndex = 2;
            //treeView1.Nodes.Add(phy);
            //phy.Expand();
            //treeView1.HotTracking = true;
            //logouttsm.Visible = false;
            //showToolbarToolStripMenuItem.Enabled = false;
            //showToolbarToolStripMenuItem.CheckState = CheckState.Checked;
            //SystemGeneralRecords sgr = new SystemGeneralRecords();
            //sgr.label5.Text = tsl.Text;
            //timer1.Start();
            //window.Text = "User: "+bi_Codes.username;
           
            
            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //img.HeaderText = "";
            //img.Name = "icon";
            ////img.Image = global::bi_CPRBS.Properties.Resources.recico;
            //dataGridView2.Columns.Add(img);
           
            
 
        }

        private void loginHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            //gSettings bis = new gSettings();
            //bis.tabControl1.Hide();
            //bis.Text = "Loghistory";
            //bis.MdiParent = this;
            //bis.dataGridView1.Dock = DockStyle.Fill;
            //bis.WindowState = FormWindowState.Maximized;
            //bis.Show();
            if (ActiveMdiChild != null)
            {
                myaction.Update("Login History");
            }
            else
            {
                this.IsMdiContainer = true;
                myaction = new Body();
                myaction.MdiParent = this;
                myaction.Update("Login History");
                myaction.WindowState = FormWindowState.Maximized;
                myaction.Show();
            }
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void assignUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings bis = new Settings();
            bis.MdiParent = this;
            bis.panel4.Dock = DockStyle.Fill;
            bis.Width = 614;
            bis.Height = 339;
            bis.Text = "Assign User/Account";
            bis.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitCtrlXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
                con.Close();
                string trysql = "select logno from loginhistory order by logno desc";
                con.Open();
                cmd = new MySqlCommand(trysql, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "loginhistory");

                dt = ds.Tables["loginhistory"];
                dataGridView1.DataSource = dt;
                jdl = dataGridView1.SelectedCells[0].RowIndex;
                label2.Text = dataGridView1["logno", jdl].Value.ToString();

                DateTime date = DateTime.Now;
                Console.WriteLine(date);
                string sql = "Update loginhistory set timelogout=?a where logno='" + label2.Text + "'";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?a", date);
                cmd.ExecuteNonQuery();


           
        }
        private void logout()
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Logout?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                con.Close();
                string trysql = "select logno from loginhistory order by logno desc";
                con.Open();
                cmd = new MySqlCommand(trysql, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "loginhistory");

                dt = ds.Tables["loginhistory"];
                dataGridView1.DataSource = dt;
                jdl = dataGridView1.SelectedCells[0].RowIndex;
                label2.Text = dataGridView1["logno", jdl].Value.ToString();

                DateTime date = DateTime.Now;
                Console.WriteLine(date);
                string sql = "Update loginhistory set timelogout=?a where logno='" + label2.Text + "'";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?a", date);
                cmd.ExecuteNonQuery();
                Login bil = new Login();
                bil.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void pat_logout_Click(object sender, EventArgs e)
        {
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login bil = new Login();
            bil.Show();

            this.Hide();
        }

        private void exitCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit?","", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

        private void iNPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bi_Registration bia = new bi_Registration();
            //bia.MdiParent = this;
            //bia.Dock = DockStyle.Left;
            //bia.Show();
        }

        private void searchRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void medicalHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bi_Medicalhistory bmh = new bi_Medicalhistory();
            //bmh.MdiParent = this;
            //bmh.Dock = DockStyle.Left;
            //bmh.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             DialogResult dr = MessageBox.Show("Backup System Database?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (dr == DialogResult.OK)
             {
                 FolderBrowserDialog fbd = new FolderBrowserDialog();
                 if (fbd.ShowDialog() == DialogResult.OK)
                 {
                     label3.Text = fbd.SelectedPath;
                     string constring = "server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''";
                     string file = label3.Text + "\\CPRBSM_BACKUP" + DateTime.Now.Ticks + ".sql";
                     using (MySqlConnection conn = new MySqlConnection(constring))
                     {
                         using (MySqlCommand cmd = new MySqlCommand())
                         {
                             using (MySqlBackup mb = new MySqlBackup(cmd))
                             {
                                 cmd.Connection = conn;
                                 conn.Open();
                                 mb.ExportToFile(file);
                                 conn.Close();
                             }
                         }
                     }
                     MessageBox.Show("Backup Completed!!");
                 }
             }
             
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void dkdkdkdkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            //bi_Registration bia = new bi_Registration();
            //bia.MdiParent = this;
            //bia.Dock = DockStyle.Left;
            //bia.tsb2.Enabled = false;
            //bia.newToolStripButton.Enabled = false;
            //bia.Show();
        }

        private void backupSystemDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Backup System Database?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    label3.Text = fbd.SelectedPath;
                    string constring = "server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''";
                    string file = label3.Text + "\\CPRBSM_BACKUP" + DateTime.Now.Ticks + ".sql";
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ExportToFile(file);
                                conn.Close();
                            }
                        }
                    }
                    MessageBox.Show("Backup Completed!!");
                }
            }
             
        }

        private void logHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Settings bis = new Settings();
            bis.MdiParent = this;
            bis.panel3.Dock = DockStyle.Fill;
            bis.Width = 602;
            bis.Height = 539;
            bis.Show();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void addHospitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string trysql = "select * from hospital";
            //cmd = new MySqlCommand(trysql, con);
            //da = new MySqlDataAdapter(cmd);
            //ds = new DataSet();
            //dt = new DataTable();
            //da.Fill(ds, "hospital");

            //dt = ds.Tables["hospital"];
            //dataGridView1.DataSource = dt;
            //int i = dt.Rows.Count;
            //string cnt = Convert.ToString(i + 1);


            HospitalMgnt bis = new HospitalMgnt();
            bis.MdiParent = this;
            bis.panel5.Dock = DockStyle.Fill;
            bis.Width = 536;
            bis.Height = 478;
            bis.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void addRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospitalMgnt bis = new  HospitalMgnt();
            bis.MdiParent = this;
            bis.panel7.Dock = DockStyle.Fill;
            bis.Width = 529;
            bis.Height = 447;
            bis.Show();
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            HospitalMgnt bis = new HospitalMgnt();
            bis.MdiParent = this;
            bis.panel9.Dock = DockStyle.Fill;
            bis.Width = 623;
            bis.Height = 520;
            //bis.textBox12.Text = "00" + cnt;
            bis.Show();
        }

        private void admissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    bi_Admission bi = new bi_Admission();
        //    bi.panel2.Dock = DockStyle.Fill;
        //    bi.Width = 1050;
        //    bi.Height = 565;
        //    bi.ShowDialog();

        }

        private void laboratoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Maintenance bis = new Maintenance();
            bis.MdiParent = this;
            bis.panel14.Dock = DockStyle.Fill;
            bis.Width = 433;
            bis.Height = 407;
            bis.Show();
        }

        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospitalMgnt bis = new HospitalMgnt();
            bis.MdiParent = this;
            bis.panel16.Dock = DockStyle.Fill;
            bis.Width = 553;
            bis.Height = 420;
            bis.Dock = DockStyle.Fill;
            bis.Show();
        }

        private void searchRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //bi_Settings bis = new bi_Settings();
            //bis.MdiParent = this;
            //bis.panel11.Dock = DockStyle.Fill;
            //bis.Width = 582;
            //bis.Height = 265;
            //bis.Dock = DockStyle.Bottom;
            //bis.Show();
        }

        private void viewPatientRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //bi_PatientInformation bip = new bi_PatientInformation();
            //bip.MdiParent = this;
            //bip.Dock = DockStyle.Fill;
            //bip.Show();
            Settings bis = new Settings();
            bis.MdiParent = this;
            bis.panel18.Dock = DockStyle.Fill;
            bis.panel18.Visible = true;
            bis.Width = 500;
            bis.Height = 323;
            bis.Show();

        }

        private void patientRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bi_Registration bia = new bi_Registration();
            //bia.MdiParent = this;
            //bia.Dock = DockStyle.Left;
            //bia.Show();
        }

        private void updateRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //bi_Update bis = new bi_Update();
            //bis.MdiParent = this;
            //bis.Dock = DockStyle.Fill;
            //bis.Show();

        }

        private void tsb9_Click(object sender, EventArgs e)
        {
            
        }

        private void tryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Maintenance bis = new Maintenance();
            bis.MdiParent = this;
            bis.panel2.Dock = DockStyle.Fill;
            bis.panel2.Visible = true;
            bis.Width = 379;
            bis.Height = 320;
            bis.Show();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bi_Consultation bi = new bi_Consultation();
            //bi.panel1.Dock = DockStyle.Fill;
            //bi.Width = 965;
            //bi.Height = 516;
            //bi.ShowDialog();
        }

        private void medicalHistoryEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void medicalHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //bi_Medicalhistory bis = new bi_Medicalhistory();
            //bis.MdiParent = this;
            //bis.Dock = DockStyle.Left;
            //bis.Show();
        }

        private void fffffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bi_AdmissionBilling bis = new bi_AdmissionBilling();
            //bis.MdiParent = this;
            //bis.Dock = DockStyle.Left;
            //bis.Show();
            //TabPage page = new TabPage();
            //page.Text = "Admission Record";
            //bi_AdmissionBilling frm6 = new bi_AdmissionBilling();
            ////panel2.Dock = DockStyle.Left;
            //frm6.TopLevel = false;
            //frm6.Visible = true;
            //frm6.FormBorderStyle = FormBorderStyle.None;
            //frm6.Dock = DockStyle.Fill;
            //tabControl1.TabPages.Add(page);
            //page.Controls.Add(frm6);
            //frm6.AutoScroll = true;
            //tabControl1.SelectedTab = page;
        }

        private void tsb8_Click(object sender, EventArgs e)
        {

        }

        private void consultationBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bi_ConsultationBilling bic = new bi_ConsultationBilling();
            //bic.MdiParent = this;
            //bic.Dock = DockStyle.Left;
            //bic.Show();
        }

        private void medicineOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maintenance bis = new Maintenance();
            bis.MdiParent = this;
            bis.panel5.Dock = DockStyle.Fill;
            bis.panel5.Visible = true;
            bis.Width = 499;
            bis.Height = 425;
            bis.Show();
        }

        private void oUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void admissionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //bi_Admission bi = new bi_Admission();
            //bi.panel2.Dock = DockStyle.Fill;
            //bi.Width = 687;
            //bi.Height = 688;
            //bi.ShowDialog();
        }

        private void consultationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //bi_Consultation bi = new bi_Consultation();
            //bi.panel1.Dock = DockStyle.Fill;
            //bi.Width = 965;
            //bi.Height = 516;
            //bi.ShowDialog();
        }

        private void viewPatientRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //bi_ViewPatient biv = new bi_ViewPatient();
            //biv.MdiParent = this;
            //biv.Dock = DockStyle.Left;
            //biv.Show();

        }

        private void laboratoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maintenance bis = new Maintenance();
            bis.MdiParent = this;
            bis.panel14.Dock = DockStyle.Fill;
            bis.Width = 433;
            bis.Height = 407;
            bis.Show();
        }

        private void medicineOthersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Maintenance bis = new Maintenance();
            bis.MdiParent = this;
            bis.panel5.Dock = DockStyle.Fill;
            bis.panel5.Visible = true;
            bis.Width = 498;
            bis.Height = 399;
            bis.Show();
        }

        private void iNPatientRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //bi_Admission bi = new bi_Admission();
            //bi.panel1.Dock = DockStyle.Fill;
            //bi.Width = 960;
            //bi.Height = 610;
            //bi.ShowDialog();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            //con.Close();
            //string trysql = "SELECT Medrecordno as 'Record No.', concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as 'Patient Full Name' FROM registration order by PtLastName asc";
            //con.Open();
            //cmd = new MySqlCommand(trysql, con);
            //da = new MySqlDataAdapter(cmd);
            //ds = new DataSet();
            //dt = new DataTable();
            //da.Fill(ds, "registration");

            //dt = ds.Tables["registration"];
            //dataGridView2.DataSource = dt;
            //dataGridView2.Columns[0].Width = 30;
            //dataGridView2.Columns[1].Width = 100;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //    con.Close();
            //    string trysql1 = "SELECT recordnumber as 'Record No.', patientname as 'Patient Full Name' FROM admit where status='Admitted' and patientname like '%"+textBox1.Text+"%'";
            //    con.Open();
            //    cmd = new MySqlCommand(trysql1, con);
            //    da = new MySqlDataAdapter(cmd);
            //    ds = new DataSet();
            //    dt = new DataTable();
            //    da.Fill(ds, "admit");

            //    dt = ds.Tables["admit"];
            //    dataGridView3.DataSource = dt;
            //    dataGridView3.Columns[0].Width = 105;
            //    for (int i = 0; i < dataGridView3.Rows.Count; i++)
            //    {
            //        tss.Text = "Total: " + Convert.ToString(i);
            //    }
            //    timer1.Stop();
            //}
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    int a = dataGridView2.SelectedCells[0].RowIndex;
        //    string b = dataGridView2["Record No.", a].Value.ToString();
        //    string c = dataGridView2["Patient Full Name", a].Value.ToString();

            //bi_PatientInformation bip = new bi_PatientInformation();
            //bip.MdiParent = this;
            //bip.label1.Text = b;
            ////bip.tabPage1.Text = c + " Medical History";
            //bip.Dock = DockStyle.Fill;
            //bip.Show();
        }

        private void prrep_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //bi_Consultation bi = new bi_Consultation();
            //bi.panel2.Dock = DockStyle.Fill;
            //bi.Width = 1032;
            //bi.Height = 551;
            //bi.ShowDialog();
        }

        private void generalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                myaction.Update("System General Record");
            }
            else
            {
                this.IsMdiContainer = true;
                myaction = new Body();
                myaction.MdiParent = this;
                myaction.Update("System General Records");
                myaction.WindowState = FormWindowState.Maximized;
                myaction.Show();
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            Settings bis = new Settings();
            bis.MdiParent = this;
            bis.FormBorderStyle = FormBorderStyle.None;
            bis.panel7.Dock = DockStyle.Fill;
            bis.Dock = DockStyle.Right;
            bis.Show();
        }

        private void hideToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (toolStrip1.Visible == true)
            //{
            //    toolStrip1.Hide(); 
            //    hideToolbarToolStripMenuItem.Enabled = false;
            //    hideToolbarToolStripMenuItem.CheckState = CheckState.Checked;
            //    showToolbarToolStripMenuItem.CheckState = CheckState.Unchecked;
            //    showToolbarToolStripMenuItem.Enabled = true;
            //    logouttsm.Visible = true;
            //}
            
        }

        private void showToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (toolStrip1.Visible == false)
            //{
            //    toolStrip1.Show();
            //    showToolbarToolStripMenuItem.Enabled = false;
            //    hideToolbarToolStripMenuItem.Enabled = true;
            //    showToolbarToolStripMenuItem.CheckState = CheckState.Checked;
            //    hideToolbarToolStripMenuItem.CheckState = CheckState.Unchecked;
            //    logouttsm.Visible = false;
            //}
        }

        private void logoutToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
           // logout();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.IsMdiContainer = true;
            gSettings bis = new gSettings();
            bis.tabControl1.Hide();
            bis.Text = "Loghistory";
            bis.MdiParent = this;
            bis.dataGridView1.Dock = DockStyle.Fill;
            bis.WindowState = FormWindowState.Maximized;
            bis.Show();
        }

        private void settToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gSettings bi = new gSettings();
            bi.tabControl1.SelectedTab = bi.tabPage2;
            bi.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
           
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (ActiveMdiChild != null)
            //{
            //    myaction.Update(""+treeView1.SelectedNode.Text); 
            //}
            //else
            //{
            //    this.IsMdiContainer = true;
            //    myaction = new Body();
            //    myaction.MdiParent = this;
            //    myaction.Update("" + treeView1.SelectedNode.Text);
            //    myaction.WindowState = FormWindowState.Maximized;
            //    myaction.Show();
            //}
        }

        private void logouttsm_DropDownStyleChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click_3(object sender, EventArgs e)
        {
            logout();
        }

        private void settingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gSettings set = new gSettings();
            set.ShowDialog();
        }

        private void patiemtGeneralListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                myaction.Update("Patients List");
            }
            else
            {

                this.IsMdiContainer = true;
                myaction = new Body();
                myaction.MdiParent = this;
                myaction.Update("Patients List");
                myaction.WindowState = FormWindowState.Maximized;
                myaction.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void tabpage2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            logout();
        }

        private void searchpx_Click(object sender, EventArgs e)
        {
            //Form myfrm = System.Windows.Forms.Application.OpenForms.OfType<PatientMgnt>().First();
            //Control lbl3 = myfrm.Controls.Find("label3", true).First();
            //((Label)lbl3).Text = searchpx.Text;
        }

        private void searchpx_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Form myfrm = System.Windows.Forms.Application.OpenForms.OfType<PatientMgnt>().First();
            //    Control dgv = myfrm.Controls.Find("dataGridView1", true).First();
            //    string mysql = "SELECT  Medrecordno as 'RECORD NUMBER',concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as 'PATIENT DISPLAY NAME', room as 'ROOM',PtTelno as 'TELEPHONE NO.',Sex as 'GENDER',CivilStatus as 'CIVIL STATUS',Birthdate as 'BIRTH DATE', Age as 'AGE',Birthplace as 'PLACE OF BIRTH',Nationality as 'NATIONALITY',Religion as 'RELIGION',Occupation as 'OCCUPATION', PatientAddress as 'ADDRESS' from registration where PtLastName like '" + searchpx.Text + "%'";
            //    con.Open();
            //    cmd = new MySqlCommand(mysql, con);
            //    da = new MySqlDataAdapter(cmd);
            //    ds = new DataSet();
            //    DataTable dt = new DataTable();
            //    da.Fill(ds, "registration");
            //    dt = ds.Tables["registration"];
            //    ((DataGridView)dgv).DataSource = dt;
            //}catch(InvalidOperationException){}
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

        private void toolStripButton3_Click_2(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                myaction.myupdate(searchpx.Text);
            }
            else
            {
                this.IsMdiContainer = true;
                myaction = new Body();
                myaction.MdiParent = this;
                myaction.myupdate(searchpx.Text);
                myaction.WindowState = FormWindowState.Maximized;
                myaction.Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                myaction.Update("Add Patient");
            }
            else
            {
                this.IsMdiContainer = true;
                myaction = new Body();
                myaction.MdiParent = this;
                myaction.Update("Add Patient");
                myaction.WindowState = FormWindowState.Maximized;
                myaction.Show();
            }
        }

        
  }
}
