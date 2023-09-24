using Debt_Management.DAO;
using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Management.Repository
{
    public class AccountRepositoy : IAccountRepository
    {
        public IEnumerable<Account> GetAccounts() => AccountDAO.Instance.GetAccounts();
    }
}
