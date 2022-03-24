using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace wpclass
{
    public class DataAccessModules
    {
        public DataTable getAllStudents()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_students_get_all", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getAllModules()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_all_names", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable viewHighSchools(int schoolNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_high_school_view", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@schoolnum", SqlDbType.Int).Value = schoolNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getModules(int int_student_num)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_all", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@student_num", SqlDbType.Int).Value = int_student_num;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getModule(int int_module_num)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_single", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@module_num", SqlDbType.Int).Value = int_module_num;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getAllStudentsByModule(int int_module_num)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_all_students",SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@module_num", SqlDbType.Int).Value = int_module_num;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getDepartmentNames()  
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_departments_get_all", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();


            return DataTable_DTable;
        }

        public DataTable getStaffByDepartmentNum(int departnum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_department_get_staff_all", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@departNum", SqlDbType.Int).Value = departnum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getStaffInfo(int memberNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_staff_get_info", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@memberNum", SqlDbType.Int).Value = memberNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getStaffCountriesVisited(int memberNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_staff_get_countries_visited", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@memberNum", SqlDbType.Int).Value = memberNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getStudent(int int_student_num)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_students_get_single", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@student_num", SqlDbType.Int).Value = int_student_num;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public void updateStudent(int int_stud_num, string string_first_name, string string_last_name)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_students_update", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@student_num", int_stud_num);
            SQLDBCommand.Parameters.AddWithValue("@first_name", string_first_name);
            SQLDBCommand.Parameters.AddWithValue("@last_name", string_last_name);

            SQLConnection_DBcnn.Open();
            SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();
        }

        public void updateModule(int int_module_num, string module_code, int lecturer_num, int fc_num)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_update", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@moduleCode", module_code);
            SQLDBCommand.Parameters.AddWithValue("@moduleNum", int_module_num);
            SQLDBCommand.Parameters.AddWithValue("@lecturerNum", lecturer_num);
            SQLDBCommand.Parameters.AddWithValue("@fcNum", fc_num);

            SQLConnection_DBcnn.Open();
            SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();
        }
        public void updateHighSchoolName(string schoolName, int schoolNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_high_school_name_update", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@schoolname", schoolName);
            SQLDBCommand.Parameters.AddWithValue("@schoolnum", schoolNum);
            

            SQLConnection_DBcnn.Open();
            SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();
        }

        public bool updateLecturer(int lecturerNum, string firstName, string lastName, string email)
        {
            int success = 0;
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_lecturer_update", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@lecturerNum", lecturerNum);
            SQLDBCommand.Parameters.AddWithValue("@firstName", firstName);
            SQLDBCommand.Parameters.AddWithValue("@lastName", lastName);
            SQLDBCommand.Parameters.AddWithValue("@email", email);

            SQLConnection_DBcnn.Open();
            success = SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();

            if(success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void addStudent(string string_first_name, string string_last_name)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_students_add", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;            
            SQLDBCommand.Parameters.AddWithValue("@first_name", string_first_name);
            SQLDBCommand.Parameters.AddWithValue("@last_name", string_last_name);

            SQLConnection_DBcnn.Open();
            SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();
        }

        public void addHighSchool(string highSchoolName, int studentNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_high_school_add_school", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@schoolname", highSchoolName);
            SQLDBCommand.Parameters.AddWithValue("@studentnum", studentNum);

            SQLConnection_DBcnn.Open();
            SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();
        }

        public void addModule(string moduleCode, int lecturerNum, int fcNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_add", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@moduleCode", moduleCode);
            SQLDBCommand.Parameters.AddWithValue("@lecturerNum", lecturerNum);
            SQLDBCommand.Parameters.AddWithValue("@fcNum", fcNum);

            SQLConnection_DBcnn.Open();
            SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();
        }

        public bool addLecturer(string firstName, string lastName, string email)
        {
            int success = 0;
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand SQLDBCommand = new SqlCommand("MC_lecturer_add", SQLConnection_DBcnn);

            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@first_name", firstName);
            SQLDBCommand.Parameters.AddWithValue("@last_name", lastName);
            SQLDBCommand.Parameters.AddWithValue("@email", email);

            SQLConnection_DBcnn.Open();
            success = SQLDBCommand.ExecuteNonQuery();

            SQLConnection_DBcnn.Close();

            SQLDBCommand.Dispose();
            SQLConnection_DBcnn.Dispose();

            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable getDetails(int moduleNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_details", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@moduleNum", SqlDbType.Int).Value = moduleNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getModuleModuleName(int moduleNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_modulename", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@moduleNum", SqlDbType.Int).Value = moduleNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getModuleLecturer(int moduleNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_lecturer", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@moduleNum", SqlDbType.Int).Value = moduleNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getModuleFacultyName(int moduleNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_facultyname", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@moduleNum", SqlDbType.Int).Value = moduleNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getAllLecturerNames()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_all_lecturers", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;            
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getAllLecturerDetails()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_lecturer_details", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getAllFacultyNames()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_modules_get_all_faculty_names", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getAllHighSchools()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_skoolers_get_all", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getEligibleHeadStudents()
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_high_school_get_eligible_head_student", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public DataTable getHighSchoolHeadStudent(int highSchoolNum)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_high_school_get_head_student", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.Add("@highSchoolNum", SqlDbType.Int).Value = highSchoolNum;
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return DataTable_DTable;
        }

        public bool checkUserLogin(string username, string password)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_check_user_login", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@username", username);
            SQLDBCommand.Parameters.AddWithValue("@password", password);
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return int.Parse(DataTable_DTable.Rows[0]["row count"].ToString()) == 0? false: true;
        }      
        
        public bool checkSchoolNameExits(string schoolName)
        {
            SqlConnection SQLConnection_DBcnn = new SqlConnection(connectionString());
            DataTable DataTable_DTable;
            SqlDataAdapter SqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand SQLDBCommand = new SqlCommand("MC_high_school_name_exists", SQLConnection_DBcnn);
            DataTable_DTable = new DataTable("type");

            SQLConnection_DBcnn.Open();
            SqlDataAdapter_SQLda.SelectCommand = SQLDBCommand;
            SQLDBCommand.CommandType = CommandType.StoredProcedure;
            SQLDBCommand.Parameters.AddWithValue("@schoolname", schoolName);            
            SqlDataAdapter_SQLda.Fill(DataTable_DTable);

            //Garbage collection
            SQLConnection_DBcnn.Close();
            SqlDataAdapter_SQLda.Dispose();

            return int.Parse(DataTable_DTable.Rows[0]["row count"].ToString()) == 0 ? false : true;
        }

        public String connectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
    }
}