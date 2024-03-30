using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LAB03_TINOCO_DAEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS;Initial Catalog=prueba;User Id=admin;Password=123456";

            List<Student> students = new List<Student>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudentId =  reader.GetInt32(0);
                    string FirstName = reader.GetString(1);
                    string LastName = reader.GetString(2);

                    students.Add( new Student(StudentId, FirstName, LastName));
                }

                connection.Close();

                dgStudents.ItemsSource = students;
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:", err.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS;Initial Catalog=prueba;User Id=admin;Password=123456";

            List<Student> students = new List<Student>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                connection.Close();

                dgStudents.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS;Initial Catalog=prueba;User Id=admin;Password=123456";

            List<Student> students = new List<Student>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string name = txtName.Text;

                string commandLike = $"SELECT * FROM students WHERE FirstName LIKE '{name}%'";
                SqlCommand command = new SqlCommand(commandLike, connection);

                //SqlCommand command = new SqlCommand("SELECT * FROM Students where FirstName="+name, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudentId = reader.GetInt32(0);
                    string FirstName = reader.GetString(1);
                    string LastName = reader.GetString(2);

                    students.Add(new Student(StudentId, FirstName, LastName));
                }

                connection.Close();

                dgStudents.ItemsSource = students;
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:", err.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS;Initial Catalog=prueba;User Id=admin;Password=123456";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string commandInsertStudent = $"INSERT INTO students (FirstName, LastName) VALUES ('{txtFirstName.Text}','{txtLastName.Text}')";

                SqlCommand commandInsert = new SqlCommand(commandInsertStudent, connection);

                int result = commandInsert.ExecuteNonQuery();

                if(result < 0) {
                    Console.WriteLine("Error al insertar datos");

                }
                else
                {
                    MessageBox.Show("Student saved successfully");
                }

                connection.Close();

                txtLastName.Clear();
                txtFirstName.Clear();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:", err.ToString());
            }
        }
    }
}