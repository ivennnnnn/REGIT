using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BARANGAY_INFORMATION_SYSTEM_final_
{
    public partial class review : Form
    {
        string mycon = "datasource=localhost;username=root;password=;database=regit_db";

        public review()
        {
            InitializeComponent();
            Load += new EventHandler(review_Load);
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            home home = new home();
            home.TopLevel = false;
            container.Controls.Add(home);
            home.Show();
            bunifuFlatButton1.Enabled = false;


            try
            {
                string query = "insert into regit_tbl(FirstName,MiddleName,LastName,Suffix,DateofBirth,PlaceofBirth,Sex,CivilStatus,Telephone,MobileNo,EmailAddress,SupplementaryData,Province,City,Barangay,AreaSubdivision,HouseNo,ComelecStatus,Age) values('" + this.label7.Text + "','" + this.label8.Text + "','" + this.label9.Text + "','" + this.label10.Text + "','" + this.label42.Text + "','" + this.label44.Text + "','" + this.label14.Text + "','" + this.label13.Text + "','" + this.label19.Text + "','" + this.label20.Text + "','" + this.label21.Text + "','" + this.label23.Text + "','" + this.label26.Text + "','" + this.label28.Text + "','" + this.label29.Text + "','" + this.label33.Text + "','" + this.label32.Text + "','" + this.label46.Text + "','" + this.label35.Text + "'); ";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, mycon2);
                MySqlDataReader MyReader1;
                mycon2.Open();
                MyReader1 = mycommand.ExecuteReader();
                MessageBox.Show("Registration Success", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            supplementary.PWD = "";
            supplementary.seniorcitizen = "";
            supplementary.minor = "";
            supplementary.soloparent = "";
            supplementary.adult = "";
            supplementary.suppldata = "";

        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }
        private void review_Load(object sender, EventArgs e)
        {
            label7.Text = personalinfo.firstname;
            label8.Text = personalinfo.middlename;
            label9.Text = personalinfo.lastname;
            label10.Text = personalinfo.suffix;
            label42.Text = personalinfo.dateofbirth;
            label14.Text = personalinfo.sex;
            label13.Text = personalinfo.civilstatus;
            label44.Text = personalinfo.placeofbirth;
            label46.Text = personalinfo.vote;
            label21.Text = personalinfo.email;
            label19.Text = personalinfo.telephone;
            label20.Text = personalinfo.mobilenumber;
            label35.Text = personalinfo.age;

            label23.Text = supplementary.suppldata;

            label26.Text = RESIDENCE.addrProvinceRegion;
            label28.Text = RESIDENCE.addrCityMunicipality;
            label29.Text = RESIDENCE.addrBarangay;
            label32.Text = RESIDENCE.addrHouseNo;
            label33.Text = RESIDENCE.addrAreaSubdivision;

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }
    }
}
