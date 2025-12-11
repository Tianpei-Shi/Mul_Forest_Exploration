using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class UserDAL
	{
		//字典保存客户端所有的用户模型
		private Dictionary<IntPtr, UserModel> ptrUserDic = new Dictionary<IntPtr, UserModel>();
		private Dictionary<int, UserModel> idUserDic = new Dictionary<int, UserModel>();
		//id
		private int userid = 1;
		
		//添加一名角色
		public int AddUser(IntPtr ptr, int index)
		{
			UserModel model = new UserModel();
			model.ID = userid++;
			model.Careerinfo = Careerinfo.CareerList[index - 1];
			model.HP = model.Careerinfo.MaxHp;
			ptrUserDic.Add(ptr, model);
			idUserDic.Add(model.ID, model);
			return model.ID;
		}

		public void RemoveUser(IntPtr ptr)
		{
			idUserDic.Remove(ptrUserDic[ptr].ID);
			ptrUserDic.Remove(ptr);
		}

		//获取所有的连接
		public IntPtr[] GetUserPtr()
		{
			return ptrUserDic.Keys.ToArray();
		}

		//获取所有的模型
		public UserModel[] GetUserModels()
		{
			return ptrUserDic.Values.ToArray();
		}

		//获取对应ID的模型
		public UserModel GetUserModel(int index)
		{
			return idUserDic[index];
		}

		//获取对应连接的模型
		public UserModel GetUserModel(IntPtr ptr)
		{
			return ptrUserDic[ptr];
		}
	}
}
