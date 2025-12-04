using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public abstract class AbstractRoom : IRoom
    {
        public Game GameInstance { get; }
        private char RoomSymbol { get; set; }
        public ConsoleColor RoomColor { get; set; }
        
        protected AbstractRoom(char symbol, ConsoleColor color = ConsoleColor.White)
        {
            RoomSymbol = symbol;
            RoomColor = color;
            GameInstance = Game.GetInstance();
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

        public void ChangeRoomSymbol(char roomSymbol)
        {
            RoomSymbol = roomSymbol;
        }
    }
}
