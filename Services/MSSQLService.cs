using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace MAS_semestral_project_MVS.Services
{
    public class MSSQLService : IDataBaseService
    {

        public MAS_semestralContext dbContext { get; set; }
        public MSSQLService(MAS_semestralContext context)
        {
            dbContext = context;
            dbContext.SetServiceInEntities(this);
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
        
        public int? GetCleanerMaxToolsQuantityFromClassAttributesInColumn() 
        {
            return dbContext.ClassAttributesInColumns.Select(e => e.CleanerMaxToolsQuantity).First();            
        }

        public void SetEmployeeMaxHourRateFromClassAttributesInColumn(decimal maxHourRate) 
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.EmployeeMaxHourRate = maxHourRate;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetDirectorMaxHourRateFromClassAttributesInColumn(decimal maxHourRate)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.DirectorMaxHourRate = maxHourRate;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetCleanerMaxHourRateFromClassAttributesInColumn(decimal maxHourRate)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.CleanerMaxHourRate = maxHourRate;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetReceptionistMaxHourRateFromClassAttributesInColumn(decimal maxHourRate)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.ReceptionistMaxHourRate = maxHourRate;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetCleanerReceptionistMaxHourRateFromClassAttributesInColumn(decimal maxHourRate)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.CleanerReceptionistMaxHourRate = maxHourRate;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetCleanerMaxToolsQuantityFromClassAttributesInColumn(int maxToolQuantity)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.CleanerMaxToolsQuantity = maxToolQuantity;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void SetEpmloyeeMaxPlaceWorkQuantity(int maxPlaceWorkQuantity) 
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.EpmloyeeMaxPlaceWorkQuantity = maxPlaceWorkQuantity;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetReceptionistMaxKnowedLanguages(int maxKnowedLanguages)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.ReceptionistMaxKnowedLanguages = maxKnowedLanguages;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void SetReceptionistMinKnowedLanguages(int minKnowedLanguages)
        {
            var staticValues = GetClassAttributesInColumn();
            staticValues.ReceptionistMinKnowedLanguages = minKnowedLanguages;
            /// Information about update for other future Contexts.
            dbContext.Entry(staticValues).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
