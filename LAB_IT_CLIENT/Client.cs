using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using LAB_IT_SERVER_;
using System.Runtime.Remoting.Channels.Tcp;

namespace LAB_IT_CLIENT
{
    static class Client
    {
        public static DatabaseManager databaseManager;
        public static void Init()
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan, false);
            databaseManager = (DatabaseManager)Activator.GetObject(typeof(DatabaseManager),
                  "tcp://localhost:10000/DataBaseManager");
            databaseManager.Init();
        }
    }
}
