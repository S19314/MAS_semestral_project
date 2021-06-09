using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.Models
{
    public partial class CleaningGroup
    {
        public CleaningGroup()
        {
            LastCleanedRooms = new HashSet<LastCleanedRoom>();
            Osobas = new HashSet<Osoba>();
        }

        public int IdGroup { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime EndWorkTime { get; set; }

        public virtual ICollection<LastCleanedRoom> LastCleanedRooms { get; set; }
        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}
