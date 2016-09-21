using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class Company : UserControl
    {
        public CompanyEntity company = new CompanyEntity();
        public Operations operations = new Operations();

        public Company()
        {
            InitializeComponent();

            this.FillCompanyComboBoxItemData();
        }

        private void FillCompanyComboBoxItemData()
        {
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = operations.GetCompanyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            productCompanyComboBox.ItemsSource = dataTable.DefaultView;
        }

        private void companySubmitButton_Click(object sender, RoutedEventArgs e)
        {
            company.Company = productCompanyComboBox.Text;

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.InsertCompany(company);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Company Registration Successfull!", "Company Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Company Registration Failed!", "Company Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void companySearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void companyNewButton_Click(object sender, RoutedEventArgs e)
        {
            productCompanyComboBox.Text = "";
            Switcher.Switch(new Company());
        }
    }
}
