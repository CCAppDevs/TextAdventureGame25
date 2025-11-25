using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Game
    {
        Map GameMap { get; set; }
        Player PlayerCharacter { get; set; }
        public bool IsRunning { get; set; }

        public Game()
        {
            GameMap = new Map(25, 25);
            
            PlayerCharacter = new Player(
                "Jesse",
                100,
                GameMap.EntranceX,
                GameMap.EntranceY,
                GameMap.SizeX,
                GameMap.SizeY
            );

            IsRunning = false;
        }

        public void Run()
        {
            IsRunning = true;

            while (IsRunning)
            {
                PrintMap();
                PrintMenu2();
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("1. Up");
            Console.WriteLine("2. Down");
            Console.WriteLine("3. Left");
            Console.WriteLine("4. Right");
            Console.WriteLine();
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    PlayerCharacter.MoveDown(-1);
                    break;
                case 2:
                    PlayerCharacter.MoveDown(1);
                    break;
                case 3:
                    PlayerCharacter.MoveRight(-1);
                    break;
                case 4:
                    PlayerCharacter.MoveRight(1);
                    break;
                case 0:
                    IsRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option, please try again.");
                    Console.ReadLine();
                    break;
            }
        }

        public void PrintMenu2()
        {
            Console.WriteLine("Where would you like to go? [U]P, [D]OWN, [L]EFT, [R]IGHT, [E]xit");
            Console.WriteLine();
            
            ConsoleKeyInfo keypress;

            do
            {
                keypress =  Console.ReadKey();
                
                if (keypress.Key == ConsoleKey.UpArrow)
                {
                    PlayerCharacter.MoveDown(-1);
                }

                if (keypress.Key == ConsoleKey.DownArrow)
                {
                    PlayerCharacter.MoveDown(1);
                }
            } while (keypress.Key != ConsoleKey.Escape);
        }

        public void PrintMap()
        {
            for (int y = 0; y < GameMap.Rooms.Count; y++)
            {
                for (int x = 0; x < GameMap.Rooms[y].Count; x++)
                {
                    if (PlayerCharacter.PosX == x && PlayerCharacter.PosY == y)
                    {
                        Console.Write("[@]");
                    } else
                    {
                        Console.Write($"[{GameMap.Rooms[y][x].GetRoomSymbol()}]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
