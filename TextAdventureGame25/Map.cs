using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame25.Rooms;

namespace TextAdventureGame25
{
    public class Map
    {
        public List<List<IRoom>> Rooms { get; set; }
        public int SizeX { get; }
        public int SizeY { get; }
        public int EntranceX { get; set; }
        public int EntranceY { get; set; }
        public int BossX { get; set; }
        public int BossY { get; set; }

        public Map(int sizeX, int sizeY)
        {
            Rooms = new List<List<IRoom>>();
            SizeX = sizeX;
            SizeY = sizeY;

            // fill the map with rooms randomly
            Random rnd = new Random();

            // loop over y
            // loop over x
            for (int y = 0; y < sizeY; y++)
            {
                // creates the empty row
                Rooms.Add(new List<IRoom>());

                // for each column in the current row
                for (int x = 0; x < sizeX; x++)
                {
                    // choose a random room type (0-4)
                    int roomType = rnd.Next(0, 100);

                    IRoom spawnedRoom;

                    if (roomType <= 10)
                    {
                        spawnedRoom = new RoomLoot('$', 100);
                    }
                    else if (roomType <= 50)
                    {
                        spawnedRoom = new RoomEmpty(' ');
                    }
                    else if (roomType <= 75)
                    {
                        if (roomType <= 60)
                        {
                            spawnedRoom = new RoomMonster('M', new Enemy("Goblin", 10, 2), ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            spawnedRoom = new RoomMonster('M', new Enemy("Slime", 5, 10), ConsoleColor.DarkGray);
                        }
                    }
                    else if (roomType <= 80)
                    {
                        spawnedRoom = new RoomPuzzle('P');
                    }
                    else
                    {
                        spawnedRoom = new RoomEmpty(' ');
                    }

                    // put that in position x,y of the map
                    Rooms[y].Add(spawnedRoom);
                }
            }

            // replace two rooms with enterance and boss room
            EntranceX = rnd.Next(0, Rooms[0].Count());
            EntranceY = rnd.Next(0, Rooms.Count());

            Rooms[EntranceY][EntranceX] = new RoomEntrance('E');

            BossX = rnd.Next(0, Rooms[0].Count());
            BossY = rnd.Next(0, Rooms.Count());

            Rooms[BossY][BossX] = new BossRoom('B', new Enemy("Goblin King", 50, 15));
        }

        public IRoom GetRoomAtPosition(int x, int y)
        {
            return Rooms[y][x];
        }
    }
}
