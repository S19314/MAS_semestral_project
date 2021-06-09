using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.Models
{
    public partial class LanguageEmployee
    {
        public int KnowedLanguageIdLanguage { get; set; }
        public int OsobaIdOsoba { get; set; }

        public virtual KnowedLanguage KnowedLanguageIdLanguageNavigation { get; set; }
        public virtual Osoba OsobaIdOsobaNavigation { get; set; }
    }
}
