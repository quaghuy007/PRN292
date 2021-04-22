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
    public partial class Schedulecs : Form
    {
        public Schedulecs(string r)
        {
            role = Convert.ToInt32(r);
            InitializeComponent();
        }
        int role;

        private void Schedulecs_Load(object sender, EventArgs e)
        {

            dsChedule.BackgroundColor = this.BackColor;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.Items.Add(new { Text = Convert.ToInt32(DateTime.Now.Year.ToString()) - 1, Value = Convert.ToInt32(DateTime.Now.Year.ToString()) - 1 });
            comboBox1.Items.Add(new { Text = DateTime.Now.Year.ToString(), Value = DateTime.Now.Year.ToString() });
            comboBox1.Items.Add(new { Text = Convert.ToInt32(DateTime.Now.Year.ToString())+1, Value = Convert.ToInt32(DateTime.Now.Year.ToString()) + 1 });
            comboBox1.SelectedIndex = 1;
            int i = comboBox2.FindStringExact(DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToString("MM/dd/yyyy"));
            comboBox2.SelectedIndex = i;


        }
        private void loadData(string year, string startDate, string endDate)
        {
            for (int i = 0; i < 6; i++)
            {
                int slot = i + 1;
                DataGridViewRow row = (DataGridViewRow)dsChedule.Rows[0].Clone();
                dsChedule.Rows.Add(row);
                dsChedule.Rows[i].Cells[0].Value = "slot " + slot;
            }
            DataTable course = DAO.GetCourseIDSche(role);
            
            foreach (DataRow dr in course.Rows)
            {
                DataTable sche = DAO.GetCourseSChe(dr["CourseID"].ToString(), startDate, endDate);
                string coursename = DAO.GetCourseName(dr["CourseID"].ToString()).Rows[0]["CName"].ToString();
                foreach (DataRow rows in sche.Rows) {
                    int slot = Convert.ToInt32(rows["Slot"].ToString());
                    string teachingdate = rows["TeachingDate"].ToString();
                    int roomid = Convert.ToInt32(rows["RoomID"].ToString());
                    string room = DAO.GetRoom(roomid).Rows[0]["RoomName"].ToString();
                    int column = DateCheck(teachingdate);
                    string info = coursename +"/"+ room;
                    dsChedule.Rows[slot-1].Cells[column].Value = info;
                    
                }
                
            }
            dsChedule.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            dsChedule.AutoSize = true;

        }

        private void loadDateToCbx(string year) {
            List<DateTime> listDate = getAllDateTime(Convert.ToInt32(year));

            List<DateTime> listSDate = new List<DateTime>();
            List<DateTime> listSDateDis = new List<DateTime>();
            for (int i = 0; i < listDate.Count; i++)
            {
                listSDate.Add(listDate[i].StartOfWeek(DayOfWeek.Monday));
            }
            listSDateDis = listSDate.Distinct().ToList();
            comboBox2.DataSource = listSDateDis;
            

        }


        private List<DateTime> getAllDateTime(int year)
        {
            var dates = new List<DateTime>();
            for(int i = 1; i < 13; i++)
            {
                for (var date = new DateTime(year, i, 1); date.Month == i; date = date.AddDays(1))
                {
                    dates.Add(date);
                }
            }
            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            

            return dates;
        }

        private int DateCheck(String date) {
            DateTime myDate = DateTime.Parse(date);
            if (myDate.DayOfWeek == DayOfWeek.Monday)
            {
                return 1;
            }
            if (myDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                return 2;
            }
            if (myDate.DayOfWeek == DayOfWeek.Wednesday)
            {
                return 3;
            }
            if (myDate.DayOfWeek == DayOfWeek.Thursday)
            {
                return 4;
            }
            if (myDate.DayOfWeek == DayOfWeek.Friday)
            {
                return 5;
            }
            if (myDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return 6;
            }
            if (myDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return 7;
            }
            return 0;
        } 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            loadDateToCbx(comboBox1.Text);
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.DataSource != null)
            {
                this.dsChedule.Rows.Clear();
                DateTime t1 = DateTime.Parse(comboBox2.Text);
                DateTime t2 = GetNextWeekday(t1, DayOfWeek.Sunday);
                loadData(DateTime.Now.Year.ToString(), t1.ToString("yyyy-MM-dd"), t2.ToString("yyyy-MM-dd"));
            }
        }
        public DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
