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
    
    public partial class SystemGeneralRecords : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        public SystemGeneralRecords()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
        }
        //pxcount
        public void pxcount()
        {
            con.Close();
            string trysqls = "SELECT * FROM registration";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "registration");
            dts = ds.Tables["registration"];
            dataGridView1.DataSource = dts;

            label5.Text = dataGridView1.Rows.Count.ToString();
        }
        //hospital count
        public void hpcount()
        {
            con.Close();
            string trysqls = "SELECT * FROM hospital";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "hospital");
            dts = ds.Tables["hospital"];
            dataGridView2.DataSource = dts;

            label6.Text = dataGridView2.Rows.Count.ToString();
        }
        //room count
        public void roomcount()
        {
            con.Close();
            string trysqls = "SELECT * FROM room";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "room");
            dts = ds.Tables["room"];
            dataGridView3.DataSource = dts;

            label7.Text = dataGridView3.Rows.Count.ToString();
        }
        //physician count
        public void phycount()
        {
            con.Close();
            string trysqls = "SELECT * FROM physician";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "physician");
            dts = ds.Tables["physician"];
            dataGridView4.DataSource = dts;

            label8.Text = dataGridView4.Rows.Count.ToString();
        }
        //laboratory count
        public void labcount()
        {
            con.Close();
            string trysqls = "SELECT * FROM laboratory";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "laboratory");
            dts = ds.Tables["laboratory"];
            dataGridView5.DataSource = dts;

            label9.Text = dataGridView5.Rows.Count.ToString();
        }
        //medicine count
        public void medcount()
        {
            con.Close();
            string trysqls = "SELECT * FROM medicine";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "medicine");
            dts = ds.Tables["medicine"];
            dataGridView6.DataSource = dts;

            label10.Text = dataGridView6.Rows.Count.ToString();
        }
        //insurance
        public void inscount()
        {
            con.Close();
            string trysqls = "SELECT * FROM insurance";
            con.Open();
            cmd = new MySqlCommand(trysqls, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dts = new DataTable();
            da.Fill(ds, "insurance");
            dts = ds.Tables["insurance"];
            dataGridView7.DataSource = dts;

            label11.Text = dataGridView7.Rows.Count.ToString();
        }
        private void SystemGeneralRecords_Load(object sender, EventArgs e)
        {
            timer1.Start();
            string trysql = "SELECT concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as 'patientname',Medrecordno,status FROM registration order by Medrecordno asc";
            con.Open();
            cmd = new MySqlCommand(trysql, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            dt = new DataTable();
            da.Fill(ds, "registration");
            dt = ds.Tables["registration"];

            //hospitalname
            con.Close();
            string trysql9 = "SELECT hname from hospital where status ='current'";
            con.Open();
            cmd = new MySqlCommand(trysql9, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dt9 = new DataTable();
            da.Fill(ds, "hospital");
            dt9 = ds.Tables["hospital"];

               foreach (DataRow dr9 in dt9.Rows)
                {
                  
                    label4.Text = dr9["hname"].ToString();
                }
           



                //treeview1
                TreeNode sysroot = new TreeNode(label4.Text);
                sysroot.Name = "root";
                sysroot.ImageIndex = 2;
                sysroot.SelectedImageIndex = 2;
                treeView1.Nodes.Add(sysroot);

                //patient records node
                pxcount();
                TreeNode trn = new TreeNode();
                trn.Name = "pr";
                trn.Text = "Patient Records (" + this.label5.Text+ ")";
                trn.ImageIndex = 0;
                trn.SelectedImageIndex = 0;
            
               
                

                //----end

                //==billing nodes
                TreeNode bs = new TreeNode("Billing System");
                bs.Name = "bs";
                bs.ImageIndex = 0;
                bs.SelectedImageIndex = 0;
                //----end

                //==hospital management nodes
                //hospital
                con.Close();
                string trysql3 = "SELECT * FROM hospital";
                con.Open();
                cmd = new MySqlCommand(trysql3, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt2 = new DataTable();
                da.Fill(ds, "hospital");
                dt2 = ds.Tables["hospital"];

                //laboratory
                con.Close();
                string trysql4 = "SELECT * FROM laboratory";
                con.Open();
                cmd = new MySqlCommand(trysql4, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt3 = new DataTable();
                da.Fill(ds, "laboratory");
                dt3 = ds.Tables["laboratory"];

                //room
                con.Close();
                string trysql5 = "SELECT * FROM room";
                con.Open();
                cmd = new MySqlCommand(trysql5, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt4 = new DataTable();
                da.Fill(ds, "room");
                dt4 = ds.Tables["room"];

                //physician
                con.Close();
                string trysql6 = "SELECT concat(lastname,', ',firstname,' ',lastname) as phyname from physician";
                con.Open();
                cmd = new MySqlCommand(trysql6, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt5 = new DataTable();
                da.Fill(ds, "physician");
                dt5 = ds.Tables["physician"];

                //medicine
                con.Close();
                string trysql7 = "SELECT * from medicine";
                con.Open();
                cmd = new MySqlCommand(trysql7, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt6 = new DataTable();
                da.Fill(ds, "medicine");
                dt6 = ds.Tables["medicine"];

                //insurance
                con.Close();
                string trysql8 = "SELECT * from insurance";
                con.Open();
                cmd = new MySqlCommand(trysql8, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable dt7 = new DataTable();
                da.Fill(ds, "insurance");
                dt7 = ds.Tables["insurance"];

                TreeNode hm = new TreeNode();
                hm.Text = "Hospital Management";
                hm.Name = "hm";
                hpcount();
                TreeNode hp = new TreeNode("Hospital (" +label6.Text+")");
                hp.Name = "rm";
                foreach (DataRow dr2 in dt2.Rows)
                {

                    hp.Nodes.Add(dr2["hname"].ToString());
                }
                hp.ImageIndex = 0;
                hp.SelectedImageIndex = 0;
                roomcount();
                TreeNode rm = new TreeNode("Room ("+label7.Text+")");
                rm.Name = "rm";
                foreach (DataRow dr4 in dt4.Rows)
                {
                    rm.Nodes.Add(dr4["roomname"].ToString());
                }
                rm.ImageIndex = 0;
                rm.SelectedImageIndex = 0;
                phycount();
                TreeNode phy = new TreeNode("Physician("+label8.Text+")");
                phy.Name = "phy";
                foreach (DataRow dr5 in dt5.Rows)
                {

                    phy.Nodes.Add(dr5["phyname"].ToString());
                }
                phy.ImageIndex = 0;
                phy.SelectedImageIndex = 0;
                labcount();
                TreeNode lab = new TreeNode("Laboratory ("+label9.Text+")");
                lab.Name = "lab";
                foreach (DataRow dr3 in dt3.Rows)
                {

                    lab.Nodes.Add(dr3["labdescription"].ToString());
                }
                lab.ImageIndex = 0;
                lab.SelectedImageIndex = 0;
                medcount();
                TreeNode med = new TreeNode("Medicine ("+label10.Text+")");
                med.Name = "med";
                foreach (DataRow dr6 in dt6.Rows)
                {
                    med.Nodes.Add(dr6["medname"].ToString());
                }
                med.ImageIndex = 0;
                med.SelectedImageIndex = 0;
                inscount();
                TreeNode ins = new TreeNode("Health Insurance ("+label11.Text+")");
                ins.Name = "ins";
                foreach (DataRow dr7 in dt7.Rows)
                {
                    ins.Nodes.Add(dr7["insurancename"].ToString());
                }
                ins.ImageIndex = 0;
                ins.SelectedImageIndex = 0;
                hm.Nodes.Add(hp);
                hm.Nodes.Add(rm);
                hm.Nodes.Add(phy);
                hm.Nodes.Add(lab);
                hm.Nodes.Add(med);
                hm.Nodes.Add(ins);
                hm.ImageIndex = 0;
                hm.SelectedImageIndex = 0;
                hm.Expand();
                //----end

                treeView1.Indent = 25;
                treeView1.ItemHeight = 30;


                foreach (DataRow dr in dt.Rows)
                {

                    trn.Nodes.Add(dr["patientname"].ToString());
                }


                foreach (TreeNode tn in trn.Nodes)
                {
                    con.Close();
                    string trysql2 = "SELECT Medrecordno, concat(PtLastName,', ',PtGivenName,' ',PtMiddleName)as 'patientname' from registration where status = 'Admitted'";
                    con.Open();
                    cmd = new MySqlCommand(trysql2, con);
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    dt = new DataTable();
                    da.Fill(ds, "registration");
                    dt = ds.Tables["registration"];

                    foreach (DataRow dr in dt.Rows)
                    {
                        string fn = dr["patientname"].ToString();

                        if (tn.Text == fn)
                        {
                            tn.ForeColor = Color.Red;

                        }

                    }


                }

                sysroot.Nodes.Add(hm);
                sysroot.Nodes.Add(trn);
                sysroot.Nodes.Add(bs);

                sysroot.Expand();
               
            //treeview1 -- end
          
            
            //treeView1.HotTracking = true;
            //TreeNode pr = new TreeNode("System General Records");
            //pr.Name = "bs";
            //treeView1.Nodes.Add(pr);
            //pr.Expand();
            //TreeNode info = new TreeNode("Patient Registration");
            //info.Name = "info";
            //pr.Nodes.Add(info);
            //TreeNode ro = new TreeNode("Admission");
            //ro.Name = "admission";
            //pr.Nodes.Add(ro);
            //TreeNode room = new TreeNode("Consultation");
            //room.Name = "consultation";
            //pr.Nodes.Add(room);
            //treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            con.Close();
            treeView1.HasChildren.GetHashCode();
            label1.Text = treeView1.SelectedNode.Name;
           
            if (label1.Text == "pr" || label1.Text =="root")
            {
            }
            else
            {
               
                treeView1.SelectedImageIndex = 3;
                label1.Text = treeView1.SelectedNode.Text;
                //con.Close();
                //string trysql = "SELECT concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as 'patientname' FROM registration where Medrecordno='" + label1.Text + "'";
                //con.Open();
                //cmd = new MySqlCommand(trysql, con);
                //da = new MySqlDataAdapter(cmd);
                //ds = new DataSet();
                //dt = new DataTable();
                //da.Fill(ds, "registration");
                //dt = ds.Tables["registration"];

                //foreach (DataRow dr in dt.Rows)
                //{
                //    label2.Text = label1.Text + " - " + dr["patientname"].ToString();
                //}

                //bi_PatientInformation bip = new bi_PatientInformation();
                //bip.MdiParent = this.MdiParent;
                //bip.Dock = DockStyle.Fill;
                //bip.label1.Text = label1.Text;
                //bip.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

            foreach (TreeNode tn in treeView1.Nodes)
            {
                 if (textBox1.Text == "")
            {
                tn.BackColor = Color.MistyRose;
            }
                con.Close();
                string trysql = "SELECT Medrecordno, concat(PtLastName,', ',PtGivenName,' ',PtMiddleName) as patientname FROM registration where PtLastName='"+textBox1.Text+"' or PtGivenName='"+textBox1.Text+"'";
                con.Open();
                cmd = new MySqlCommand(trysql, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(ds, "registration");
                dt = ds.Tables["registration"];

                foreach (DataRow dr in dt.Rows)
                {
                string fn = dr["Medrecordno"].ToString();
                if (tn.Text == fn)
                {
                    tn.BackColor = Color.LightSkyBlue;
                    label2.Text = label1.Text + " - " + dr["patientname"].ToString();
                }

                }
               
               
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //registration
          
        }

       

        

       
    }
}
