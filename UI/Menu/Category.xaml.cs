using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : UserControl
    {
        public CategoryEntity category = new CategoryEntity();
        public Operations operations = new Operations();

        public Category()
        {
            InitializeComponent();

            this.FillCategoryComboBoxItemData();
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

        private void categorySubmitButton_Click(object sender, RoutedEventArgs e)
        {
            category.Category = productCategoryComboBox.Text;

            int rowsAffected = 0;
            try
            {
                rowsAffected = operations.InsertCategory(category);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Category Registration Successfull!", "Category Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Category Registration Failed!", "Category Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void categoryNewButton_Click(object sender, RoutedEventArgs e)
        {
            productCategoryComboBox.Text = "";
            Switcher.Switch(new Category());
        }
    }
}
