using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        public ProductEntity product = new ProductEntity();
        public Operations operations = new Operations();

        public Product()
        {
            InitializeComponent();

            this.FillProductNameComboBoxItemData();
            this.FillCategoryComboBoxItemData();
            this.FillCompanyComboBoxItemData();
        }

        private void FillProductNameComboBoxItemData()
        {
            DataTable productDataTable = new DataTable();

            try
            {
                productDataTable = operations.GetProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            productNameComboBox.ItemsSource = productDataTable.DefaultView;
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

        private void FillCategoryComboBoxItemData()
        {
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = operations.GetCategoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            productCategoryComboBox.ItemsSource = dataTable.DefaultView;
        }


        private void productSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                product.ProductName = productNameComboBox.Text;
                product.Category = productCategoryComboBox.Text;
                product.Company = productCompanyComboBox.Text;
                product.Features = productFeaturesTextBox.Text;
                product.Price = Convert.ToDouble(productPriceTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.InsertProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Product Registration Successfull!", "Product Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Product Registration Failed!", "Product Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void productNewButton_Click(object sender, RoutedEventArgs e)
        {
            productNameComboBox.Text = "";
            productCategoryComboBox.Text = "";
            productCompanyComboBox.Text = "";
            productFeaturesTextBox.Text = "";
            productPriceTextBox.Text = "";
            Switcher.Switch(new Product());
        }

        private void productNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void productUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                product.ProductName = productNameComboBox.Text;
                product.Category = productCategoryComboBox.Text;
                product.Company = productCompanyComboBox.Text;
                product.Features = productFeaturesTextBox.Text;
                product.Price = Convert.ToDouble(productPriceTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Product Update Successfull!", "Product Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Product Update Failed!", "Product Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void productDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                product.ProductName = productNameComboBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Product Deletion Successfull!", "Product Deletion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Product Deletion Failed!", "Product Deletion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void productSearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                product.ProductName = productNameComboBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Argument", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            DataTable productDataTable = new DataTable("Product");

            try
            {
                productDataTable = operations.SearchProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            productCategoryComboBox.Text = productDataTable.Rows[0]["Category"].ToString();
            productCompanyComboBox.Text = productDataTable.Rows[0]["Company"].ToString();
            productFeaturesTextBox.Text = productDataTable.Rows[0]["Features"].ToString();
            productPriceTextBox.Text = productDataTable.Rows[0]["Price"].ToString();
        }
    }
}
