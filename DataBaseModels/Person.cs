using System;
using System.Collections.Generic;
using MAS_semestral_project_MVS.Models.Enums;
#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class Person
    {
        public Person()
        {
            CleaningTools = new HashSet<CleaningTool>();
            CustomerConversationClientIdOsobaNavigations = new HashSet<CustomerConversation>();
            CustomerConversationEmployeeIdOsobaNavigations = new HashSet<CustomerConversation>();
            LanguageEmployees = new HashSet<LanguageEmployee>();
            OrderOsoba2IdOsobaNavigations = new HashSet<Order>();
            OrderOsobaIdOsobaNavigations = new HashSet<Order>();
            PlaceWorks = new HashSet<PlaceWork>();
        }

        public int IdOsoba { get; set; }
        public string RelationWithCompany { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeExperienceType { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PassportData { get; set; }
        public string PhoneNumber { get; set; }
        public int? InternshipDaysInCurentHotel { get; set; }
        public decimal? HourRate { get; set; }
        public DateTime? LastDateChangeRate { get; set; }
        public string WorkShift { get; set; }
        public int? CleaningGroupIdGroup { get; set; }
        // TO DO 
        // add in DB
        private static decimal maxHourRateDirector; 
        private static decimal maxHourRateCleaner; 
        private static decimal maxHourRateReceptionist; 
        private static decimal maxHourRateCleaner_Receptionist;
        private static HashSet<decimal> maxHourRates = new HashSet<decimal>(); // ?
        public decimal MaxHourRate 
        {
            get 
            {
                return maxHourRateCleaner;   // Заглушка     
            }
            set 
            {
                maxHourRateCleaner = value; // Заглушка
            }
        }

        public virtual CleaningGroup CleaningGroupIdGroupNavigation { get; set; }
        public virtual ICollection<CleaningTool> CleaningTools { get; set; }
        public virtual ICollection<CustomerConversation> CustomerConversationClientIdOsobaNavigations { get; set; }
        public virtual ICollection<CustomerConversation> CustomerConversationEmployeeIdOsobaNavigations { get; set; }
        public virtual ICollection<LanguageEmployee> LanguageEmployees { get; set; }
        public virtual ICollection<Order> OrderOsoba2IdOsobaNavigations { get; set; }
        public virtual ICollection<Order> OrderOsobaIdOsobaNavigations { get; set; }
        public virtual ICollection<PlaceWork> PlaceWorks { get; set; }

        private static Person CreatePerson(string firstName, string secondName)
        {
            return new Person { 
                FirstName = firstName,
                SecondName = secondName
            };
        }
        public static Person CreateClient(string firstName, string secondName, string passportData, string phoneNumber) 
        {
            var client = CreatePerson(firstName, secondName);
            client.RelationWithCompany = RelationWithCompanyEnum.GetConformityEnumValue(
                RelationWithCompanyEnum.RelationWithCompany.Client
                );
            client.PassportData = passportData;
            client.PhoneNumber = phoneNumber;
            return client;
        }
        /// TO DO: ДОбавить: 1. статические поля; 2. Как статическое поле сделать ограничение количества последних мест работы.
        
        /// <summary>
        ///  
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="internshipDaysInCurentHotel"></param>
        /// <param name="hourRate"></param>
        /// <param name="lastDateChangeRate"></param>
        /// <param name="placeWorks"></param>
        /// <returns></returns>
        private static Person CreateEmployee(string firstName, string secondName, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks ) 
        {
            var employee = CreatePerson(firstName, secondName);
            employee.RelationWithCompany = RelationWithCompanyEnum.GetConformityEnumValue(
                RelationWithCompanyEnum.RelationWithCompany.Employee
                );
            employee.InternshipDaysInCurentHotel = internshipDaysInCurentHotel;
            employee.HourRate = hourRate;
            employee.LastDateChangeRate = lastDateChangeRate;
            throw new NotImplementedException("1.set placeWorks; 2. Set EmployeeType(create own \"Construct\"")
            // employee.
            return employee;
        }

        public static Person CreatePracownik_Client (string firstName, string secondName, string passportData, string phoneNumber)
        {
            throw new NotImplementedException("        public static Person CreatePracownik_Client (string firstName, string secondName, string passportData, string phoneNumber)");
            var client = CreatePerson(firstName, secondName);
            client.RelationWithCompany = RelationWithCompanyEnum.GetConformityEnumValue(
                RelationWithCompanyEnum.RelationWithCompany.Client
                );
            client.PassportData = passportData;
            client.PhoneNumber = phoneNumber;
            return client;
        }

    }
}
