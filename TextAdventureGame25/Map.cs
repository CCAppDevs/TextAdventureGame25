using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Map
    {
        public int[,] Rooms { get; set; }
        public int SizeX { get; }
        public int SizeY { get; }

        public Map(int sizeX, int sizeY)
        {
            Rooms = new int[sizeX, sizeY];
            SizeX = sizeX;
            SizeY = sizeY;

            // fill the map with rooms randomly
            Random rnd = new Random();

            // loop over y
            // loop over x
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    // choose a random room type (0-4)
                    int roomType = rnd.Next(0, 5);

                    // put that in position x,y of the map
                    Rooms[x, y] = roomType;
                }
            }
        }

        public void PrintMap()
        {
            for (int y = 0; y < Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Rooms.GetLength(0); x++)
                {
                    if (Rooms[x, y] == 0)
                    {
                        Console.Write("[ ]");
                    } else
                    {
                        Console.Write($"[{Rooms[x, y]}]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
