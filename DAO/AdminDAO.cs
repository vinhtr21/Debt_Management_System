using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		
	}
}
