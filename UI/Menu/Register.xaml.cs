using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public UserEntity user = new UserEntity();
        public Operations operations = new Operations();

        public Register()
        {
            InitializeComponent();
        }

        private void regSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.UserName = regUserNameTextBox.Text;
                user.Name = regNameTextBox.Text;
                user.Password = regPassBox.Password;
                user.Email = regEmailTextBox.Text;
                user.ContactNo = Convert.ToInt32(regContactTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.InsertUser(user);
            }
            catch (Exception)
            {
                MessageBox.Show("SQLError!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("User Registration Successfull!", "User Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("User Registration Failed!", "User Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.isLoggedin == true)
            {
                Switcher.Switch(new MainMenu());
            }
            else
            {
                Switcher.Switch(new Login());
            }
        }

        private void regNewButton_Click(object sender, RoutedEventArgs e)
        {
            regUserNameTextBox.Text = "";
            regNameTextBox.Text = "";
            regPassBox.Password = "";
            regEmailTextBox.Text = "";
            regContactTextBox.Text = "";
            Switcher.Switch(new Product());
        }

        private void regUpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userSearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.UserName = regUserNameTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            DataTable userDataTable = new DataTable("User");

            try
            {
                userDataTable = operations.SearchUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            regNameTextBox.Text = userDataTable.Rows[0]["Name"].ToString();
            regEmailTextBox.Text = userDataTable.Rows[0]["Email"].ToString();
            regContactTextBox.Text = userDataTable.Rows[0]["ContactNo"].ToString();
        }
    }
}
