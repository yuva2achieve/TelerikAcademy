using System;
using System.Linq;
using System.Threading;
using IronMQ;
using IronMQ.Data;

namespace _01.IronMQReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("5210ab525adfbb0005000004",
                "tsb6KTpQVLC15L0ylhJX4cEnY_I");
            IQueue queue = client.Queue("SimpleChatQueue");
            Console.WriteLine("Listening for new messages from IronMQ server:");
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }
                Thread.Sleep(100);
            }
        }
    }
}
