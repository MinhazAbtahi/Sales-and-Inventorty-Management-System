using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : UserControl
    {
        public StockEntity stock = new StockEntity();
        public ProductEntity product = new ProductEntity();
        public Operations operations = new Operations();

        public Stock()
        {
            InitializeComponent();

            this.stockDatePicker.SelectedDate = DateTime.Now;
            this.FillStockProductNameComboBoxItemData();
            this.FillStockIdComboBoxItemData();
        }

        private void FillStockProductNameComboBoxItemData()
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

            stockProductNameComboBox.ItemsSource = productDataTable.DefaultView;
        }

        private void FillStockIdComboBoxItemData()
        {
            DataTable productDataTable = new DataTable();

            try
            {
                productDataTable = operations.GetStockIdList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            stockIdComboBox.ItemsSource = productDataTable.DefaultView;
        }

        private void stockProductSearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stock.ProductName = stockProductNameComboBox.Text;
                product.ProductName = stock.ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            DataTable productDataTable = new DataTable("Product");
            DataTable stockDataTable = new DataTable("Stock");

            try
            {
                productDataTable = operations.SearchProduct(product);
                stockDataTable = operations.SearchStock(stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            stockFeatureTextBox.Text = productDataTable.Rows[0]["Features"].ToString();
            stockPriceTextBox.Text = productDataTable.Rows[0]["Price"].ToString();
            try
            {
                stockIdComboBox.Text = stockDataTable.Rows[0]["StockID"].ToString();
                stockQuantitytextBox.Text = stockDataTable.Rows[0]["Quantity"].ToString();
                stockTotalPriceTextBox.Text = stockDataTable.Rows[0]["TotalPrice"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Stock Not Found", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void stockSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(stockPriceTextBox.Text);

                stock.ProductName = stockProductNameComboBox.Text;
                stock.StockID = Convert.ToInt32(stockIdComboBox.Text);
                stock.Quantity = Convert.ToInt32(stockQuantitytextBox.Text);
                stock.TotalPrice = Convert.ToDouble(stockTotalPriceTextBox.Text);
                stock.StockDate = stockDatePicker.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.InsertStock(stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Stock Registration Successfull!", "Stock Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Stock Registration Failed!", "Stock Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void stockCalculatePriceButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = Convert.ToInt32(stockQuantitytextBox.Text);
            double price = Convert.ToDouble(stockPriceTextBox.Text);
            double totalPrice = quantity * price;

            stockTotalPriceTextBox.Text = Convert.ToString(totalPrice);
        }

        private void stockNewButton_Click(object sender, RoutedEventArgs e)
        {
            stockProductNameComboBox.Text = "";
            stockIdComboBox.Text = "";
            stockFeatureTextBox.Text = "";
            stockPriceTextBox.Text = "";
            stockQuantitytextBox.Text = "";
            stockTotalPriceTextBox.Text = "";
            Switcher.Switch(new Stock());
        }

        private void stockUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stock.ProductName = stockProductNameComboBox.Text;
                stock.StockID = Convert.ToInt32(stockIdComboBox.Text);
                stock.Quantity = Convert.ToInt32(stockQuantitytextBox.Text);
                stock.TotalPrice = Convert.ToInt32(stockTotalPriceTextBox.Text);
                stock.StockDate = stockDatePicker.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.UpdateStock(stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Stock Update Successfull!", "Stock Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Stock Update Failed!", "Stock Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void stockDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stock.ProductName = stockProductNameComboBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Arguments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.DeleteStock(stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Stock Deletion Successfull!", "Stock Deletion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Stock Deletion Failed!", "Stock Deletion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
