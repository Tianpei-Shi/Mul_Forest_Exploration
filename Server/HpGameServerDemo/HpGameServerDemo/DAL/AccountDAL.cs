using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class AccountDAL
	{
		//保存我们的账号
		private List<AccountModel> accountList = new List<AccountModel>();
		//登录成功的账号 IntPtr是连接的ID
		private Dictionary<IntPtr, AccountModel> ptrAccountDict = new Dictionary<IntPtr, AccountModel>();

		public AccountDAL()
		{
			//加载数据库的密码到列表中
			using (MySqlDataReader reader = MysqlManager.Instance.Search("SELECT * FROM account"))
			{
				//读取数据
				while (reader.Read())
				{
					int id = reader.GetInt32(0);
					string account = reader.GetString(1);
					string password = reader.GetString(2);
					AccountModel accountModel = new AccountModel();
					accountModel.ID = id;
					accountModel.Account = account;
					accountModel.Password = password;
					accountList.Add(accountModel);
				}
			} // using会自动关闭reader和连接
		}

		//添加账号1成功
		public int Add(string account, string password)
		{
			//遍历列表，已存在返回-1
			foreach(AccountModel model in accountList)
			{
				if(model.Account == account)
				{
					return -1;
				}
			}

			lock (this) 
			{
				//添加账号到数据库 - 修复SQL语句错误
				int res = MysqlManager.Instance.ExecuteCmd($"INSERT INTO account(account, password) VALUES('{account}', '{password}')");
				//判断是否添加成功
				if (res != 1)
				{
					return -1;
				}
			}

			//创建新的账号
			AccountModel accountModel = new AccountModel();
			accountModel.ID = accountList.Count + 1;
			accountModel.Account = account;
			accountModel.Password = password;
			accountList.Add(accountModel);
			return 1;
		}

		//登录 客户端已经连接上服务器了
		public int Login(IntPtr ptr, string account, string password)
		{
			//是否已经登录
			foreach(AccountModel model in ptrAccountDict.Values)
			{
				if(model.Account == account)
				{
					return -1;
				}
			}
			//判断是否正确
			foreach(AccountModel acc in accountList)
			{
				if(acc.Account == account && acc.Password == password)
				{
					//登录成功，保存连接ID和账号的对应关系
					ptrAccountDict.Add(ptr, acc);
					return acc.ID;
				}
			}
			return -1;
		}

		//账号下线
		public void Logout(IntPtr ptr)
		{
			if(ptrAccountDict.ContainsKey(ptr))
			{
				ptrAccountDict.Remove(ptr);
			}
		}
	}
}
