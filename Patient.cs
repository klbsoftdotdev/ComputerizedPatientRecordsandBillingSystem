using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace bi_CPRBS
{

    public partial class Patient : Form

    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        public Patient()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            //pictureBox2.Image = Image.FromFile(@"Resources\PatientImage\patienticon_default.png");
            panel1.Dock = DockStyle.Fill;
            splitContainer1.Dock = DockStyle.Fill;
            string trysql9 = "SELECT * from registration where Medrecordno='" + label2.Text + "'";
            con.Open();
            cmd = new MySqlCommand(trysql9, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dt9 = new DataTable();
            da.Fill(ds, "registration");
            dt9 = ds.Tables["registration"];
            dataGridView1.DataSource = dt9;
            
            //con.Close();
            //string trysql9 = "SELECT * from patienthistory where pxname='" + lblpxname.Text + "'";
            //con.Open();
            //cmd = new MySqlCommand(trysql9, con);
            //da = new MySqlDataAdapter(cmd);
            //ds = new DataSet();
            //DataTable dt9 = new DataTable();
            //da.Fill(ds, "patienthistory");
            //dt9 = ds.Tables["patienthistory"];
            //dataGridView1.DataSource = dt9;

            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void lblpxname_TextChanged(object sender, EventArgs e)
        {
            //con.Close();
            //string trysql9 = "SELECT * from patienthistory where pxname='" + lblpxname.Text + "'";
            //con.Open();
            //cmd = new MySqlCommand(trysql9, con);
            //da = new MySqlDataAdapter(cmd);
            //ds = new DataSet();
            //DataTable dt9 = new DataTable();
            //da.Fill(ds, "patienthistory");
            //dt9 = ds.Tables["patienthistory"];
            //dataGridView1.DataSource = dt9;
            //int a = dataGridView1.SelectedCells[0].RowIndex;
            //label2.Text = "No. "+dataGridView1["pxno", a].Value.ToString();
            
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            TreeNode phy = new TreeNode("Medical History");
            phy.Name = "phy";
            foreach (DataGridViewRow dr5 in dataGridView1.Rows)
            {
                phy.Nodes.Add(dr5.Cells[2].Value.ToString());
                lblpxname.Text = dr5.Cells[0].Value.ToString();
            }
            treeView2.Nodes.Add(phy);
            treeView2.HotTracking = true;
            phy.Expand();
            con.Close();
            string trysql9 = "SELECT * from registration where Medrecordno='" + label2.Text + "'";
            con.Open();
            cmd = new MySqlCommand(trysql9, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dt9 = new DataTable();
            da.Fill(ds, "registration");
            dt9 = ds.Tables["registration"];
            dataGridView1.DataSource = dt9;
            int a = dataGridView1.SelectedCells[0].RowIndex;
            label3.Text = "Gender: " + dataGridView1["Sex", a].Value.ToString();
            label4.Text = "Birthday: " + dataGridView1["Birthdate", a].Value.ToString();
            label6.Text = "Status: " + dataGridView1["CivilStatus", a].Value.ToString();
            label5.Text = "Address: " + dataGridView1["PatientAddress", a].Value.ToString();


            string path = @"Resources\PatientImage\"+textBox2.Text+".jpg";
            if (File.Exists(path))
            {
            pictureBox1.Image = Image.FromFile(@"Resources\PatientImage\"+label2.Text+".jpg");
            }
            else
                pictureBox1.Image = Image.FromFile(@"Resources\PatientImage\patienticon_default.png");



        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void dataGridView2_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form myfrm = System.Windows.Forms.Application.OpenForms.OfType<Body>().First();
            int a = dataGridView2.SelectedCells[0].RowIndex;

            Control lbl4 = myfrm.Controls.Find("label4", true).First();
            ((Label)lbl4).Text = dataGridView2["RECORD NUMBER", a].Value.ToString();
        }
        private void saveImage()
        {
            string path = @"Resources\PatientImage\"+textBox2.Text+".jpg";
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);

            if (System.IO.File.Exists(path))
            {
                string Fromfile = @"Resources\PatientImage\"+textBox2.Text+".jpg";
                string Tofile = @"Resources\PatientImage\"+textBox2.Text +"_old.jpg";
                File.Move(Fromfile, Tofile);
                System.IO.File.Delete(Tofile);
                bmp1.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp1.Dispose();
            }
            else
            {
                bmp1.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp1.Dispose();
                MessageBox.Show("Saved!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select Image";
                openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

                string path = Path.GetDirectoryName(Application.ExecutablePath) + @"Resources\PatientImage\";
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        label9.Text = openFileDialog1.FileName;
                        //string name = openFileDialog1.SafeFileName;
                        File.Copy(label9.Text, Path.Combine(@"Resources\PatientImage\", Path.GetFileName(label9.Text)));
                        pictureBox2.Image = new Bitmap(openFileDialog1.OpenFile());
                        pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Unable to open file" + exp.Message);
                    }
                }
                else
                {
                    openFileDialog1.Dispose();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Close();
            string trysql9 = "SELECT * from registration where Medrecordno='" + textBox1.Text + "'";
            con.Open();
            cmd = new MySqlCommand(trysql9, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dt9 = new DataTable();
            da.Fill(ds, "registration");
            dt9 = ds.Tables["registration"];
            dataGridView1.DataSource = dt9;
            pictureBox3.Image = Image.FromFile((@"Resources\PatientImage\"+textBox2.Text+".jpg"));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
