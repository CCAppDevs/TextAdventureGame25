using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public abstract class AbstractRoom : IRoom
    {
        private char RoomSymbol { get; }
        
        protected AbstractRoom(char symbol)
        {
            RoomSymbol = symbol;
        }

        public char GetRoomSymbol()
        {
            return RoomSymbol;
        }

        public abstract void OnEnter();
        public abstract void OnInteract();
        public abstract void OnLeave();
        public abstract void ResetRoom();
    }
}
