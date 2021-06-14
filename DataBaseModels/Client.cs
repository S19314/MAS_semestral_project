using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class Client  // : Person
    {
        public int IdOsoba { get; set; }
        public string RelationWithCompany { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PassportData { get; set; }
        public string PhoneNumber { get; set; }
    }
}
