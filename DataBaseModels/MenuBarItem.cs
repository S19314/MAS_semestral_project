using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class MenuBarItem
    {
        public MenuBarItem()
        {
            ConnectionItemPages = new HashSet<ConnectionItemPage>();
        }

        public int IdMenuBarItem { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConnectionItemPage> ConnectionItemPages { get; set; }
    }
}
