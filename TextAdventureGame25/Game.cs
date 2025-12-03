using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame25.Rooms;

// TODO: remove the wasd movement so we stop having two actions on attack

namespace TextAdventureGame25
{
    public class Game
    {
        public static Game Instance { get; private set; }

        Map[] GameMap { get; set; }
        int CurrentFloor {  get; set; }
        public Player PlayerCharacter { get; set; }
        public bool IsRunning { get; set; }
        public IRoom? CurrentRoom { get; set; }

        public Game()
        {
            CurrentFloor = 0;
            IsRunning = false;
            Instance = this;
        }

        public void Run()
        {
            IsRunning = true;
            GameMap = new Map[100];

            for (int i = 0; i < GameMap.Length; i++)
            {
                GameMap[i] = new Map(25, 25);
            }

            //GameMap = new Map(25, 25);

            PlayerCharacter = new Player(
                "Jesse",
                100,
                5,
                GameMap[CurrentFloor].EntranceX,
                GameMap[CurrentFloor].EntranceY,
                GameMap[CurrentFloor].SizeX,
                GameMap[CurrentFloor].SizeY
            );

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
            for (int y = 0; y < GameMap[CurrentFloor].Rooms.Count; y++)
            {
                for (int x = 0; x < GameMap[CurrentFloor].Rooms[y].Count; x++)
                {
                    if (PlayerCharacter.PosX == x && PlayerCharacter.PosY == y)
                    {
                        var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("[@]");
                        Console.ForegroundColor = oldColor;
                    } else
                    {
                        var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = GameMap[CurrentFloor].Rooms[y][x].RoomColor;
                        Console.Write($"[{GameMap[CurrentFloor].Rooms[y][x].GetRoomSymbol()}]");
                        Console.ForegroundColor = oldColor;
                    }
                }
                Console.WriteLine();
            }
        }

        public void OnEnterRoom()
        {
            CurrentRoom = GameMap[CurrentFloor].GetRoomAtPosition(PlayerCharacter.PosX, PlayerCharacter.PosY);

            CurrentRoom.OnEnter();
        }

        public void OnExitMap()
        {
            // switch to a new map
            // dont do this GameMap = new Map(25, 25);
            CurrentFloor++;

            // place the player at the entrance
            // continue playing
        }

        public static Game GetInstance()
        {
            return Game.Instance;
        }

        public void RunCombat(Actor player, Actor enemy)
        {
            bool isInCombat = true;

            while (isInCombat)
            {
                Console.WriteLine("What would you like to do: (a)ttack, (r)un?");

                ConsoleKeyInfo keypress;

                keypress = Console.ReadKey(true);

                if (keypress.Key == ConsoleKey.A)
                {
                    player.MakeAttack(enemy);
                }
                else if (keypress.Key == ConsoleKey.R)
                {
                    // end combat and run away, end the loop early
                    Console.WriteLine($"{player.Name} attempts to run away.");
                    isInCombat = false;
                    // TODO: add code to move the player somewhere nearby
                    break;
                }

                // enemy counter attack
                enemy.MakeAttack(player);

                // check for victory conditions
                if (player.IsDead())
                {
                    // exit combat (game over)
                    isInCombat = false;
                }
                else if (enemy.IsDead())
                {
                    // exit combat, give the player a cookie
                    isInCombat = false;
                }
            }
        }
    }
}
