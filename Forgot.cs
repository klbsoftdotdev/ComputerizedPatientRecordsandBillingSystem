using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bi_CPRBS
{
    public partial class Forgot : Form
    {
        public Forgot()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bi_Codes forgots = new bi_Codes();
            dataGridView1.DataSource = forgots.forgotpass(textBox1.Text);
            try
            {
                int a = dataGridView1.SelectedCells[0].RowIndex;
                comboBox1.Text = dataGridView1["securityquestion", a].Value.ToString();
                label4.Text = dataGridView1["securityanswer", a].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "View")
            {
                if (label4.Text == textBox3.Text)
                {
                    this.Height = 382;
                    button1.Text = "Save";
                    textBox3.Enabled = false;
                    textBox1.Enabled = false;
                    comboBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Wrong Security answer!");
                }
            }
            else
            {
                if (textBox4.Text != textBox2.Text)
                {
                    MessageBox.Show("Password Did not Match!");
                }
                else if (textBox2.TextLength < 8)
                {
                    MessageBox.Show("Password is weak! try entering 8 to 12 digit password");
                    textBox2.Clear();
                    textBox4.Clear();
                }
                else
                {
                    bi_Codes forg = new bi_Codes();
                    forg.addpass(textBox2.Text, textBox1.Text);
                    MessageBox.Show("Password has been successfully updated!");
                    Login bi = new Login();
                    bi.Show();
                    this.Hide();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login bi = new Login();
            bi.Show();
            this.Hide();
        }

        private void bi_Forgot_Load(object sender, EventArgs e)
        {

        }
    }
}
