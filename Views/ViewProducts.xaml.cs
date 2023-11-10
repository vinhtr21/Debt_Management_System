using Debt_Management.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Debt_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Debt_Management.Views
{
    /// <summary>
    /// Interaction logic for ViewProducts.xaml
    /// </summary>
    public partial class ViewProducts : Window
    {
        private DebtCompanyContext _context = new DebtCompanyContext();
        public ViewProducts()
        {
            InitializeComponent();
            LoadProducts();
        }

        public void LoadProducts()
        {
            listProducts.ItemsSource = ProductDAO.Instance.GetProducts();
        }

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menu = new MenuWindow();
			this.Close();
			menu.Show();
		}



        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    Id = int.Parse(txtID.Text),
                    ProductName = txtProductName.Text,
                    Price = double.Parse(txtPrice.Text),
                    Weight = double.Parse(txtWeight.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Product");
            }
            return product;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();
                if (product != null)
                {
                    product.Id = 0;
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    LoadProducts();
                    MessageBox.Show($"{product.ProductName} inserted successful", "Insert product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add product");
            }
        }

        private Product GetProductID(int productID)
        {
            Product product = null;
            try
            {
                product = _context.Products.SingleOrDefault(p => p.Id == productID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Product By ID");
            }
            return product;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();
                Product p = GetProductID(product.Id);
                if (p != null)
                {
                    _context.Products.Remove(p);
                    _context.SaveChanges();
                    LoadProducts();
                    MessageBox.Show($"{p.ProductName} deleted successful", "Delete Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete product");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();
                Product c = GetProductID(product.Id);
                if (c != null)
                {
                    _context.Entry<Product>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadProducts();
                    MessageBox.Show($"{c.ProductName} updated successful", "Update Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Product");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtWeight.Text = string.Empty;
        }

    }
}
