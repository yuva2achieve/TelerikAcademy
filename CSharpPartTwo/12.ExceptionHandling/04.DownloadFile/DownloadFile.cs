using System;
using System.Linq;
using System.Net;

namespace _04.DownloadFile
{
    class DownloadFile
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter file URI:");
                string uri = Console.ReadLine();
                WebClient downloader = new WebClient();
                downloader.DownloadFile(uri, "picture.jpg");
                Console.WriteLine("Download Complete");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The URI is null");
            }
            catch (WebException)
            {
                Console.WriteLine("The URI is invalid or file doesn't exist or filename is null or empty");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}
