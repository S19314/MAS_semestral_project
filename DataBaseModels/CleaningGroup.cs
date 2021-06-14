using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class CleaningGroup
    {
        public CleaningGroup()
        {
            LastCleanedRooms = new HashSet<LastCleanedRoom>();
            People = new HashSet<Person>();
        }

        public int IdAttribute { get; set; }
        public int IdGroup { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime EndWorkTime { get; set; }

        public virtual ICollection<LastCleanedRoom> LastCleanedRooms { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
