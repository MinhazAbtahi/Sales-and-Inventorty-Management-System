using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        public CustomerEntity customer = new CustomerEntity();
        public Operations operations = new Operations();

        public Customer()
        {
            InitializeComponent();
        }

        private void customerSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customer.CustomerID = Convert.ToInt32(customerIdTextBox.Text);
                customer.CustomerName = customerrNameTextBox.Text;
                customer.Address = customerAddressTextBox.Text;
                customer.Email = customerEmailTextBox.Text;
                customer.ContactNo = Convert.ToInt32(customerContactTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;

            try
            {
                rowsAffected = operations.InsertCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Customer Registration Successfull!", "Customer Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Customer Registration Failed!", "Customer Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void customerNewButton_Click(object sender, RoutedEventArgs e)
        {
            customerIdTextBox.Text = "";
            customerrNameTextBox.Text = "";
            customerAddressTextBox.Text = "";
            customerEmailTextBox.Text = "";
            customerContactTextBox.Text = "";

            Switcher.Switch(new Customer());
        }

        private void customerUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customer.CustomerID = Convert.ToInt32(customerIdTextBox.Text);
                customer.CustomerName = customerrNameTextBox.Text;
                customer.Address = customerAddressTextBox.Text;
                customer.Email = customerEmailTextBox.Text;
                customer.ContactNo = Convert.ToInt32(customerContactTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;

            try
            {
                rowsAffected = operations.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Customer Update Successfull!", "Customer Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Customer Update Failed!", "Customer Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void customerDeleteeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void customerSearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
