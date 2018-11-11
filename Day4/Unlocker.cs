using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    public class Unlocker
    {
        private readonly List<Room> _rooms;
        private readonly List<Room> _validRooms;

        public Unlocker(string[] input)
        {
            _rooms = new List<Room>();
            _validRooms = new List<Room>();

            foreach (var s in input)
            {
                _rooms.Add(new Room(s));
            }
        }

        public int GenerateSectorSum()
        { 
            var count = 0;
            foreach (var room in _rooms)
            {
                if (room.IsValid())
                {
                    _validRooms.Add(room);
                    count += room.GetSectorId();
                }
            }

            return count;
        }

        public void GetSectorIdOfRequiredRoom()
        {
            foreach (var validRoom in _validRooms)
            {
                if (validRoom.GetEncryptedName().Contains("north"))
                {
                    Console.WriteLine(validRoom.GetSectorId());
                    Console.WriteLine(validRoom.GetEncryptedName());
                }
            }
        }
    }
}