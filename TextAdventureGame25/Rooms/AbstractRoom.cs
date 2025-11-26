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
        
        protected AbstractRoom(char symbol)
        {
            RoomSymbol = symbol;
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
