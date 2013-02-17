using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _11.FallingRocks
{
    struct Rock
    {
       public int x;
       public int y;
       public string c;
       public ConsoleColor color;
    }
    class FallingRocks
    {
        static void RemoveBuffer()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void DrawStringOnPosition(int x,int y,string c,
            ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        static void Main(string[] args)
        {
            RemoveBuffer();
            int livesCount = 3;
            Rock dwarf = new Rock();
            dwarf.x = Console.WindowWidth / 2 - 1;
            dwarf.y = Console.WindowHeight - 1;
            dwarf.c = "@";
            dwarf.color = ConsoleColor.Yellow;
            Random randomGenerator = new Random();
            List<Rock> rocks = new List<Rock>();
            while (true)
            {
                Rock firstRock = new Rock();
                firstRock.x = randomGenerator.Next(0, Console.WindowWidth);
                firstRock.y = 0;
                firstRock.c = "$";
                firstRock.color = ConsoleColor.Red;
                rocks.Add(firstRock);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.x-1 >= 0)
                        {
                            dwarf.x--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.x < Console.WindowWidth - 1)
                        {
                            dwarf.x++;
                        }
                    }
                }
                Console.Clear();
                List<Rock> newRocks = new List<Rock>();
                for (int i = 0; i < rocks.Count; i++)
                {
                    Rock oldRock = rocks[i];
                    Rock newRock = new Rock();
                    newRock.x = oldRock.x;
                    newRock.y = oldRock.y + 1;
                    newRock.c = oldRock.c;
                    newRock.color = oldRock.color;
                    if (newRock.y == dwarf.y && newRock.x == dwarf.x)
                    {
                        livesCount--;
                        if (livesCount == 0)
                        {
                            DrawStringOnPosition(40, 10, "GameOver", ConsoleColor.Red);
                            DrawStringOnPosition(35, 15, "Press Enter to exit", ConsoleColor.Red);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    if (newRock.y < Console.WindowHeight -2)
                    {
                        newRocks.Add(newRock);
                    }
                }
                rocks = newRocks;
                DrawStringOnPosition(dwarf.x, dwarf.y, dwarf.c,dwarf.color);
                foreach (var rock in rocks)
                {
                    DrawStringOnPosition(rock.x, rock.y, rock.c,rock.color);
                }
                DrawStringOnPosition(40, 10,"Lives"+livesCount, ConsoleColor.White);
                Thread.Sleep(250);
            }
        }
    }
}
