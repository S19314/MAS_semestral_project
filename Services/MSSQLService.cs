using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using MAS_semestral_project_MVS.Models.Enums;
using MAS_semestral_project_MVS.DataBaseModels;

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
        public int? GetEpmloyeeMaxPlaceWorkQuantity()
        {
            return dbContext.ClassAttributesInColumns.First().EpmloyeeMaxPlaceWorkQuantity.Value;
        }
        public int? GetReceptionistMaxKnowedLanguages()
        {
            return dbContext.ClassAttributesInColumns.First().ReceptionistMaxKnowedLanguages.Value;
        }
        public int? GetReceptionistMinKnowedLanguages()
        {
            return dbContext.ClassAttributesInColumns.First().ReceptionistMinKnowedLanguages.Value;
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
        private bool ValidationAddKnownLanguagePartPerson(Person person)
        {
            if (person.Equals(null))
            {
                throw new Exception("Person can't be null.");
            }
            if (!person.IsEmployee())
            {
                throw new Exception("Only Employee can add knowedLanguage");
            }
            if (person.LanguageEmployees.Count + 1 > Person.ReceptionistMaxKnowedLanguages)
            {
                throw new Exception("Employee can't have more than " + Person.ReceptionistMaxKnowedLanguages + " knowedLanguage.");
            }
            return true;
        }
        private bool ValidationAddKnownLanguagePartKnowedLanguage(KnowedLanguage knowedLanguage)
        {
            if (knowedLanguage.Equals(null))
            {
                throw new Exception("KnowedLanguage can't be null.");
            }
            return true;
        }
        private bool ValidationAddKnownLanguage(Person person, KnowedLanguage knowedLanguage)
        {
            var validated = ValidationAddKnownLanguagePartPerson(person) &&
                            ValidationAddKnownLanguagePartKnowedLanguage(knowedLanguage);
            return validated;
        }

        public void AddKnownLanguage(Person person, KnowedLanguage knowedLanguage)
        {
            ValidationAddKnownLanguage(person, knowedLanguage);
            var languageEmployee = new LanguageEmployee
            {
                KnowedLanguageIdLanguage = knowedLanguage.IdLanguage,
                KnowedLanguageIdLanguageNavigation = knowedLanguage,
                OsobaIdOsoba = person.IdOsoba,
                OsobaIdOsobaNavigation = person
            };
            dbContext.LanguageEmployees.Add(languageEmployee);
            dbContext.Entry(languageEmployee).State = EntityState.Added;
            dbContext.SaveChanges();
        }

        private bool ValidationRemoveKnownLanguagePartPerson(Person person)
        {
            if (person.Equals(null))
            {
                throw new Exception("Person can't be null.");
            }
            if (!person.IsEmployee())
            {
                throw new Exception("Only Employee can add knowedLanguage");
            }
            if (person.LanguageEmployees.Count - 1 < Person.ReceptionistMinKnowedLanguages)
            {
                throw new Exception("Employee can't have less than " + Person.ReceptionistMinKnowedLanguages + " knowedLanguage.");
            }
            return true;
        }
        private bool ValidationRemoveKnownLanguagePartKnowedLanguage(KnowedLanguage knowedLanguage)
        {
            if (knowedLanguage.Equals(null))
            {
                throw new Exception("KnowedLanguage can't be null.");
            }
            return true;
        }
        private bool ValidationAddKnownLanguagePartLanguageEmployee(LanguageEmployee languageEmployee)
        {
            if (languageEmployee.Equals(null))
            {
                throw new Exception("LanguageEmployee can't be null.");
            }
            return true;
        }

        private bool ValidationRemoveKnownLanguage(LanguageEmployee languageEmployee)
        {
            var person = languageEmployee.OsobaIdOsobaNavigation;
            var knowedLanguage = languageEmployee.KnowedLanguageIdLanguageNavigation;
            var validated = ValidationAddKnownLanguagePartPerson(person) &&
                            ValidationAddKnownLanguagePartKnowedLanguage(knowedLanguage) &&
                            ValidationAddKnownLanguagePartLanguageEmployee(languageEmployee)
                            ;
            return validated;
        }
        public void RemoveKnownLanguage(LanguageEmployee languageEmployee)
        {
            ValidationRemoveKnownLanguage(languageEmployee);
            dbContext.LanguageEmployees.Remove(languageEmployee);
            dbContext.Entry(languageEmployee).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public IEnumerable<Person> GetClients()
        {
            return dbContext.People
                .Where(e =>
                e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client)
                ||
                e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client_Employee)
                )
                .ToList<Person>();
        }

        public IEnumerable<Person> GetReceptionists()
        {
            return dbContext.People
                    .Where(e =>
                    e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Employee)
                    ||
                    e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client_Employee)
                    )
                    .ToList<Person>();
        }
        public IEnumerable<CustomerConversation> GetCustomerConversations()
        {
            return dbContext.CustomerConversations
                .ToList<CustomerConversation>();
        }
        public IEnumerable<Offer> GetOffers()
        {
            return dbContext.Offers
                .ToList<Offer>();
        }
        public IEnumerable<Order> GetOrders()
        {
            return dbContext.Orders
                .ToList<Order>();
        }

        public void AddCustomerConversation(CustomerConversation customerConversation)
        {
            dbContext.CustomerConversations.Add(customerConversation);
            dbContext.SaveChanges();
        }
        public Person GetPersonById(int id)
        {
            return dbContext.People.First(e => e.IdOsoba == id);
        }
        public int GetMaxIdCustomerConversation()
        {
            return dbContext.CustomerConversations.Max(e => e.IdCustomerConversation);
        }
        public IEnumerable<Person> GetClientsConnectedWithEmployeeByConversation()
        {
            return dbContext.People.Where(
                e => e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client)
                    ||
                e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client_Employee)
                     ).Include(c => c.CustomerConversationClientIdOsobaNavigations).ThenInclude(e => e.EmployeIdOsobaNavigation)
                     .ToList();
        }
        public IEnumerable<Person> GetEmployeesConnectedWithClientByConversation()
        {
            return dbContext.People.Where(
                e => e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Employee)
                    ||
                e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client_Employee)
                     ).Include(c => c.CustomerConversationEmployeeIdOsobaNavigations).ThenInclude(e => e.ClientIdOsobaNavigation)
                     .ToList();
            //     db.Courses.Include(c => c.Students).ToList();    
            // return dbContext.People.Include(c => c.CustomerConversationEmployeeIdOsobaNavigations).ThenInclude(e => e.IdCustomerConversation);
        }
        public IEnumerable<Person> GetEmployeeByIdWithConnectionWithClient(int id)
        {
            return dbContext.People.Where(e =>
               e.IdOsoba == id
               &&
               (
                   e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Employee)
                   ||
                   e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client_Employee)
               )
                ).Include(c => c.CustomerConversationEmployeeIdOsobaNavigations).ThenInclude(e => e.ClientIdOsobaNavigation)
                .ToList();
        }
        public IEnumerable<Person> GetClientByIdConnectionWithEmployee(int id)
        {
            return dbContext.People.Where(e =>
               e.IdOsoba == id
               &&
               (
                   e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client)
                   ||
                   e.RelationWithCompany == RelationWithCompanyEnum.GetConformityEnumValue(RelationWithCompanyEnum.RelationWithCompany.Client_Employee)
               )
                ).Include(c => c.CustomerConversationClientIdOsobaNavigations).ThenInclude(e => e.EmployeIdOsobaNavigation)
                .ToList();
        }

        public void AddClient(Person client)
        {
            client.IdOsoba = 1 + dbContext.People.Max(e => e.IdOsoba);
            dbContext.People.Add(client);
            dbContext.SaveChanges();
        }

        public void AddReceptionist(Person receptionist) 
        {
            receptionist.IdOsoba = 1 + dbContext.People.Max(e => e.IdOsoba);
            dbContext.People.Add(receptionist);
            dbContext.SaveChanges();
        }
        public void AddOffer(Offer offer) 
        {
            offer.Id= 1 + dbContext.Offers.Max(e => e.Id);
            offer.OfferStatus = "Available";
            dbContext.Offers.Add(offer);
            dbContext.SaveChanges();
        }
        public IEnumerable<Room> GetRooms() 
        {
            return dbContext.Rooms;
        }
        
        public void AddOrder(Order order)
        {
            order.IdOrder = 1 + dbContext.Orders.Max(e => e.IdOrder);
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}
