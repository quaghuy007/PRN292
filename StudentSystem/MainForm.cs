using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace StudentSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        DataTable userlogin = DAO.GetAllData("User");
        string role = "";
        public int userid;
        public string uname;
        private void gplogin_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblsec.Text = System.DateTime.Now.ToString();
            label72.Text = System.DateTime.Now.DayOfWeek.ToString();
        }

        //login 
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtusername.Text == "")
                {
                    MessageBox.Show("Please, Enter UserName !!", "Group5");

                }
                else if (txtpassword.Text == "")
                {
                    MessageBox.Show("Please, Enter Password !!", "Group5");

                }
                else
                {
                    
                    int user = 0;
                    foreach (DataRow rows in userlogin.Rows) {
                        if (txtusername.Text == rows["Account"].ToString() && txtpassword.Text == rows["Password"].ToString())
                        {
                            userid = 1;
                            uname = rows["Account"].ToString();
                            role = rows["Role"].ToString();
                            user = 1;
                        }
                    }
                    if (user == 0)
                    {
                        MessageBox.Show("Invalid Username or Password !!", "Group5");
                    }
                    else
                    {
                        if (role == "admin")
                        {
                            MessageBox.Show("Welcome to Group5 Assignment. You are login as admin", " Group5");
                            lbldisplay.Text = "Welcome " + uname;
                            lbldisplay.Visible = true;
                            setTextUserandPass();
                            gplogin.Visible = false;
                            btnlogout.Visible = true;
                            pnllogo.Visible = true;
                            setDisplayItem(true);


                        }
                        if (role == "guess")
                        {
                            
                            MessageBox.Show("Welcome to Group5 Assignment. You are login as guess", " Group5");
                            setTextUserandPass();
                            this.Hide();
                            var guess = new Guess();
                            guess.Uname = uname;
                            guess.Visible = true;
                            guess.Closed += (s, args) => this.Close();
                            guess.Show();
                        }
                        if(Regex.IsMatch(role, @"^\d+$"))
                        {
                            
                            MessageBox.Show("Welcome to Group5 Assignment. You are login as student", " Group5");
                            setTextUserandPass();
                            this.Hide();
                            var studnent = new Student();
                            studnent.Role = role;
                            studnent.Uname = uname;
                            studnent.Visible = true;
                            studnent.Closed += (s, args) => this.Close();
                            studnent.Show();
                        }
                    }
                }
                
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }
        //end login
        public void setTextUserandPass()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
        }
        private void setDisplayItem(bool status)
        {
            pictureBox8.Visible = status;
            pictureBox6.Visible = status;
            pictureBox1.Visible = status;
            button16.Visible = status;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 0;
            studentclear();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            lbldisplay.Visible = false;
            lbldisplay.Text = "";
            gplogin.Visible = true;
            tbstudent.Visible = false;
            pnllogo.Visible = false;
            btnlogout.Visible = false;
        }


        public void studentclear()
        {
            try
            {
                txtname.Text = "";
                txtsurname.Text = "";
                txtaddress.Text = "";
                txtpin.Text = "";
                txtcontact.Text = "";
                gpcourse.Enabled = false;
                txtemail.Text = "";
                txtfees.Text = "";
                txtcontact.Text = "";
                lblstudentmsg.Text = "";
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblsec.Text = System.DateTime.Now.ToString();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                dgstudent.DataSource = null;
                dgfess.DataSource = null;
                dgfess.Visible = false;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 1;
                txtsname.Text = "";
                lblrecord.Text = "";
                loadData();
                dgstudent.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
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
        private void loadData() {
            dgstudent.DataSource = DAO.getTop10Student();
            dgstudent.Visible = true;
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsname.Text = "";
            dgstudent.DataSource = null;
            dgfess.DataSource = null;
            lblrecord.Text = "";
            loadData();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bool status = false;
            try
            {
                if (MessageBox.Show("Are you sure !! you want to Delete this student", "Group5", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int row = dgstudent.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(dgstudent.Rows[row].Cells["SID"].Value.ToString());
                    int a = DAO.DeleteStudent(id);
                    if(a > 0)
                    {
                        MessageBox.Show("Deleted");
                        status = true;
                    }
                   
                }
                if (status) {
                    txtsname.Text = "";
                    dgstudent.DataSource = null;
                    dgfess.DataSource = null;
                    lblrecord.Text = "";
                    loadData();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int blank = 0;
                if (txtname.Text == "")
                {
                    lblnamee.Visible = true;
                    blank = 1;
                }
                else { lblnamee.Visible = false; }
                if (txtsurname.Text == "")
                {
                    lblsurnamee.Visible = true;
                    blank = 1;
                }
                else
                {
                    lblsurnamee.Visible = false;
                }
                if (txtemail.Text == "")
                {
                    lblemaile.Visible = true;
                    blank = 1;
                }
                else
                {
                    lblemaile.Visible = false;
                }

                if (txtemail.Text.Contains("@") && txtemail.Text.Contains("."))
                {
                    lblemaile.Visible = false;
                }
                else
                {
                    lblemaile.Visible = true;
                    blank = 1;
                }
                if (txtcontact.Text == "")
                {
                    lblmoe.Visible = true;
                    blank = 1;
                }
                else
                {
                    lblmoe.Visible = false;
                }

                if (blank == 0)
                {
                    lblmoe.Visible = false;
                    lblemaile.Visible = false;
                    lblnamee.Visible = false;
                    lblsurnamee.Visible = false;
                    Drpyear.SelectedItem = 0;
                    gpcourse.Enabled = true;
                    DataTable CourseDT = DAO.GetAllData("CourseMst");
                    cmbcourse.DataSource = CourseDT;
                    cmbcourse.DisplayMember = "CName";
                    cmbcourse.ValueMember = "Fees";
                    cmbcourse.Text = "SELECT";
                    txtfees.Text = "";
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfees.Text == "")
                {
                    MessageBox.Show("Please, Check your Course Fees.", "Group5");
                }
                else
                {
                    int ins = DAO.AddNewStudent(txtname.Text, txtsurname.Text, txtaddress.Text, txtpin.Text, txtcontact.Text, txtemail.Text, Convert.ToInt32(txtfees.Text), 0, Convert.ToInt32(txtfees.Text), Drpyear.Text, datestart.Value.Date, dateend.Value.Date);

                    if (ins == 1)
                    {
                        studentclear();
                        lblstudentmsg.Text = "Student Added Successfully !!";
                        MessageBox.Show("Student Added Successfully !!", "Group5");
                    }
                }
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
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 6;
                DataTable dt = DAO.GetAllData("TeacherMst");
                dgteacher.DataSource = dt;
                dgteacher.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
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
            MessageBox.Show("Xin loi chuc nang nay dang duoc phat trien them!");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                lblcourse.Text = "";
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 3;
                DataTable teacherdt = DAO.GetAllData("TeacherMst");
                cbxTeacher.DataSource = teacherdt;
                cbxTeacher.DisplayMember = "TName";
                cbxTeacher.ValueMember = "TID";
            }
            catch (Exception a)
            {

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 4;
                DataTable dt = DAO.GetAllData("CourseMst");
                dgcourse.DataSource = dt;
                dgcourse.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 5;
            txtteacher.Text = "";
            txtquli.Text = "";
        }
        //tab selected change
        private void tbstudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (role == "admin") 
                {
                    lblerror.Text = "";

                    if (tbstudent.SelectedIndex == 7)
                    {
                        tbadmin.Visible = true;
                        lblerror.Visible = false;
                        lblerror.Text = "";
                        cbxSelectRole.Visible = true;
                    }
                    

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }
        //end tab selectedchange

        private void cbxSelectRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSelectRole.SelectedIndex == 2)
            {
                dgAdminSearch.Visible = true;
                label15.Visible = true;
                textBox8.Visible = true;
                button8.Visible = true;
            }
            else {
                dgAdminSearch.Visible = false;
                label15.Visible = false;
                textBox8.Visible = false;
                button8.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dgAdminSearch.DataSource = DAO.GetAllStudentByName(textBox8.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (cbxSelectRole.SelectedIndex == 2) {
                int row = dgAdminSearch.CurrentCell.RowIndex;
                string id = dgAdminSearch.Rows[row].Cells["SID"].Value.ToString();
                int i = DAO.UpdateUser(id,txtauser.Text, txtapass.Text);
                if (i == 1) {
                    MessageBox.Show("Create Successfully");
                }
                
            }
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

        private void btnfeeview_Click(object sender, EventArgs e)
        {

        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
            try
            {
                int result = DAO.AddCourse(txtcoursename.Text, int.Parse(txtcoursefees.Text), cmbduration.Text, Convert.ToInt32(cbxTeacher.SelectedValue.ToString()));
                if (result > 0)
                {
                    MessageBox.Show("Add successfull");
                }
                else
                {
                    MessageBox.Show("Add unsuccessfull please check again all the field data");
                }
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
            
        }

        private void btnteacher_Click(object sender, EventArgs e)
        {
            try
            {
                int result = DAO.AddTeacher(txtteacher.Text, txtquli.Text);
                if (result > 0)
                {
                    MessageBox.Show("Add successfull");
                }
                else
                {
                    MessageBox.Show("Add unsuccessfull please check again all the field data");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Group5");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dgcourse.SelectedRows.Count > 0)
            {
                int row = dgcourse.CurrentCell.RowIndex;
                string id = dgcourse.Rows[row].Cells["CID"].Value.ToString();
                DataTable teachingschedule = DAO.GetCourseNotAddChedule(int.Parse(id));
                if (teachingschedule.Rows.Count == 0)
                {
                    AddTeachingSchedule add = new AddTeachingSchedule();
                    add.Btnname = "Add";
                    add.Courseid = id;
                    add.Visible = true;
                }
                if(teachingschedule.Rows.Count > 0)
                {
                    AddTeachingSchedule add = new AddTeachingSchedule();
                    add.Btnname = "Edit";
                    add.Courseid = id;
                    add.Visible = true;
                    add.EditValue();
                    add.setCbxValue();

                }
                
            }
            else
            {
                MessageBox.Show("Please select at least a course");
            }
        }

    }
}