using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Management.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
