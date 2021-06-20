﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class CustomerConversationModelView
    {
        public int ClientIdOsoba { get; set; }
        public int EmployeeIdOsoba { get; set; }
        public int MarkServiceQuality { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int ConversationDurationInSeconds { get; set; }

        public virtual Person ClientIdOsobaNavigation { get; set; }
        public virtual Person EmployeeIdOsobaNavigation { get; set; }
    }
}
