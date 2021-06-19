using System;
using System.Collections.Generic;
#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class WebPage
    {
        public WebPage()
        {
            ConnectionItemPages = new HashSet<ConnectionItemPage>();
        }

        public int IdWebPage { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConnectionItemPage> ConnectionItemPages { get; set; }
    }
}
