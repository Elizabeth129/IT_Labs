using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace LAB_IT_SERVER_
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 10000;
            TcpChannel chan = new TcpChannel(port);
            ChannelServices.RegisterChannel(chan, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
               typeof(DatabaseManager), "DataBaseManager",
               WellKnownObjectMode.Singleton);
            Console.WriteLine(string.Format("Started server on port {0}", port));
            string command = "";
            while (command.ToLower() != "quit" && command.ToLower() != "exit")
            {
                command = Console.ReadLine();
            }
        }
    }
}
