using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public DateTime CreationDate { get; set; }
        public int OfferId { get; set; }
        public int OsobaIdOsoba { get; set; }
        public int Osoba2IdOsoba { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual Person Osoba2IdOsobaNavigation { get; set; }
        public virtual Person OsobaIdOsobaNavigation { get; set; }
    }
}
