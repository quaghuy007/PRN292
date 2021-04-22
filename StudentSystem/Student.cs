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
    public partial class Student : Form
    {
        string uname;
        string role;
        public Student()
        {
            InitializeComponent();
        }

        public string Uname { get => uname; set => uname = value; }
        public string Role { get => role; set => role = value; }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Schedulecs sch = new Schedulecs(role);
            sch.Visible = true;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            lblsec.Text = System.DateTime.Now.ToString();
            label72.Text = System.DateTime.Now.DayOfWeek.ToString();
            lbldisplay.Text = "Welcome " + uname;
            lbldisplay.Visible = true;
            btnlogout.Visible = true;
            pnllogo.Visible = true;
            
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
                tbstudent.SelectedIndex = 1;
                dgcourse.Rows.Clear();
                DataTable dt = DAO.GetCourseID(Convert.ToInt32(role));
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Sorry! There no course aviable now");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataTable course = DAO.GetCourseByID(dr["CourseID"].ToString());
                        foreach (DataRow courses in course.Rows)
                        {
                            int n = dgcourse.Rows.Add();
                            string courseID = courses["CID"].ToString();
                            string courseName = courses["CName"].ToString();
                            string courseFees = courses["Fees"].ToString();
                            string Duration = courses["Duration"].ToString();
                            string teacherName = DAO.GetTeacherByID(courses["TeacherID"].ToString()).Rows[0]["TName"].ToString();
                            dgcourse.Rows[n].Cells[0].Value = courseID;
                            dgcourse.Rows[n].Cells[1].Value = courseName;
                            dgcourse.Rows[n].Cells[2].Value = courseFees;
                            dgcourse.Rows[n].Cells[3].Value = Duration;
                            dgcourse.Rows[n].Cells[4].Value = teacherName;
                        }
                    }
                }
                
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            try
            {
                dgteacher.DataSource = null;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 2;
                DataTable dt = DAO.GetAllData("TeacherMst");
                dgteacher.DataSource = dt;
                dgteacher.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }
        public void resetSourse(object sender, EventArgs e)
        {
            pictureBox7_Click(sender, e);  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgcourse.SelectedRows.Count > 0)
            {
                int row = dgcourse.CurrentCell.RowIndex;
                string courseID = dgcourse.Rows[row].Cells["courseid"].Value.ToString();
                string teacher = dgcourse.Rows[row].Cells["teachername"].Value.ToString();
                string cname = dgcourse.Rows[row].Cells["coursename"].Value.ToString();
                Register r = new Register();
                r.Courseid = courseID;
                r.Teacher = teacher;
                r.Coursename = cname;
                r.Visible = true;
                r.Role = role;
            }
            else
            {
                MessageBox.Show("Please select at least a student");
            }
        }
    }
}
