using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class DALManager
	{
		private static DALManager instance;
		public static DALManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DALManager();
				}
				return instance;
			}
		}
		//所有的DAL类都在这里实例化，并提供给外部调用
		public AccountDAL account = new AccountDAL();

		public UserDAL user = new UserDAL();
	}
}
