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
    public partial class RESIDENCE : Form
    {
        public static string addrProvinceRegion;
        public static string addrCityMunicipality;
        public static string addrBarangay;
        public static string addrHouseNo;
        public static string addrAreaSubdivision;
        

        public RESIDENCE()
        {
            InitializeComponent();
        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            addrProvinceRegion = bunifuMetroTextbox1.Text;
            addrCityMunicipality = bunifuMetroTextbox2.Text;
            addrBarangay = bunifuMetroTextbox3.Text;
            addrHouseNo = bunifuMetroTextbox4.Text;
            addrAreaSubdivision = bunifuDropdown1.selectedValue;



            container.Controls.Clear();
            review review = new review();
            review.TopLevel = false;
            container.Controls.Add(review);
            review.Show();
            bunifuFlatButton1.Enabled = false;
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
