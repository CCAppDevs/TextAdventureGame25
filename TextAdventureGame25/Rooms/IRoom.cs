using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public interface IRoom
    {
        // property
        ConsoleColor RoomColor { get; set; }

        // method
        char GetRoomSymbol();
        void OnEnter();
        void OnInteract();
        void OnLeave();
        void ResetRoom();
        bool LookAtRoom(Actor searcher);
    }
}
