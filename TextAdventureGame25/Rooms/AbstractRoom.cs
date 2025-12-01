using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public abstract class AbstractRoom : IRoom
    {
        private char RoomSymbol { get; }
        public ConsoleColor RoomColor { get; set; }
        
        protected AbstractRoom(char symbol, ConsoleColor color = ConsoleColor.White)
        {
            RoomSymbol = symbol;
            RoomColor = color;
        }



        public abstract void OnEnter();
        public abstract void OnInteract();
        public abstract void OnLeave();
        public abstract void ResetRoom();
        public virtual bool LookAtRoom(Actor searcher)
        {
            OnEnter();
            return true;
        }

        public char GetRoomSymbol()
        {
            return RoomSymbol;
        }
    }
}
