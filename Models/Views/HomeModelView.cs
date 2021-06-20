using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.DataBaseModels;

namespace MAS_semestral_project_MVS.Models.Views
{
    public class HomeModelView
    {
        public IEnumerable<Person> Clients { get; set; }
        public IEnumerable<Person> Receptionists { get; set; }
    }
}
