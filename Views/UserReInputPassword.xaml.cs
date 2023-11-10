using Debt_Management.DAO;
using Debt_Management.Models;
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
    /// Interaction logic for UserReInputPassword.xaml
    /// </summary>
    public partial class UserReInputPassword : Window
    {
        public UserReInputPassword()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Account account = AccountDAO.Instance.GetAccountByID(MainWindow.memberId);
            if (account.Password.Equals(txtPassword.Password))
            {
                
                UserEditInfo user = new UserEditInfo();
                user.Show(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password", "Error");
            }
        }
    }
}
