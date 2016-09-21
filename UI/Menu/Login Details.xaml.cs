using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Login_Details.xaml
    /// </summary>
    public partial class Login_Details : UserControl
    {
        public UserEntity user = new UserEntity();
        public Operations operations = new Operations();

        public Login_Details()
        {
            InitializeComponent();

            this.FillUserDetails();
        }

        void FillUserDetails()
        {
            user.UserName = Login.activeUserName;

            DataTable userDataTable = new DataTable("User");

            try
            {
                userDataTable = operations.SearchUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            nameTextBlock.Text = userDataTable.Rows[0]["Name"].ToString();
            userNameTextBlock.Text = userDataTable.Rows[0]["UserName"].ToString();
            emailTextBlock.Text = userDataTable.Rows[0]["Email"].ToString();
            contactNoTextBlock.Text = "0" + userDataTable.Rows[0]["ContactNo"].ToString();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}
