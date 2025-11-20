using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public interface IRoom
    {
        char GetRoomSymbol();
        void OnEnter();
        void OnInteract();
        void OnLeave();
        void ResetRoom();
    }
}
