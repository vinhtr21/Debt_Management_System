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
            
            if (MainWindow.isAdmin == true)
            {
                AdminInfor adminInfor = new();
                this.Close();
                adminInfor.Show();
            }
            else
            {
                UserInfo userInfo = new();

                this.Close();
                userInfo.Show();
            }
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.isAdmin == true)
            {
                ViewAllMember view = new ViewAllMember();

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
            if (MainWindow.isAdmin == true)
            {
                ViewProducts view = new ViewProducts();

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
            if (MainWindow.isAdmin == true)
            {
                DashboardView view = new DashboardView();

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
            if (MainWindow.isAdmin == true)
            {
                AdminRequireWindow admin = new AdminRequireWindow();

                this.Close();
                admin.Show();
            }
            else
            {
                UserViewRequire user = new UserViewRequire();

                this.Close();
                user.Show();
            }
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.isAdmin == true)
            {
                PaymentAdminWindow admin = new PaymentAdminWindow();
                this.Close();
                admin.Show();
            }
            else
            {
                UserViewPaymentWindow user = new UserViewPaymentWindow();
                this.Close();
                user.Show();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.isAdmin = false;
            MainWindow.memberId = 0;
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void btnSMS_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.isAdmin == true)
            {
                AdminSendMsg admin = new AdminSendMsg();
                this.Close();
                admin.Show();
            }
            else
            {
                UserSendMsg user = new UserSendMsg();
                this.Close();
                user.Show();
            }
        }
    }
}
