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
    public partial class login : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public login()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to exit?", "Exit Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(usertext.Text == "admin" && passtext.Text == "admin")
            {
                admin adminform = new admin();
                adminform.Show();
                this.Hide();
            }
            else if (usertext.Text == "staff" && passtext.Text == "1234")
            {
                registration regform= new registration();
                regform.Show();
                this.Hide();
            }
            else if(usertext.Text == "" && passtext.Text == "")
            {
                DialogResult result = MessageBox.Show("username and password can't be blank");
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid username or Password");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
