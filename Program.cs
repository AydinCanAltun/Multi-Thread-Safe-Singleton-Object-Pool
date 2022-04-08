using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

namespace RentRoom
{
    class Program
    {
        private static readonly int CLIENT_SIZE = 15;
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRoomPool, RoomPool>();
            
            for(int i=0; i<CLIENT_SIZE; i++){
                Client client = new Client();
                client.ThreadId = i + 1;
                Thread thread = new Thread(new ThreadStart(client.DoSomething));
                thread.Start();
            }
        }
    }
}
