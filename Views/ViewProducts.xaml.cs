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

namespace Debt_Management.Views
{
    /// <summary>
    /// Interaction logic for ViewProducts.xaml
    /// </summary>
    public partial class ViewProducts : Window
    {
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
	}
}
