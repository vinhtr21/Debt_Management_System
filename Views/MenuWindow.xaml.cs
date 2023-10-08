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
        AdminInfor adminInfor = new AdminInfor();
        UserInfo userInfo = new UserInfo();
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnViewInfo_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.isAdmin == true)
            {
                adminInfor.Show();
            }
            else
            {
                userInfo.Show();
            }
            this.Close();
        }
    }
}
