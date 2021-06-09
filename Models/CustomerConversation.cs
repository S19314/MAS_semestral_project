using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.Models
{
    public partial class CustomerConversation
    {
        public int ClientIdOsoba { get; set; }
        public int EmployeeIdOsoba { get; set; }
        public int MarkServiceQuality { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int ConversationDurationInSeconds { get; set; }

        public virtual Osoba ClientIdOsobaNavigation { get; set; }
        public virtual Osoba EmployeeIdOsobaNavigation { get; set; }
    }
}
