using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace HpGameServerDemo
{
	public class MysqlManager
	{
		private static MysqlManager instance;
		public static MysqlManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new MysqlManager();
				}
				return instance;
			}
		}

		//数据库连接字符串
		private string connectionString;

		MysqlManager()
		{
			//数据库连接字符串
			connectionString = "Server=localhost;Port=3306;Database=unitytext;User ID=root;Password=root;Pooling=true;MinimumPoolSize=5;MaximumPoolSize=20;";
			
			//创建表（使用临时连接）
			using (var con = new MySqlConnection(connectionString))
			{
				con.Open();
				using (var cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS account (id INT PRIMARY KEY AUTO_INCREMENT, account VARCHAR(255) UNIQUE, password VARCHAR(255))", con))
				{
					cmd.ExecuteNonQuery();
				}
			}
		}

		//执行命令，除了查询以外的命令
		public int ExecuteCmd(string command)
		{
			using (var con = new MySqlConnection(connectionString))
			{
				con.Open();
				using (var cmd = new MySqlCommand(command, con))
				{
					return cmd.ExecuteNonQuery();
				}
			}
		}

		//执行查询单个
		public object SearchOne(string command)
		{
			using (var con = new MySqlConnection(connectionString))
			{
				con.Open();
				using (var cmd = new MySqlCommand(command, con))
				{
					return cmd.ExecuteScalar();
				}
			}
		}

		//查询多个
		public MySqlDataReader Search(string command)
		{
			var con = new MySqlConnection(connectionString);
			con.Open();
			var cmd = new MySqlCommand(command, con);
			// 注意：这里返回的Reader需要在使用完后手动关闭连接
			return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
		}
	}
}
