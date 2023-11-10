using Debt_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Debt_Management.DAO
{
    public class AdminDAO
    {
        private DebtCompanyContext context = new DebtCompanyContext();
        private static AdminDAO instance = null;
        private static readonly object instanceLock = new object();
        private AdminDAO() { }

        public static AdminDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdminDAO();
                    }
                    return instance;
                }
            }
        }

        public Admin GetAdminInfor()
        {
            Admin ad = context.Admins.FirstOrDefault();
            return ad;
        }
        public Admin UpdateAdmin()
        {
            var admin = GetAdminInfor();
            var myDB = new DebtCompanyContext();
            myDB.Update(admin);
            myDB.SaveChanges();
            return admin;
        }
    }
}
