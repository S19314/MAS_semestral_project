using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class LastCleanedRoom
    {
        public int IdLastCleanedRoom { get; set; }
        public DateTime DurationCleanedTime { get; set; }
        public int CleaningGroupIdGroup { get; set; }
        public int RoomIdRoom { get; set; }

        public virtual CleaningGroup CleaningGroupIdGroupNavigation { get; set; }
        public virtual Room RoomIdRoomNavigation { get; set; }
    }
}
