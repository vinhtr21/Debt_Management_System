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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        
        
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnViewInfo_Click(object sender, RoutedEventArgs e)
        {
			AdminInfor adminInfor = new();
			UserInfo userInfo = new();
			if (MainWindow.isAdmin == true)
            {
                this.Close();
                adminInfor.Show();
            }
            else
            {
				this.Close();
				userInfo.Show();
            }
        }

		private void btnMember_Click(object sender, RoutedEventArgs e)
		{
            ViewAllMember view = new ViewAllMember();
			if (MainWindow.isAdmin == true)
			{
				this.Close();
				view.Show();
            }
            else
            {
                MessageBox.Show("chuc nang nay chi danh cho admin");
            }
		}

		private void btnViewProduct_Click(object sender, RoutedEventArgs e)
		{
            ViewProducts view = new ViewProducts();
			if (MainWindow.isAdmin == true)
			{
				this.Close();
				view.Show();
			}
			else
			{
				MessageBox.Show("chuc nang nay chi danh cho admin");
			}
		}

		private void btnDashBoard_Click(object sender, RoutedEventArgs e)
		{
			DashboardView view = new DashboardView();
			if (MainWindow.isAdmin == true)
			{
				this.Close();
				view.Show();
			}
			else
			{
				MessageBox.Show("chuc nang nay chi danh cho admin");
			}
		}

		private void btnRequire_Click(object sender, RoutedEventArgs e)
		{
			AdminRequireWindow admin = new AdminRequireWindow();
			UserRequire user = new UserRequire();
			if (MainWindow.isAdmin == true)
			{
				this.Close();
				admin.Show();
			}
			else
			{
				this.Close();
				user.Show();
			}
		}
	}
}
