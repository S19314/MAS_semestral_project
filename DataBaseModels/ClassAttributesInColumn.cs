using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class ClassAttributesInColumn
    {
        public int Id { get; set; }
        public decimal? EmployeeMaxHourRate { get; set; }
        public decimal? DirectorMaxHourRate { get; set; }
        public decimal? CleanerMaxHourRate { get; set; }
        public decimal? ReceptionistMaxHourRate { get; set; }
        public decimal? CleanerReceptionistMaxHourRate { get; set; }
        public int? CleanerMaxToolsQuantity { get; set; }
        public int? EpmloyeeMaxPlaceWorkQuantity { get; set; }
        public int? ReceptionistMaxKnowedLanguages { get; set; }
        public int? ReceptionistMinKnowedLanguages { get; set; }

    }
}
