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
    /// Interaction logic for UserSendMsg.xaml
    /// </summary>
    public partial class UserSendMsg : Window
    {
        public UserSendMsg()
        {
            InitializeComponent();
            LoadUsernamesFromDatabase();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            this.Close();
            menu.Show();
        }

        private void LoadUsernamesFromDatabase()
        {
            MembersList.Items.Add(AdminDAO.Instance.GetAdminInfor().Name);
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string selectedUser = AdminDAO.Instance.GetAdminInfor().Name;
            string message = MessageTextBox.Text;
            //SendMessageToSpecificUser(selectedUserID, message);
            ChatDisplay.Items.Add($"{AccountDAO.Instance.GetAccountByID(MainWindow.memberId).Name} to {selectedUser}: {message}");
            MessageTextBox.Text = string.Empty;
        }
    }
}
