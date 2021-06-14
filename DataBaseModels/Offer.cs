using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class Offer
    {
        public Offer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string OfferStatus { get; set; }
        public decimal RoomPrice { get; set; }
        public DateTime AvailableTo { get; set; }
        public DateTime AvailableFrom { get; set; }
        public int RoomIdRoom { get; set; }

        public virtual Room RoomIdRoomNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
