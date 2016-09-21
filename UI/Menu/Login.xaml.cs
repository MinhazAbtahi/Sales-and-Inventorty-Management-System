using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl, ISwitchable
    {
        public UserEntity user = new UserEntity();
        public Operations operations = new Operations();
        DataTable dataTable = new DataTable();

        public static bool isLoggedin = false;
        public static string activeUserName = "";

        public Login()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.UserName = userNameTextBox.Text;
                user.Password = passwordBox.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            try
            {
                dataTable = operations.ValidateUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (dataTable.Rows.Count > 0)
            {
                isLoggedin = true;
                activeUserName = user.UserName;
                Switcher.Switch(new MainMenu());
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Register());
        }
    }
}
