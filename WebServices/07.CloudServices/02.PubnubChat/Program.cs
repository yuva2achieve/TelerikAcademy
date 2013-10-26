using PubNubMessaging.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PubnubChat
{
    class Program
    {
        private const string SubcribeKey = "sub-c-5c52dc30-0582-11e3-991c-02ee2ddab7fe";
        private const string PublishKey = "pub-c-e52a8135-dc8f-47c9-a195-1d35de03382c";
        private const string ChannelName = "PubnubChatClient";

        static void Main(string[] args)
        {
            Process.Start("..\\..\\PubnubChatClient.html");

            System.Threading.Thread.Sleep(2000);

            Pubnub pubnub = new Pubnub(PublishKey, SubcribeKey);

            // Publish a sample message to Pubnub
            pubnub.Publish<string>(ChannelName, "Hello Pubnub!",MessageSentCallback);

            // Show PubNub server time
            pubnub.Time(PrintTime);


            pubnub.Subscribe<string>(ChannelName, MessageReceivedCallback,DisplayConnectStatusMessage);

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish<string>(ChannelName, msg, MessageSentCallback);
                Console.WriteLine("Message {0} sent.", msg);
            }
        }

        private static void MessageSentCallback(string msg)
        {
            Console.WriteLine("Message sent!: {0}", msg);
        }

        private static void MessageReceivedCallback(string msg)
        {
            Console.WriteLine(msg);
        }


        private static void DisplayConnectStatusMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        private static void PrintTime(object serverTime)
        {
            Console.WriteLine("Server Time: " + serverTime.ToString());
        }
    }
}
