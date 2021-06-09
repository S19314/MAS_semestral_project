using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.Models
{
    public partial class CleaningTool
    {
        public int IdTool { get; set; }
        public string Name { get; set; }
        public int OsobaIdOsoba { get; set; }

        public virtual Osoba OsobaIdOsobaNavigation { get; set; }
    }
}
