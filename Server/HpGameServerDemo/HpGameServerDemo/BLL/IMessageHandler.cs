using HPSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMessageHandler
{
	void Server_OnReceive(IntPtr connId, myMessage message);

	void Server_OnClose(IntPtr connId);
}
