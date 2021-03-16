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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using Newtonsoft.Json.Linq;

namespace appForCallCenter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
             
           
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {   
            string userLogin = loginInpt.Text;
            string userPass = passwordBox.Password;
            string connString = "Host=192.168.70.114;Port=7777;Database=postgres;Username=postgres;Password=13123866rT;";
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            var selectUser = new NpgsqlCommand("SELECT user_role FROM mybuxuchet.users_list where user_login ='"+userLogin+"' and user_pass ='"+userPass+"';", connection);
            /*if (selectUser.AllResultTypesAreUnknown == false)
            {
                errorsLabel.Content = "user topilmadi";
            }*/
            /*else { */

            var result = selectUser.ExecuteScalar();
            if (result == null)
            {
                errorsLabel.Content = "user Topilmadi!";
            }

            else
            {
                int roleid = Convert.ToInt32(result);
                if (roleid == 7)
                {
                    errorsLabel.Content = "is Admin";
                   
                }

                else if (roleid == 6)
                {
                    errorsLabel.Content = "is Users";
                    CallCenterLayout callCenterLayout = new CallCenterLayout();
                    callCenterLayout.Show();
                    callCenterLayout.thisUserLogin = userLogin;
                }

            }
             
        }
        


    }   
    }

