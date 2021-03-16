using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;
using Newtonsoft.Json.Linq;

namespace appForCallCenter
{
    /// <summary>
    /// Логика взаимодействия для CallCenterLayout.xaml
    /// </summary>
    public partial class CallCenterLayout : Window
    {
        public CallCenterLayout()
        {
            InitializeComponent();
        }
        public string thisUserLogin;




        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (telNumberInpt.Text.Length == 9 && tinInpt.Text.Length == 9 && problemInpt.Text.Length > 0)
            {
                DateTime dateTime = DateTime.Today;
                string currentDate = dateTime.ToString("D");
                string clientTin = tinInpt.Text;
                string clientTelNumber = telNumberInpt.Text;
                string problemContent = problemInpt.Text;
                MainWindow mainWindow = new MainWindow();
               /* thisUserLogin = mainWindow.userLogin;*/


                string connString = "Host=192.168.70.114;Port=7777;Database=postgres;Username=postgres;Password=13123866rT;";
                NpgsqlConnection connection = new NpgsqlConnection(connString);
                connection.Open();  
                NpgsqlCommand insertClientProblems = new NpgsqlCommand("INSERT INTO mybuxuchet.user_problems(added_user, client_tin, client_number, problem_content, added_date) VALUES ('"+thisUserLogin+ "','"+clientTin+"','"+clientTelNumber+"','"+problemContent+"','"+currentDate+"');", connection);
                insertClientProblems.ExecuteNonQuery();
                connection.Close();
                /*errorsLabel.Content = currentDate;*/
                tinInpt.Clear();
                telNumberInpt.Clear();
                problemInpt.Clear();
            }
            else
            {
                errorsLabel.Content = "nimadur to'liq emas";
            }
        }
    }
}
