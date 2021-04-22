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
    public partial class Register : Form
    {
        string role;
        string courseid;
        string coursename;
        string duration;
        string teacher;
        public Register()
        {
            InitializeComponent();
        }

        public string Courseid { get => courseid; set => courseid = value; }
        public string Coursename { get => coursename; set => coursename = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Teacher { get => teacher; set => teacher = value; }
        public string Role { get => role; set => role = value; }

        private void Register_Load(object sender, EventArgs e)
        {
            string slots = "";
            DataTable slot = DAO.GetSlotByCourseID(courseid);
            foreach(DataRow dr in slot.Rows)
            {
                slots = slots + "-" + dr["Slot"].ToString();
            }
            textBox1.Text = slots;
            textBox2.Text = teacher;
            textBox3.Text = duration;
            textBox4.Text = coursename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = DAO.RegisterCourse(courseid, role);
            if (result > 0)
            {
                MessageBox.Show("Register successfully");
            }
        }
    }
}
