using System;
using System.Linq;
using IronMQ;

namespace _01.IronMQSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("5210ab525adfbb0005000004",
                "tsb6KTpQVLC15L0ylhJX4cEnY_I");
            IQueue queue = client.Queue("SimpleChatQueue");
            while (true)
            {
                Console.WriteLine("Enter messages to be sent to the IronMQ server:");
			    string messageToSend = Console.ReadLine();
			    queue.Push(messageToSend);
                Console.WriteLine("Message sent to the IronMQ server.");
                Console.WriteLine("Listening for new messages from IronMQ server:");
            }
        }
    }
}
