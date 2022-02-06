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
        public String connectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
    }
}