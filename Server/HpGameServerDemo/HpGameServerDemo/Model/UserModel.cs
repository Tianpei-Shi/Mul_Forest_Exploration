using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class Careerinfo
	{
		public int ModelID;
		public int MaxHp;
		public int Attack;
		public int StartPoint;

		public Careerinfo(int modelID, int maxHp, int attack, int point)
		{
			this.ModelID = modelID;
			this.MaxHp = maxHp;
			this.Attack = attack;
			this.StartPoint = point;
		}

		public static Careerinfo[] CareerList = new Careerinfo[]
		{
			//战士
			new Careerinfo(1,100,10,1),
			//法师
			new Careerinfo(2,80,15, 2),
		};
	}
	public class UserModel
	{
		public int ID;
		public int HP;
		public float[] points;
		public Careerinfo Careerinfo;

	}
}
