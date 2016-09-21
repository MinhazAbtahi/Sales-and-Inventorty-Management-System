using BusinessAccessLayer;
using BusinessEntityLayer;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : UserControl
    {
        public UserEntity user = new UserEntity();
        public Operations operations = new Operations();

        public UserProfile()
        {
            InitializeComponent();
        }

        private void userProfileNewButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new UserProfile());
        }

        private void userProfileUpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}
