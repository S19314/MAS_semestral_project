using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.DataBaseModels;

namespace MAS_semestral_project_MVS.Services
{
    public class MSSQLService : IDataBbaseService
    {

        public MAS_semestralContext dbContext { get; set; }
        public MSSQLService(MAS_semestralContext context)
        {
            dbContext = context;
        }

        public ClassAttributesInColumn GetClassAttributesInColumn()
        {
            return dbContext.ClassAttributesInColumns.First();
        }

        public decimal? GetEmployeeMaxHourRateFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.EmployeeMaxHourRate).First();            
        }
        
        public decimal? GetDirectorMaxHourRateFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.DirectorMaxHourRate).First();            
        }
        
        public decimal? GetCleanerMaxHourRateFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.CleanerMaxHourRate).First();            
        }
        
        public decimal? GetReceptionistMaxHourRateFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.ReceptionistMaxHourRate).First();            
        }
        
        public decimal? GetCleanerReceptionistMaxHourRateFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.CleanerReceptionistMaxHourRate).First();            
        }
        
        public decimal? GetCleanerMaxToolsQuantityFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.CleanerMaxToolsQuantity).First();            
        }
    }
}
