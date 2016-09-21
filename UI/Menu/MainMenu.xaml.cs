using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public ProductEntity product = new ProductEntity();
        public StockEntity stock = new StockEntity();
        public Operations operations = new Operations();

        DataTable productDataTable = new DataTable();
        DataTable stockDataTable = new DataTable();

        public MainMenu()
        {
            InitializeComponent();

            if (Login.isLoggedin == true)
            {
                loginStatusLabel.Content = Login.activeUserName;
                dateStatusLabel.Content = DateTime.Now;
            }

            this.FillSearchProductNameComboBoxItemData();
            this.FillDataGridWithStockData();
        }

        private void FillSearchProductNameComboBoxItemData()
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

            searchProductByNameComboBox.ItemsSource = productDataTable.DefaultView;
        }

        private void FillDataGridWithStockData()
        {
            DataTable productDataTable = new DataTable();

            try
            {
                productDataTable = operations.GetProductStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            productDataGrid.ItemsSource = productDataTable.DefaultView;
        }

        private void masterEntryItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void categorySubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Category());
        }

        private void notepadSubItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void calcSubItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void wordpadSubItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void taskManagerSubItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void regSubItem_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Register());
        }

        private void loginDetailsSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login_Details());
        }

        private void productSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Product());
        }

        private void profileEntrySubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Customer());
        }

        private void companySubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Company());
        }

        private void aboutSubItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sales & Inventory Management System v1.0", "About", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        private void stock1SubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Stock());
        }

        private void sales1SubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Sales());
        }

        private void customersRecordSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CustomersRecord());
        }

        private void productsRecordSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ProductsRecord());
        }

        private void stockRecordSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new StockRecord());
        }

        private void salesRecordSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SalesRecord());
        }

        private void productDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                product.ProductName = searchProductByNameComboBox.Text;
                stock.ProductName = product.ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Argument", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            try
            {
                productDataTable = operations.SearchProduct(product);
                //stockDataTable = operations.GetProductStock(stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (productDataTable.Rows.Count > 0)
            {
                productDataGrid.ItemsSource = productDataTable.DefaultView;
                //productDataGrid.ItemsSource = stockDataTable.DefaultView; 
            }
            else
            {
                MessageBox.Show("No Records Found for Product:  " + product.ProductName, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterToolBar_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Register());
        }

        private void StockToolBar_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Stock());
        }

        private void SalesToolBar_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Sales());
        }

        private void ProductToolBar_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Product());
        }

        private void LogoutToolBar_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login());
        }

        private void searchProductByNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InventoryToolBar_Click(object sender, RoutedEventArgs e)
        {
            this.FillDataGridWithStockData();
        }

        private void userProfileSubItem_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new UserProfile());
        }
    }
}
