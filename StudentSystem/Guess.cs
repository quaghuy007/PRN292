using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentSystem
{
    public partial class Guess : Form
    {
        string uname;

        public string Uname { get => uname; set => uname = value; }
        public Guess()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                dgstudent.DataSource = null;
                dgfess.DataSource = null;
                dgfess.Visible = false;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 0;
                txtsname.Text = "";
                lblrecord.Text = "";
                loadData();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }
        private void loadData()
        {
            dgstudent.DataSource = DAO.getTop10Student();
            dgstudent.Visible = true;
            lbldisplay.Text = "Welcome " + uname;
            lbldisplay.Visible = true;
            btnlogout.Visible = true;
            pnllogo.Visible = true;
            dgstudent.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void Guess_Load(object sender, EventArgs e)
        {
            lblsec.Text = System.DateTime.Now.ToString();
            label72.Text = System.DateTime.Now.DayOfWeek.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            lblsec.Text = System.DateTime.Now.ToString();


        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            btnedit.Visible = false;
            lblfees.Text = "";
            lblfeeerror.Text = "";
            gpupdatefees.Visible = false;
            txtfeeid.Text = "";
            txtfeeadd.Text = "";
            MessageBox.Show("Xin loi chuc nang dang trong qua trinh phat trien");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 2;
                DataTable dt = DAO.GetAllData("CourseMst");
                dgcourse.DataSource = dt;
                dgcourse.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                dgteacher.DataSource = null;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 3;
                dgteacher.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            lbldisplay.Visible = false;
            lbldisplay.Text = "";
            tbstudent.Visible = false;
            pnllogo.Visible = false;
            btnlogout.Visible = false;
            this.Hide();
            var f = new MainForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblrecord.Text = "";
                dgstudent.DataSource = null;
                dgstudent.Visible = true;
                dgfess.DataSource = null;
                dgfess.Visible = false;

                if (txtsname.Text == "" || txtsname.Text == null)
                {
                    MessageBox.Show("Invalid Name !!", "Group5");
                }
                else
                {
                    dgstudent.DataSource = DAO.GetAllStudentByName(txtsname.Text);
                }


                lblrecord.Text = "Record = " + dgstudent.RowCount.ToString();

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsname.Text = "";
            dgstudent.DataSource = null;
            dgfess.DataSource = null;
            lblrecord.Text = "";
            loadData();
        }

        

        private void btnViewSche_Click(object sender, EventArgs e)
        {
            if (dgstudent.SelectedRows.Count > 0)
            {
                int row = dgstudent.CurrentCell.RowIndex;
                string role = dgstudent.Rows[row].Cells["SID"].Value.ToString();
                MessageBox.Show(role);
                Schedulecs sch = new Schedulecs(role);
                sch.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select at least a student");
            }
        }
    }
}
