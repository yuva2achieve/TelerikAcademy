using System;
using System.Linq;

namespace _05.SortByElementLenght
{
    class SortByElementLenght
    {
        static void Main(string[] args)
        {
            string[] myArr = { "a", "aaaaa", "aaaawasdawd", "a", "12355asdf", "wdasdwe" };
            string tmp = "";
            for (int i = 0; i < myArr.Length - 1; i++)
            {
                for (int j = i + 1; j < myArr.Length; j++)
                {
                    if (myArr[i].Length > myArr[j].Length)
                    {
                        tmp = myArr[i];
                        myArr[i] = myArr[j];
                        myArr[j] = tmp;
                    }
                }
            }
            foreach (var item in myArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
