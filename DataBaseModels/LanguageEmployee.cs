using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class LanguageEmployee
    {
        public int KnowedLanguageIdLanguage { get; set; }
        public int OsobaIdOsoba { get; set; }

        public virtual KnowedLanguage KnowedLanguageIdLanguageNavigation { get; set; }
        public virtual Person OsobaIdOsobaNavigation { get; set; }

        public string ToString() 
        {
            return "KnowedLanguageIdLanguage: " + KnowedLanguageIdLanguage;
        }

        public static string ListToString(ICollection<LanguageEmployee> languageEployees)
        {
            var languagesToString = "";
            foreach (var l in languageEployees)
            {
                languagesToString += l.ToString() + "\n";
            }

            return languagesToString;
        }
    }
}
