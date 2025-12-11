using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class BLLManager
	{
		private static BLLManager instance;
		public static BLLManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BLLManager();
				}
				return instance;
			}
		}

		//所有的BLL类都在这里实例化，并提供给外部调用
		public AccountBLL account = new AccountBLL();

		public UserBLL user = new UserBLL();

		public GameBLL game = new GameBLL();

	}
}

	
