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
        public int? GetCleanerMaxToolsQuantityFromClassAttributesInColumn();
        public int? GetEpmloyeeMaxPlaceWorkQuantity();
        public int? GetReceptionistMaxKnowedLanguages();
        public int? GetReceptionistMinKnowedLanguages();

        public void SetEmployeeMaxHourRateFromClassAttributesInColumn(decimal maxHourRate);
        public void SetDirectorMaxHourRateFromClassAttributesInColumn(decimal maxHourRate);
        public void SetCleanerMaxHourRateFromClassAttributesInColumn(decimal maxHourRate);
        public void SetReceptionistMaxHourRateFromClassAttributesInColumn(decimal maxHourRate);
        public void SetCleanerReceptionistMaxHourRateFromClassAttributesInColumn(decimal maxHourRate);
        public void SetCleanerMaxToolsQuantityFromClassAttributesInColumn(int maxToolQuantity);
        public void SetEpmloyeeMaxPlaceWorkQuantity(int maxPlaceWorkQuantity);
        public void SetReceptionistMaxKnowedLanguages(int maxKnowedLanguages);
        public void SetReceptionistMinKnowedLanguages(int minKnowedLanguages);
    }
}
