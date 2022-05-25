using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BARANGAY_INFORMATION_SYSTEM_final_
{
    public partial class registration : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );
        public registration()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            home home = new home();
            home.TopLevel = false;
            container.Controls.Add(home);
            home.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to logout?", "Exit Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                login loginform = new login();
                loginform.Show();
                this.Hide();

            }
        }

        private void personalinfobtn_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            personalinfo personal = new personalinfo();
            personal.TopLevel = false;
            container.Controls.Add(personal);
            personal.Show();
        }

        private void supplementarybtn_Click(object sender, EventArgs e)
        {
            supplementary.PWD = "";
            supplementary.seniorcitizen = "";
            supplementary.minor = "";
            supplementary.soloparent = "";
            supplementary.adult = "";
            supplementary.suppldata = "";

            container.Controls.Clear();
            supplementary suppdata = new supplementary();
            suppdata.TopLevel = false;
            container.Controls.Add(suppdata);
            suppdata.Show();
        }

        private void residencebtn_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            RESIDENCE residence = new RESIDENCE();
            residence.TopLevel = false;
            container.Controls.Add(residence);
            residence.Show();
        }

        private void reviewbtn_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            review review = new review();
            review.TopLevel = false;
            container.Controls.Add(review);
            review.Show();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
