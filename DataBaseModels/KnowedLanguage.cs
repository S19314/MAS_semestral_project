using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class KnowedLanguage
    {
        public KnowedLanguage()
        {
            LanguageEmployees = new HashSet<LanguageEmployee>();
        }

        public int IdLanguage { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LanguageEmployee> LanguageEmployees { get; set; }
    }
}
