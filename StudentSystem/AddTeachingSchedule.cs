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
    public partial class AddTeachingSchedule : Form
    {
        string courseid;
        string btnname;
        public AddTeachingSchedule()
        {
            InitializeComponent();
        }

        public string Courseid { get => courseid; set => courseid = value; }
        public string Btnname { get => btnname; set => btnname = value; }

        private void AddTeachingSchedule_Load(object sender, EventArgs e)
        {
            DataTable data = DAO.GetCourseByID(courseid);
            DataTable rooms = DAO.GetAllData("RoomMst");
            comboBox2.DataSource = rooms;
            comboBox2.DisplayMember = "RoomName";
            comboBox2.ValueMember = "RID";
            textBox1.Text = data.Rows[0]["CName"].ToString();
            button1.Text = btnname;
            
            
            
        }
        public void setCbxValue()
        {
            if (comboBox3.Items.Count != 0) {
                DataTable record = DAO.GetCourseNotAddChedule(int.Parse(courseid));
                comboBox3.DisplayMember = "Text";
                comboBox3.ValueMember = "Value";
                for (int i = 0; i < record.Rows.Count; i++)
                {
                    int a = i + 1;
                    comboBox3.Items.Add(new { Text = a.ToString(), Value = a.ToString() });
                }
                comboBox3.SelectedIndex = 0;
            }
            
        }
        public void EditValue()
        {
            label5.Visible = true;
            comboBox3.Visible = true;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (btnname.Equals("Add"))
            {
                int result = DAO.AddSchedule(int.Parse(courseid), DateTime.Parse(dateTimePicker1.Value.ToString("MM/dd/yyyy")), int.Parse(comboBox1.Text), int.Parse(comboBox2.SelectedValue.ToString()));
                if (result > 0)
                {
                    MessageBox.Show("Added");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            else
            {
                
                int result = DAO.UpdateSche(DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")), int.Parse(comboBox1.Text), int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(courseid));
                if (result > 0)
                {
                    MessageBox.Show("Edited");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(comboBox3.Text);
            DataTable record = DAO.GetCourseNotAddChedule(int.Parse(courseid));
            dateTimePicker1.Value = DateTime.Parse(record.Rows[index - 1]["TeachingDate"].ToString());
            comboBox1.SelectedIndex = comboBox1.FindStringExact(record.Rows[index - 1]["Slot"].ToString());
            for(int i =0; i < comboBox2.Items.Count; i++)
            {
                if(comboBox2.SelectedValue.Equals(record.Rows[index - 1]["RoomID"].ToString()))
                {
                    comboBox2.SelectedIndex = i;
                }
            }
        }
    }
}
