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

namespace TeacherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = AddressTextBox.Text;
            string email = emailTextBox.Text;
            decimal salary = Convert.ToDecimal(salaryTextBox.Text);

            if (IsEmailExists(email))
            {

                MessageBox.Show("email   already  exits");
            }

            string connectionstring = "SERVER= MITHUN-PC; Database=MithunInfoDB;Integrated security=true";


            SqlConnection con = new SqlConnection(connectionstring);

            string query = "INSERT INTO mithuns VALUES('" + name + "','" + address + "','" + email + "','" + salary +
                           "') ";
            SqlCommand command = new SqlCommand(query, con);

            con.Open();
            int Rowaffected = command.ExecuteNonQuery();
            con.Close();
            if (Rowaffected > 0)
            {

                MessageBox.Show("Inserted sucessfully");
            }
            else
            {
                MessageBox.Show("Not inserted");
            }
            //connection datebasae
        }

        public bool IsEmailExists(string email)
        {
            string connectionstring = "SERVER= MITHUN-PC; Database=MithunInfoDB;Integrated security=true";


            SqlConnection con = new SqlConnection(connectionstring);

            string query = "SELECT * FROM mithuns WHERE Email='" + email + "'";

            SqlCommand command = new SqlCommand(query, con);
            bool isRegNOExists = false;
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isRegNOExists = true;
                break;


            }
            con.Close();
            reader.Close();
            return isRegNOExists;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string connectionstring =  "SERVER=MITHUN-PC; Database=MithunInfoDB;Integrated security=true";
            SqlConnection con = new SqlConnection(connectionstring);
            string query = "SELECT * FROM  mithuns";
            SqlCommand command = new SqlCommand(query, con);

            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            while (reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.id = int.Parse(reader["ID"].ToString());
                aTeacher.name = reader["Name"].ToString();
                aTeacher.address = reader["Address"].ToString();
                aTeacher.email = reader["Email"].ToString();
                aTeacher.salary = Convert.ToDecimal(reader["Salary"].ToString());

                teacherList.Add(aTeacher);
            }
            con.Close();
            reader.Close();
            LoadStudentListView(teacherList);

        }

        public void LoadStudentListView(List<Teacher> teachers)
        {

            foreach (var teacher in teachers)
            {
                ListViewItem item = new ListViewItem(teacher.id.ToString());

                item.SubItems.Add(teacher.name);
                item.SubItems.Add(teacher.address);
                item.SubItems.Add(teacher.email);
                item.SubItems.Add(teacher.salary.ToString());
                showListView.Items.Add(item);
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item=new ListViewItem();
            int id = int.Parse(item.Text.ToString());
             Teacher aTeacher=



        }

        public Student GetStudentBy( int ID )
        {
            


        }
          


      
    }
}
    

