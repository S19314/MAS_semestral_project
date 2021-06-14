using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class PlaceWork
    {
        public int IdPlaceWork { get; set; }
        public string Name { get; set; }
        public int EmployeeIdPerson { get; set; }

        public virtual Person EmployeeIdPersonNavigation { get; set; }
    }
}
