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

        public String connectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
    }
}