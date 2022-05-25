using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BARANGAY_INFORMATION_SYSTEM_final_
{
    public partial class supplementary : Form
    {

        public static string PWD;
        public static string seniorcitizen;
        public static string minor;
        public static string soloparent;
        public static string adult;
        public static string suppldata;

        public supplementary()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            

            suppldata = PWD + seniorcitizen + soloparent + adult + minor;

            container.Controls.Clear();
            RESIDENCE residence = new RESIDENCE();
            residence.TopLevel = false;
            container.Controls.Add(residence);
            residence.Show();
            bunifuFlatButton1.Enabled = false;

            

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            
                if (bunifuCheckbox1.Checked)
            {
                minor = "Minor ";
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
            }
            else
            {
                minor = "";
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked)
            {
                adult = "Adult ";
                bunifuCheckbox1.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;


            }
            else
            {
                adult = "";
            }
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked)
            {
                seniorcitizen = "Senior Citizen ";
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox1.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
            }
            else
            {
                seniorcitizen = "";
            }
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox4.Checked)
            {
                PWD = "Person with disability ";
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox1.Checked = false;
                bunifuCheckbox5.Checked = false;
            }
            else
            {
                PWD = "";
            }
        }

        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox5.Checked)
            {
                soloparent = "Solo Parent ";
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox1.Checked = false;
            }
            else
            {
                soloparent = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
