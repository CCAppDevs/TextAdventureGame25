using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Map
    {
        public List<List<IRoom>> Rooms { get; set; }
        public int SizeX { get; }
        public int SizeY { get; }

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
                    int roomType = rnd.Next(0, 2);

                    // TODO: Weight which type of room spawns
                    IRoom spawnedRoom;

                    if (roomType == 0)
                    {
                        spawnedRoom = new RoomEntrance();
                    }
                    else if (roomType == 1)
                    {
                        spawnedRoom = new RoomEmpty();
                    }
                    else
                    {
                        spawnedRoom = new RoomEmpty();
                    }

                    // put that in position x,y of the map
                    Rooms[y].Add(spawnedRoom);
                }
            }
        }

        public void PrintMap()
        {
            for (int y = 0; y < Rooms.Count; y++)
            {
                for (int x = 0; x < Rooms[y].Count; x++)
                {
                    if (Rooms[y][x] == 0)
                    {
                        Console.Write("[ ]");
                    } else
                    {
                        Console.Write($"[{Rooms[y][x]}]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
