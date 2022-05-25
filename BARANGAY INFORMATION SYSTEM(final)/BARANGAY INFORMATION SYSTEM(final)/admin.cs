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
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace BARANGAY_INFORMATION_SYSTEM_final_
{
    public partial class admin : Form
    {
        string mycon = "datasource=localhost;username=root;password=;database=regit_db";
        string myconn = "datasource=localhost;username=root;password=;database=regit_db";
        string s;
        string x;
        int numVal;
        int total;



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

        public admin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            

            show();
            info();
            
        }


        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to exit?", "Exit Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void admin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void admin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void admin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to logout?", "Exit Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                login loginform = new login();
                loginform.Show();
                this.Hide();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void show()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(mycon))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM regit_tbl", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;

            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string delquery = "DELETE FROM regit_tbl WHERE ID='" + s + "';";

                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(delquery, mycon2);
                MySqlDataReader MyReader1;
                mycon2.Open();
                MyReader1 = mycommand.ExecuteReader();
                MessageBox.Show("Record deleted successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            show();
            info();
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            s = row.Cells["ID"].Value.ToString();

            //bunifuMetroTextbox1.Text = s;
                //dataGridView1.CurrentCell.Value.ToString();
            
            x = this.dataGridView1.CurrentCell.ColumnIndex.ToString();

                numVal = Int32.Parse(x);
                
         
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            
            switch (numVal)
            {

                case 0:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET ID='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;

                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 1:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET FirstName='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        
                            using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                            {
                                MySqlConnection mycon2 = new MySqlConnection(mycon);
                                MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                                MySqlDataReader MyReader1;
                                mycon2.Open();
                                MyReader1 = mycommand.ExecuteReader();
                                MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                mycon2.Close();

                            }
                    }
                    catch (Exception ex)
                    {       MessageBox.Show(ex.Message);
                   }
                    break;

                case 2:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET MiddleName='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 3:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET LastName='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 4:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET Suffix='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 5:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET Age='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 6:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET DateofBirth='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 7:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET PlaceofBirth='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 8:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET Sex='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 9:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET CivilStatus='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 10:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET Telephone='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 11:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET MobileNo='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 12:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET EmailAddress='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 13:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET SupplementaryData='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 14:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET Province='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 15:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET City='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 16:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET Barangay='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 17:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET AreaSubdivision='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 18:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET HouseNo='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 19:
                    try
                    {
                        string updatequery = "UPDATE regit_tbl SET ComelecStatus='" + bunifuMetroTextbox1.Text + "' WHERE ID=" + s;
                        using (MySqlConnection sqlCon = new MySqlConnection(myconn))
                        {
                            MySqlConnection mycon2 = new MySqlConnection(mycon);
                            MySqlCommand mycommand = new MySqlCommand(updatequery, mycon2);
                            MySqlDataReader MyReader1;
                            mycon2.Open();
                            MyReader1 = mycommand.ExecuteReader();
                            MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mycon2.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;


                default:

                    break;
                    
            }

            bunifuMetroTextbox1.Text = "";
            show();
            info();
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        public void info()
        {

            try
            {
                string cnt1 = "SELECT COUNT(*) FROM regit_tbl;";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt1, mycon2);
                mycon2.Open();
                string tot = mycommand.ExecuteScalar().ToString();
                total = Int32.Parse(tot);
                
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE ComelecStatus= 'Registered';";
                    MySqlConnection mycon2 = new MySqlConnection(mycon);
                    MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                    mycon2.Open();
                label5.Text = mycommand.ExecuteScalar().ToString();
                double a = Int32.Parse(label5.Text); 
                double b = (a / total) * 100;
                b = Math.Truncate(b);
                int c = Convert.ToInt32(b);
                bunifuCircleProgressbar1.Value = c;
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE ComelecStatus= 'Not Registered';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label6.Text = mycommand.ExecuteScalar().ToString();
                
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE AreaSubdivision= 'MERRYLAND';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label26.Text = mycommand.ExecuteScalar().ToString();
                double a1 = Int32.Parse(label26.Text);
                double b1 = (a1 / total) * 100;
                b1 = Math.Truncate(b1);
                int c1 = Convert.ToInt32(b1);

                
                bunifuCircleProgressbar2.Value = c1;
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE AreaSubdivision= 'DREAMLAND';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label27.Text = mycommand.ExecuteScalar().ToString();
                double a2 = Int32.Parse(label27.Text);
                double b2 = (a2 / total) * 100;
                b2 = Math.Truncate(b2);
                int c2 = Convert.ToInt32(b2);
                bunifuCircleProgressbar3.Value = c2;
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE AreaSubdivision= 'WONDERLAND';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label28.Text = mycommand.ExecuteScalar().ToString();
                double a3 = Int32.Parse(label28.Text);
                double b3 = (a3 / total) * 100;
                b3 = Math.Truncate(b3);
                int c3 = Convert.ToInt32(b3);
                bunifuCircleProgressbar4.Value = c3;
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE AreaSubdivision= 'Namayan Castaneda';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label29.Text = mycommand.ExecuteScalar().ToString();
                double a4 = Int32.Parse(label29.Text);
                double b4 = (a4 / total) * 100;
                b4 = Math.Truncate(b4);
                int c4 = Convert.ToInt32(b4);
                bunifuCircleProgressbar5.Value = c4;
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE AreaSubdivision= 'J.P. RIZAL';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label30.Text = mycommand.ExecuteScalar().ToString();
                double a5 = Int32.Parse(label30.Text);
                double b5 = (a5 / total) * 100;
                b5 = Math.Truncate(b5);
                int c5 = Convert.ToInt32(b5);
                bunifuCircleProgressbar6.Value = c5;
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE SupplementaryData= 'Minor';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label15.Text = mycommand.ExecuteScalar().ToString();
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE SupplementaryData= 'Adult';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label18.Text = mycommand.ExecuteScalar().ToString();
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE SupplementaryData= 'Senior Citizen';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label20.Text = mycommand.ExecuteScalar().ToString();
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE SupplementaryData= 'Person with disability';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label22.Text = mycommand.ExecuteScalar().ToString();
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string cnt = "SELECT COUNT(*) AS total FROM regit_tbl WHERE SupplementaryData= 'Solo Parent';";
                MySqlConnection mycon2 = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(cnt, mycon2);
                mycon2.Open();
                label24.Text = mycommand.ExecuteScalar().ToString();
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
