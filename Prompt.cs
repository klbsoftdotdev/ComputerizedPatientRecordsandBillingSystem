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
    public partial class Prompt : Form
    {
        bi_Codes prompt1;
        public Prompt()
        {
            InitializeComponent();
            prompt1 = new bi_Codes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Patient Records [CPRBS-PR]")
            {
                prompt1.prprecords(label3.Text);
                MessageBox.Show(label1.Text+" has been assigned in Patient Records");
                this.Close();
            }
            else if (comboBox1.Text == "Billing System [CPRBS-BS]")
            {
                prompt1.prpbilling(label3.Text);
                MessageBox.Show(label1.Text + " has been assigned in Billing System");
                this.Close();
            }
        }

        private void Prompt_Load(object sender, EventArgs e)
        {

        }
    }
}
