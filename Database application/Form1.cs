using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=Mikhail-ROG;Integrated security=true");
            //SqlConnection myConn = new SqlConnection("Data Source=MSSQLSERVER; Initial Catalog=E:\\Users\\Mikhail\\Documents\\Datastorage\\Database application\\; Integrated Security=true");

            str = "CREATE DATABASE MyDatabase ON PRIMARY (NAME = MyDatabase_Data, " + 
                "FILENAME = 'E:\\Users\\Mikhail\\Documents\\Datastorage\\Database application\\MyDatabaseData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) LOG ON (NAME = MyDatabase_Log, " + 
                "FILENAME = 'E:\\Users\\Mikhail\\Documents\\Datastorage\\Database application\\MyDatabaseLog.ldf', SIZE 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            finally
            {
                if(myConn.State==ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
