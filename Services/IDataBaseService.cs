using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.DataBaseModels;

namespace MAS_semestral_project_MVS.Services
{
    public interface IDataBaseService
    {
        public ClassAttributesInColumn GetClassAttributesInColumn();
        public decimal? GetEmployeeMaxHourRateFromClassAttributesInColumn();
        public decimal? GetDirectorMaxHourRateFromClassAttributesInColumn();
        public decimal? GetCleanerMaxHourRateFromClassAttributesInColumn();
        public decimal? GetReceptionistMaxHourRateFromClassAttributesInColumn();
        public decimal? GetCleanerReceptionistMaxHourRateFromClassAttributesInColumn();
        public decimal? GetCleanerMaxToolsQuantityFromClassAttributesInColumn();
    }
}
