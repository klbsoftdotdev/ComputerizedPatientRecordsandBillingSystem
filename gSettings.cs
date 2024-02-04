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
    public partial class gSettings : Form
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
        bi_Codes deactivate;
        bi_Codes activate;
        bi_Codes acc;
        bi_Codes save;
        public gSettings()
        {
            InitializeComponent();
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            cmd = con.CreateCommand();
            cmd.Connection = con;
            account = new bi_Codes();
            account2 = new bi_Codes();
            assign = new bi_Codes();
            account3 = new bi_Codes();
            deactivate = new bi_Codes();
            activate = new bi_Codes();
            acc = new bi_Codes();
            save = new bi_Codes();
        }

        private void gSettings_Load(object sender, EventArgs e)
        {
            

            saveToolStripMenuItem.Visible = false;
            cancelToolStripMenuItem.Visible = false;
            //---contextmenustrip---
            //newAccountToolStripMenuItem.Enabled = true;
            //assignToolStripMenuItem.Enabled = false;
            //activateToolStripMenuItem.Enabled = false; 
            
            //---datagridview image---
            DataGridViewImageColumn imgs = new DataGridViewImageColumn();
            imgs.HeaderText = "";
            imgs.Name = "icon";
            imgs.Image = new Bitmap(@"Resources\useraccount_img.jpg");
            dataGridView2.Columns.Add(imgs);

            dataGridView2.DataSource = account2.useraccount();
            dataGridView2.GridColor = Color.DeepSkyBlue;


            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].Width = 30;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Width = 100;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[3].Width = 150;
            //dataGridView2.Columns[4].Width = 80;
            //dataGridView2.Columns[5].Width = 80;
            dataGridView2.Columns[6].Width = 100;
            //dataGridView2.Columns[7].ReadOnly = true;
            dataGridView2.Columns[8].ReadOnly = true;
            dataGridView2.Columns[9].ReadOnly = false;
            //dataGridView2.Columns[10].Width = 80;
            //dataGridView2.Columns[11].Width = 80;
            //dataGridView2.Columns[10].ReadOnly = true;
            //dataGridView2.Columns[11].ReadOnly = true;
            //dataGridView2.Columns[1].Visible = false;
            //dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
           
            //dataGridView2.Columns[9].ReadOnly = true;
            //loghistory------
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "";
            img.Name = "icon";
            //img.Image = Properties.Resources.images_066;

            dataGridView1.Columns.Add(img);
            dataGridView1.GridColor = Color.DeepSkyBlue;
            dataGridView1.DataSource = account.loghistcode();
            dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {
                string d = dg.Cells[8].Value.ToString();
                if (d == "Activated")
                {
                    dg.DefaultCellStyle.BackColor = Color.LightBlue; ;
                }
                else
                    dg.DefaultCellStyle.BackColor = Color.IndianRed;

            }
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dg in dataGridView2.Rows)
            {
                string d = dg.Cells[9].Value.ToString();
                if (d == "Activated")
                {
                    dg.DefaultCellStyle.BackColor = Color.LightBlue; ;
                }
                else
                    dg.DefaultCellStyle.BackColor = Color.IndianRed;

            }

            try
            {
                if (e.ColumnIndex == 5 || e.ColumnIndex == 7 && e.Value != null)
                {
                    e.Value = new String('*', e.Value.ToString().Length);
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
          
        }

        private void dataGridView2_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (label1.Text == "0")
            {
                if (label8.Text == "0")
                {
                    if (e.KeyData == (Keys.Control | Keys.S))
                    {
                        MessageBox.Show("Save account?");
                        save.saveacc(dataGridView2[3, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[4, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[5, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[6, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[7, dataGridView2.CurrentCell.RowIndex].Value.ToString(),label10.Text);
                        dataGridView2.DataSource = account2.useraccount();
                        //string sql3 = "INSERT INTO useraccount(lastname, firstname,middlename,username,password,securityquestion,securityanswer,status) VALUES (@1, @2, @3,@4,@5,@6,@7,@8)";
                        //MySqlCommand dbcomm1 = new MySqlCommand(sql3, con);
                        //dbcomm1.Parameters.AddWithValue("@1", dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@2", dataGridView2[2, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@3", dataGridView2[3, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@4", dataGridView2[4, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@5", dataGridView2[5, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@6", dataGridView2[6, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@7", dataGridView2[7, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                        //dbcomm1.Parameters.AddWithValue("@8", "Activated");
                        //dbcomm1.ExecuteNonQuery();
                        MessageBox.Show("Saved!");
                        dataGridView2.ContextMenuStrip = contextMenuStrip1;
                        label1.Text = "";
                        label7.Text = "";
                        label8.Text = "";
                    }
                    else if (e.KeyData == (Keys.Control | Keys.X))
                    {
                        DialogResult dr = MessageBox.Show("Cancel " + label5.Text + " transaction?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            //string sql = "select userid from useraccount where accountID='"+label5.Text+"'";
                            //MySqlCommand dbcomm = new MySqlCommand(sql, con);
                            //dbcomm.ExecuteNonQuery();
                            //label2.Text = sql;

                            con.Open();
                            string sql4 = "DELETE FROM useraccount WHERE userid='" + label10.Text + "'";
                            MySqlCommand dbcomm4 = new MySqlCommand(sql4, con);
                            dbcomm4.ExecuteNonQuery();
                            con.Close();
                            dataGridView2.DataSource = account2.useraccount();
                            dataGridView2.Refresh();
                            label1.Text = "";
                            label7.Text = "";
                            label8.Text = "";
                            dataGridView2.ContextMenuStrip = contextMenuStrip1;
                            //newAccountToolStripMenuItem.Enabled = true;
                            //assignToolStripMenuItem.Enabled = false;
                            //activateToolStripMenuItem.Enabled = false; 

                        }

                    }
                }
            }
            
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a;
            a = dataGridView2.SelectedCells[0].RowIndex;
            //label6.Text = dataGridView2["userid", a].Value.ToString();
            label5.Text = dataGridView2["STATUS", a].Value.ToString();
            label10.Text = dataGridView2["userid", a].Value.ToString();
            label9.Text = dataGridView2["USER FULLNAME", a].Value.ToString();

            //newAccountToolStripMenuItem.Enabled = false;
            //assignToolStripMenuItem.Enabled = true;
            //activateToolStripMenuItem.Enabled = true;
            //int a;
            //a = dataGridView2.SelectedCells[0].RowIndex;
            //label5.Text = dataGridView2["STATUS", a].Value.ToString();

           
                //var hti = dataGridView2.HitTest(e.X, e.Y);
                //dataGridView2.ClearSelection();
                //dataGridView2.Rows[hti.RowIndex].Selected = true;
            

                if (label5.Text == "Activated")
                {
                    activateToolStripMenuItem.Text = "Deactivate";
                }
                else if (label5.Text == "Deactivated")
                {
                    activateToolStripMenuItem.Text = "Activate";
                }

            
            
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            a = dataGridView2.SelectedCells[0].RowIndex;
            label6.Text = dataGridView2["userid", a].Value.ToString();
            label5.Text = dataGridView2["STATUS", a].Value.ToString();
            label3.Text = dataGridView2["ACCOUNT_ID", a].Value.ToString();

            if (label5.Text == "Activated")
            {
                DialogResult dr = MessageBox.Show("Deactivate " + label9.Text + "?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    deactivate.Deactivate(label6.Text);
                    MessageBox.Show("Deactivated!", "Success!");
                    dataGridView2.DataSource = account2.useraccount();
                    //newAccountToolStripMenuItem.Enabled = true;
                    //assignToolStripMenuItem.Enabled = false;
                    //activateToolStripMenuItem.Enabled = false;
                }
                else
                {
                    //newAccountToolStripMenuItem.Enabled = true;
                    //assignToolStripMenuItem.Enabled = false;
                    //activateToolStripMenuItem.Enabled = false;
                }
            }
            else if (label5.Text == "Deactivated")
            {
                DialogResult dr = MessageBox.Show("Activate " + label9.Text + "?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    activate.Activate(label6.Text);
                    MessageBox.Show("Activated!", "Success!");
                    dataGridView2.DataSource = account2.useraccount();
                    //newAccountToolStripMenuItem.Enabled = true;
                    //assignToolStripMenuItem.Enabled = false;
                    //activateToolStripMenuItem.Enabled = false;
                }
                else
                {
                    //newAccountToolStripMenuItem.Enabled = true;
                    //assignToolStripMenuItem.Enabled = false;
                    //activateToolStripMenuItem.Enabled = false;
                }
            }

        }

        private void assignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            a = dataGridView2.SelectedCells[0].RowIndex;
            label3.Text = dataGridView2["ACCOUNT_ID", a].Value.ToString();
            label4.Text = dataGridView2["ACCESS", a].Value.ToString();
            label5.Text = dataGridView2["STATUS", a].Value.ToString();
            label6.Text = dataGridView2["userid", a].Value.ToString();

            DialogResult dr = MessageBox.Show("Assign " + label9.Text + "?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (label5.Text == "Deactivated")
                {
                    //MessageBox.Show("You can't assign " + label3.Text + ", Account is " + label5.Text," ",MessageBoxIcon.Warning);
                    MessageBox.Show("You can't assign " + label9.Text + ", activate account first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Prompt bip = new Prompt();
                    bip.label1.Text = label3.Text;
                    bip.label2.Text = label4.Text;
                    bip.label3.Text = label6.Text;
                    bip.ShowDialog();
                    dataGridView2.DataSource = account2.useraccount();
                }
            }
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label12.Text = "exit";
            //dataGridView2.ReadOnly=true;
            //this.dataGridView2.Rows[dataGridView2.Rows.Count - 1].ReadOnly = false;
            //dataGridView2.Refresh();
            
            //if (dataGridView2.RowCount > 0)
            //{
            //dataGridView2.Rows[dataGridView2.RowCount].ReadOnly = false;
            //}
           
            //int i = dataGridView2.Rows.Count;
            //dataGridView2.Rows[3].ReadOnly = false;


            label11.Text = "Save";
            saveToolStripMenuItem.Visible = true;
            cancelToolStripMenuItem.Visible = true;
            newAccountToolStripMenuItem.Visible=false;
            toolStripSeparator1.Visible=false;
            assignToolStripMenuItem.Visible=false;
            activateToolStripMenuItem.Visible=false;
            toolStripMenuItem1.Visible=false;
            label1.Text = "0";
            DialogResult dr = MessageBox.Show("Add new Account?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                int s = dataGridView2.Rows.Count;
                string cnt = Convert.ToString(s + 1);
                string b = "ACCID" + DateTime.Now.ToString("MMddyyyy0") + cnt;
                label5.Text = b;

                string sql3 = "INSERT INTO useraccount(username,password,securityquestion,securityanswer,status,access,accountID,name) VALUES (@1,@2,@3,@4,@5,@6,@7,@8)";
                con.Open();
                MySqlCommand dbcomm1 = new MySqlCommand(sql3, con);
                dbcomm1.Parameters.AddWithValue("@1", " ");
                dbcomm1.Parameters.AddWithValue("@2", " ");
                dbcomm1.Parameters.AddWithValue("@3", " ");
                dbcomm1.Parameters.AddWithValue("@4", " ");
                dbcomm1.Parameters.AddWithValue("@5", " ");
                dbcomm1.Parameters.AddWithValue("@6", " ");
                dbcomm1.Parameters.AddWithValue("@7", " " + b);
                dbcomm1.Parameters.AddWithValue("@8", " ");
                dbcomm1.ExecuteNonQuery();
                con.Close();
                dataGridView2.DataSource = account2.useraccount();
               

                
            }
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                int a;
                a = dataGridView2.SelectedCells[0].RowIndex;
                label2.Text = dataGridView2["userid", a].Value.ToString(); 
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (label1.Text == "0")
            {
                label8.Text = "0";
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label12.Text = "exit";
            MessageBox.Show("Update "+label9.Text+"?");
            dataGridView2.BeginEdit(true);
            saveToolStripMenuItem.Visible = true;
            cancelToolStripMenuItem.Visible = true;
            newAccountToolStripMenuItem.Visible = false;
            toolStripSeparator1.Visible = false;
            assignToolStripMenuItem.Visible = false;
            activateToolStripMenuItem.Visible = false;
            toolStripMenuItem1.Visible = false;
            label1.Text = "0";
            label8.Text = "0";
            label11.Text = "Update";
            

            //int i = dataGridView2.Rows.Count;
            //string cnt = Convert.ToString(i - 1);
            //int ii = Convert.ToInt32(cnt);
            //dataGridView2.Rows[ii].Cells[3].Value = "";
            //dataGridView2.Rows[ii].Cells[4].Value = "";
            //dataGridView2.Rows[ii].Cells[5].Value = "";
            //dataGridView2.Rows[ii].Cells[6].Value = "";
            //dataGridView2.Rows[ii].Cells[7].Value = "";
            //dataGridView2.Rows[ii].Cells[7].De

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label11.Text == "Save")
            {
                MessageBox.Show("Save account?");
                save.saveacc(dataGridView2[3, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[4, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[5, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[6, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[7, dataGridView2.CurrentCell.RowIndex].Value.ToString(), label10.Text);
                dataGridView2.DataSource = account2.useraccount();
                MessageBox.Show("Saved!");
                dataGridView2.ContextMenuStrip = contextMenuStrip1;
                saveToolStripMenuItem.Visible = false;
                cancelToolStripMenuItem.Visible = false;
                newAccountToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = true;
                assignToolStripMenuItem.Visible = true;
                activateToolStripMenuItem.Visible = true;
                toolStripMenuItem1.Visible = true;
                label1.Text = "";
                label7.Text = "";
                label8.Text = "";
                label11.Text = "";
                label12.Text = "";
            }
            else if (label11.Text == "Update")
            {
                save.saveacc(dataGridView2[3, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[4, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[5, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[6, dataGridView2.CurrentCell.RowIndex].Value.ToString(), dataGridView2[7, dataGridView2.CurrentCell.RowIndex].Value.ToString(), label10.Text);
                dataGridView2.DataSource = account2.useraccount();
                MessageBox.Show("Updated!");
                dataGridView2.ContextMenuStrip = contextMenuStrip1;
                saveToolStripMenuItem.Visible = false;
                cancelToolStripMenuItem.Visible = false;
                newAccountToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = true;
                assignToolStripMenuItem.Visible = true;
                activateToolStripMenuItem.Visible = true;
                toolStripMenuItem1.Visible = true;
                label1.Text = "";
                label7.Text = "";
                label8.Text = "";
                label11.Text = "";
                label12.Text = "";
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label11.Text == "Update")
            {
                DialogResult dr = MessageBox.Show("Cancel " + label5.Text + " transaction?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    dataGridView2.DataSource = account2.useraccount();
                    dataGridView2.ContextMenuStrip = contextMenuStrip1;
                    saveToolStripMenuItem.Visible = false;
                    cancelToolStripMenuItem.Visible = false;
                    newAccountToolStripMenuItem.Visible = true;
                    toolStripSeparator1.Visible = true;
                    assignToolStripMenuItem.Visible = true;
                    activateToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    MessageBox.Show("Canceled!");
                    label12.Text = "";
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Cancel " + label5.Text + " transaction?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //string sql = "select userid from useraccount where accountID='"+label5.Text+"'";
                    //MySqlCommand dbcomm = new MySqlCommand(sql, con);
                    //dbcomm.ExecuteNonQuery();
                    //label2.Text = sql;

                    con.Open();
                    string sql4 = "DELETE FROM useraccount WHERE userid='" + label10.Text + "'";
                    MySqlCommand dbcomm4 = new MySqlCommand(sql4, con);
                    dbcomm4.ExecuteNonQuery();
                    con.Close();
                    dataGridView2.DataSource = account2.useraccount();
                    dataGridView2.Refresh();
                    label1.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    dataGridView2.ContextMenuStrip = contextMenuStrip1;
                    saveToolStripMenuItem.Visible = false;
                    cancelToolStripMenuItem.Visible = false;
                    newAccountToolStripMenuItem.Visible = true;
                    toolStripSeparator1.Visible = true;
                    assignToolStripMenuItem.Visible = true;
                    activateToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    label12.Text = "";
                    MessageBox.Show("Canceled!");
                }
            }
        }

        private void gSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (label12.Text == "exit")
            {
                DialogResult dr = MessageBox.Show("Close withou saving?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    con.Open();
                    string sql4 = "DELETE FROM useraccount WHERE userid='" + label10.Text + "'";
                    MySqlCommand dbcomm4 = new MySqlCommand(sql4, con);
                    dbcomm4.ExecuteNonQuery();
                    con.Close();
                    dataGridView2.DataSource = account2.useraccount();
                    dataGridView2.Refresh();
                    label1.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    dataGridView2.ContextMenuStrip = contextMenuStrip1;
                    saveToolStripMenuItem.Visible = false;
                    cancelToolStripMenuItem.Visible = false;
                    newAccountToolStripMenuItem.Visible = true;
                    toolStripSeparator1.Visible = true;
                    assignToolStripMenuItem.Visible = true;
                    activateToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = true;

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
