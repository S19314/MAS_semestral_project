using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.Models
{
    public partial class Room
    {
        public Room()
        {
            LastCleanedRooms = new HashSet<LastCleanedRoom>();
            Offers = new HashSet<Offer>();
        }

        public int IdRoom { get; set; }
        public int SeatQuantity { get; set; }
        public string RoomDescription { get; set; }
        public string RoomType { get; set; }

        public virtual ICollection<LastCleanedRoom> LastCleanedRooms { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
