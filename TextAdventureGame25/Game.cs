using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame25.Rooms;

namespace TextAdventureGame25
{
    public class Game
    {
        Map GameMap { get; set; }
        Player PlayerCharacter { get; set; }
        public bool IsRunning { get; set; }
        public IRoom? CurrentRoom { get; set; }

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
                Console.Clear();
                PrintMap();
                OnEnterRoom();
                ProcessInput();
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

        public void ProcessInput()
        {
            ConsoleKeyInfo keypress;

            
            keypress =  Console.ReadKey(true);
                
            if (keypress.Key == ConsoleKey.UpArrow || keypress.Key == ConsoleKey.W)
            {
                PlayerCharacter.MoveDown(-1);
            }
            
            if (keypress.Key == ConsoleKey.DownArrow || keypress.Key == ConsoleKey.S)
            {
                PlayerCharacter.MoveDown(1);
            }
            
            if (keypress.Key == ConsoleKey.LeftArrow || keypress.Key == ConsoleKey.A)
            {
                PlayerCharacter.MoveRight(-1);
            }

            if (keypress.Key == ConsoleKey.RightArrow || keypress.Key == ConsoleKey.D)
            {
                PlayerCharacter.MoveRight(1);
            }

            if (keypress.Key == ConsoleKey.Escape)
            {
                IsRunning = false;
            }

            if (keypress.Key == ConsoleKey.L)
            {
                Console.WriteLine("You look around...");
                if (CurrentRoom != null)
                {
                    CurrentRoom.LookAtRoom(PlayerCharacter);
                    Console.ReadLine();
                }
            }
        }

        public void PrintMap()
        {
            for (int y = 0; y < GameMap.Rooms.Count; y++)
            {
                for (int x = 0; x < GameMap.Rooms[y].Count; x++)
                {
                    if (PlayerCharacter.PosX == x && PlayerCharacter.PosY == y)
                    {
                        var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("[@]");
                        Console.ForegroundColor = oldColor;
                    } else
                    {
                        Console.Write($"[{GameMap.Rooms[y][x].GetRoomSymbol()}]");
                    }
                }
                Console.WriteLine();
            }
        }

        public void OnEnterRoom()
        {
            CurrentRoom = GameMap.GetRoomAtPosition(PlayerCharacter.PosX, PlayerCharacter.PosY);

            CurrentRoom.OnEnter();
        }
    }
}
