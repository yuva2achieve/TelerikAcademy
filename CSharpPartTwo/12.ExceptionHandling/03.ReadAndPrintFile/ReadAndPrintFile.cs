using System;
using System.Linq;
using System.IO;

namespace _03.ReadAndPrintFile
{
    class ReadAndPrintFile
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter file path:");
                string filePath = Console.ReadLine();
                string text = File.ReadAllText(filePath);
                Console.WriteLine("File content is: ");
                Console.WriteLine(text);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path is null");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Path is too long.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Path not found");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error occurred while opening the file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Can't access file");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Path is in an invalid format");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path is zero or contains invalid characters");
            }
        }
    }
}
