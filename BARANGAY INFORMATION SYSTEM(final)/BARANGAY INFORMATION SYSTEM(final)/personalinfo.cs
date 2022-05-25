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
    public partial class personalinfo : Form
    {

        public static string firstname;
        public static string middlename;
        public static string lastname;
        public static string suffix;
        public static string dateofbirth;
        public static string sex;
        public static string civilstatus;
        public static string placeofbirth;
        public static string vote;
        public static string sex1;
        public static string email;
        public static string mobilenumber;
        public static string telephone;
        public static string age;


        public personalinfo()
        {
            InitializeComponent();
        }

        private void personalinfo_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void personalinfobtn_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            firstname = bunifuMetroTextbox1.Text;
            middlename = bunifuMetroTextbox2.Text;
            lastname = bunifuMetroTextbox3.Text;
            suffix = bunifuMetroTextbox4.Text;
            dateofbirth = bunifuDatepicker1.Value.ToString("dd-MM-yyyy");
            sex = sex1;
            civilstatus = bunifuDropdown1.selectedValue;
            email = bunifuMetroTextbox9.Text;
            mobilenumber = bunifuMetroTextbox8.Text;
            telephone = bunifuMetroTextbox7.Text;
            placeofbirth = bunifuMetroTextbox5.Text;
            age = bunifuMetroTextbox6.Text;

            
            container.Controls.Clear();
            supplementary suppdata = new supplementary();
            suppdata.TopLevel = false;
            container.Controls.Add(suppdata);
            suppdata.Show();
            bunifuFlatButton1.Enabled = false;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sex1 = "Male";
            sex = sex1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sex1 = "Female";
            sex = sex1;
        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            vote = "Registered";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            vote = "Not Registered";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            DateTime from = bunifuDatepicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan tSpan = to - from;
            double days = tSpan.TotalDays;

            int age = to.Year - from.Year;
            if (to.Month > from.Month || (to.Month == to.Month || to.Day > from.Day))
            {
                bunifuMetroTextbox6.Text = age.ToString();
            }
            else
            {
                age--;
                bunifuMetroTextbox6.Text = age.ToString();
            }
        }

        private void bunifuMetroTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
