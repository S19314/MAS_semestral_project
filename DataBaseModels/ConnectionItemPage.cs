using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class ConnectionItemPage
    {
        public int Order { get; set; }
        public int MenuBarItemIdMenuBarItem { get; set; }
        public int WebPageIdWebPage { get; set; }

        public virtual MenuBarItem MenuBarItemIdMenuBarItemNavigation { get; set; }
        public virtual WebPage WebPageIdWebPageNavigation { get; set; }
    }
}
