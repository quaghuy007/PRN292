using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace StudentSystem
{
    class DAO
    {
        public static SqlConnection GetConnection()
        {
            string strConn = ConfigurationManager.ConnectionStrings["DBString"].ToString();
            return new SqlConnection(strConn);
        }
        public static DataTable GetRoom(int id)
        {
            string sql = "select RoomName from [RoomMst] where RID = "+id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetCourseByID(string id)
        {
            string sql = "select * from CourseMst where CID = " + id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        internal static DataTable GetCourseName(string id)
        {
            string sql = "select CName from [CourseMst] where CID = " + id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetCourseSChe(string id, string startDate, string endDate)
        {
            string sql = "select TeachingDate, Slot, RoomID from Courses_Schedules where CourseID = "+id+" and TeachingDate between '"+startDate+"' and '"+endDate+"'";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetCourseID(int id)
        {
            string sql = "SELECT distinct CID as CourseID FROM CourseMst WHERE CID  NOT IN (SELECT CourseID FROM Student_Course where StudentID = "+id+")";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetCourseIDSche(int id)
        {
            string sql = "select CourseID from Student_Course where StudentID = "+id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetTeacherByID(string id)
        {
            string sql = "select TName from TeacherMst where TID = " + id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetAllData(string tblName)
        {
            string sql = "select * from ["+tblName +"]";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static int UpdateUser(string id, string username, string pass) {
            string sql = "INSERT INTO [USER] VALUES(@role,@Account,@Pass)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            // Tao doi tuong parameter de truyen tham so cho cau truy van
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@role", SqlDbType.NVarChar),
                new SqlParameter("@Account", SqlDbType.NVarChar),
                new SqlParameter("@Pass", SqlDbType.NVarChar),
            };
            // Gán giá trị cho các Parameter
            para[0].Value = id;
            para[1].Value = username;
            para[2].Value = pass;
            // Them cac tham so cho doi tuong command
            cmd.Parameters.AddRange(para);

            // Mở kết nối tới CSDL
            cmd.Connection.Open();
            // Thực thi truy vấn
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
        public static DataTable GetAllStudentByName(string name)
        {
            string sql = "select * from [StudentMst] where SName like '"+name+ "%' or Surname like '" + name + "%'";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetAllStudentByID(int id)
        {
            string sql = "select * from [StudentMst] where SID = "+id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static int DeleteStudent(int id)
        {
            string sql = "Delete from Student_Course where StudentID = " + id + ";Delete from StudentMst where SID = " + id + ""; 
                SqlCommand cmd = new SqlCommand(sql, GetConnection());
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return result;
        }
        public static string GETDATE() {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        public static int AddNewStudent(string sname, string surename, string address, string pin, string contact, string email, int fees, int paid, int rem, string year, DateTime sdate, DateTime edate) {
            string sql = "INSERT INTO STUDENTMST VALUES(@SNAME,@SURENAME,@ADDRESS, @PIN, @CONTACT, @EMAIL,@FEES,@PAID,@REM,'none',@year,1,@SDATE,@EDATE,"+GETDATE()+","+GETDATE()+")";
            // Tao doi tuong command de thuc thi truy van
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            // Tao doi tuong parameter de truyen tham so cho cau truy van
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@SNAME", SqlDbType.NVarChar),
                new SqlParameter("@SURENAME", SqlDbType.NVarChar),
                new SqlParameter("@ADDRESS", SqlDbType.NVarChar),
                new SqlParameter("@PIN", SqlDbType.NVarChar),
                new SqlParameter("@CONTACT", SqlDbType.NVarChar),
                new SqlParameter("@EMAIL", SqlDbType.NVarChar),
                new SqlParameter("@FEES", SqlDbType.Int),
                new SqlParameter("@PAID", SqlDbType.Int),
                new SqlParameter("@REM", SqlDbType.Int),
                new SqlParameter("@year", SqlDbType.NVarChar),
                new SqlParameter("@SDATE", SqlDbType.DateTime),
                new SqlParameter("@EDATE", SqlDbType.DateTime),
            };
            // Gán giá trị cho các Parameter
            para[0].Value = sname;
            para[1].Value = surename;
            para[2].Value = address;
            para[3].Value = pin;
            para[4].Value = contact;
            para[5].Value = email;
            para[6].Value = fees;
            para[7].Value = paid;
            para[8].Value = rem;
            para[9].Value = year;
            para[10].Value = sdate;
            para[11].Value = edate;

            // Them cac tham so cho doi tuong command
            cmd.Parameters.AddRange(para);

            // Mở kết nối tới CSDL
            cmd.Connection.Open();
            // Thực thi truy vấn
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public static DataTable getTop10Student() {
            string sql = "select top(10) * from StudentMST";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetSlotByCourseID(string id)
        {
            string sql = "select distinct Slot from Courses_Schedules where CourseID = "+id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static int RegisterCourse(string cid, string sid)
        {
            string sql = "insert into Student_Course values(@cid, @sid)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            // Tao doi tuong parameter de truyen tham so cho cau truy van
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@cid", SqlDbType.Int),
                new SqlParameter("@sid", SqlDbType.Int),
            };
            // Gán giá trị cho các Parameter
            para[0].Value = cid;
            para[1].Value = sid;
            // Them cac tham so cho doi tuong command
            cmd.Parameters.AddRange(para);

            // Mở kết nối tới CSDL
            cmd.Connection.Open();
            // Thực thi truy vấn
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
        public static int AddCourse(string cname, int fees, string duration, int tid)
        {
            int count = 0;
            string sql = "insert into CourseMst (CName,Fees,Duration,TeacherID) values (@cname,@fees,@duration,@teacherid)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@cname",SqlDbType.NVarChar),
                new SqlParameter("@fees",SqlDbType.Int),
                new SqlParameter("@duration",SqlDbType.NVarChar),
                new SqlParameter("@teacherid",SqlDbType.Int)
            };

            para[0].Value = cname;
            para[1].Value = fees;
            para[2].Value = duration;
            para[3].Value = tid;

            cmd.Parameters.AddRange(para);

            cmd.Connection.Open();

            count = cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            return count;
        }
        public static int AddTeacher(string name, string quali)
        {
            int count = 0;
            string sql = "insert into [TeacherMst] (TName, Qualification) values (@name, @quali)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@quali",SqlDbType.NVarChar)
            };

            para[0].Value = name;
            para[1].Value = quali;

            cmd.Parameters.AddRange(para);

            cmd.Connection.Open();

            count = cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            return count;
        }

        public static int AddSchedule(int id, DateTime teachingdate, int slot, int roomid)
        {
            int count = 0;
            string sql = "insert into [Courses_Schedules] values (@CourseID, @TeachingDate, @Slot, @RoomID, 'none')";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CourseID",SqlDbType.Int),
                new SqlParameter("@TeachingDate",SqlDbType.DateTime),
                new SqlParameter("@Slot",SqlDbType.Int),
                new SqlParameter("@RoomID",SqlDbType.Int),
            };

            para[0].Value = id;
            para[1].Value = teachingdate;
            para[2].Value = slot;
            para[3].Value = roomid;

            cmd.Parameters.AddRange(para);

            cmd.Connection.Open();

            count = cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            return count;
        }

        public static DataTable GetCourseNotAddChedule(int id)
        {
            string sql = "select * from Courses_Schedules where CourseID = "+id;
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static int UpdateSche(DateTime date, int slot, int roomId, int teachId)
        {
            string sql = "update top(1) Courses_Schedules set [TeachingDate] = @date, [Slot] = @slot, [RoomID] = @room where[CourseID] = @teachId";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            // Tao doi tuong parameter de truyen tham so cho cau truy van
            SqlParameter p1 = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter p2 = new SqlParameter("@slot", SqlDbType.Int);
            SqlParameter p3 = new SqlParameter("@room", SqlDbType.Int);
            SqlParameter p4 = new SqlParameter("@teachId", SqlDbType.Int);
            // Gán giá trị cho các Parameter
            p1.Value = date;
            p2.Value = slot;
            p3.Value = roomId;
            p4.Value = teachId;
            // Them cac tham so cho doi tuong command
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            // Mở kết nối tới CSDL
            cmd.Connection.Open();
            // Thực thi truy vấn
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
    }
}
