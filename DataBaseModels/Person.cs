using System;
using System.Collections.Generic;
using MAS_semestral_project_MVS.Models.Enums;
using MAS_semestral_project_MVS.DataBaseModels;
using MAS_semestral_project_MVS.Services;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class Person
    {
        public static IDataBaseService DataBaseService { get; set; }
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
        private decimal? hourRate;
        public decimal? HourRate
        {
            get
            {
                return hourRate;
            }
            set
            {
                if (value > MaxHourRate)
                {
                    throw new Exception("New HourRate can't bigger than MaxHourRate.");
                }
                if (LastDateChangeRate.Value.Subtract(DateTime.Now).TotalDays < 30) 
                {
                    throw new Exception("HourRate can be changed only one in 30 days.");
                }
                hourRate = value;
            }
        }
        public DateTime? LastDateChangeRate { get; set; }
        public string WorkShift { get; set; }
        public int? CleaningGroupIdGroup { get; set; }
        /// <summary>
        /// Property that depends on type of Person.
        /// </summary>
        public decimal MaxHourRate
        {
            get 
            {
                if(IsEmployee())
                {
                    if(EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Cleaner))) 
                    {
                        return (decimal)DataBaseService.GetCleanerMaxHourRateFromClassAttributesInColumn();
                    }
                    if(EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Cleaner_Receptionist))) 
                    {
                        return (decimal)DataBaseService.GetCleanerReceptionistMaxHourRateFromClassAttributesInColumn();
                    }
                    if(EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Director))) 
                    {
                        return (decimal)DataBaseService.GetDirectorMaxHourRateFromClassAttributesInColumn();
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Receptionist)))
                    {
                        return (decimal)DataBaseService.GetReceptionistMaxHourRateFromClassAttributesInColumn();
                    }
                }
            throw new Exception("This object doesn't have permission for this property.");
            }
            /// <summary>
            /// Property that depends on type of Person.
            /// </summary>
            set
            {
                if (IsEmployee())
                {
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Cleaner)))
                    {
                        DataBaseService.SetCleanerMaxHourRateFromClassAttributesInColumn(value);
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Cleaner_Receptionist)))
                    {
                        DataBaseService.SetCleanerReceptionistMaxHourRateFromClassAttributesInColumn(value);
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Director)))
                    {
                        DataBaseService.SetDirectorMaxHourRateFromClassAttributesInColumn(value);
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Receptionist)))
                    {
                        DataBaseService.SetReceptionistMaxHourRateFromClassAttributesInColumn(value);
                    }
                }
                throw new Exception("This object doesn't have permission for this property.");
            }
        }
        
        
        public static int CleanerMaxToolsQuantity 
        {
            get { return (int)DataBaseService.GetCleanerMaxToolsQuantityFromClassAttributesInColumn();  }
            set { DataBaseService.SetCleanerMaxToolsQuantityFromClassAttributesInColumn(value);  }
        }
        public static int EpmloyeeMaxPlaceWorkQuantity
        {
            get { return (int)DataBaseService.GetEpmloyeeMaxPlaceWorkQuantity();  }
            set { DataBaseService.SetEpmloyeeMaxPlaceWorkQuantity(value);  }
        }
        public static int ReceptionistMaxKnowedLanguages
        {
            get { return (int)DataBaseService.GetReceptionistMaxKnowedLanguages();  }
            set { DataBaseService.SetReceptionistMaxKnowedLanguages(value);  }
        }
        public static int ReceptionistMinKnowedLanguages
        {
            get { return (int)DataBaseService.GetReceptionistMinKnowedLanguages();  }
            set { DataBaseService.SetReceptionistMinKnowedLanguages(value);  }
        }

        public virtual CleaningGroup CleaningGroupIdGroupNavigation { get; set; }
        public virtual ICollection<CleaningTool> CleaningTools { get; set; }
        public virtual ICollection<CustomerConversation> CustomerConversationClientIdOsobaNavigations { get; set; }
        public virtual ICollection<CustomerConversation> CustomerConversationEmployeeIdOsobaNavigations { get; set; }
        public virtual ICollection<LanguageEmployee> LanguageEmployees { get; set; }
        /// <summary>
        /// Association from Eployee side.
        /// </summary>
        public virtual ICollection<Order> OrderOsoba2IdOsobaNavigations { get; set; }
        /// <summary>
        /// Association from Client side.
        /// </summary>
        public virtual ICollection<Order> OrderOsobaIdOsobaNavigations { get; set; } 
        public virtual ICollection<PlaceWork> PlaceWorks { get; set; }

        public bool IsEmployee() 
        {
            return RelationWithCompanyEnum.IsEmployee(RelationWithCompany);
        }
        
        public bool IsClient() 
        {
            return RelationWithCompanyEnum.IsClient(RelationWithCompany);
        }
        public void SetRelationWithCompanyAsEmployee()
        {
            this.RelationWithCompany = RelationWithCompanyEnum.GetConformityEnumValue(
                RelationWithCompanyEnum.RelationWithCompany.Employee
                );
        }
        public void SetRelationWithCompanyAsClient()
        {
            this.RelationWithCompany = RelationWithCompanyEnum.GetConformityEnumValue(
                RelationWithCompanyEnum.RelationWithCompany.Client
                );
        }
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
            employee.SetRelationWithCompanyAsEmployee();
            employee.InternshipDaysInCurentHotel = internshipDaysInCurentHotel;
            employee.HourRate = hourRate;
            employee.LastDateChangeRate = lastDateChangeRate;
            if (placeWorks.Length + employee.PlaceWorks.Count > Person.EpmloyeeMaxPlaceWorkQuantity) 
            {
                throw new Exception("Employee can't have more than " + Person.EpmloyeeMaxPlaceWorkQuantity +"; You should remove some PlaceWork before additing new.");
            }
            for(int i = 0; i < placeWorks.Length; i++) { 
                employee.PlaceWorks.Add(placeWorks[i]);
            }
            return employee;
        }
        private static Person CreateDirector(string firstName, string secondName, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks)
        {
            
            var director = CreateEmployee(firstName, secondName, internshipDaysInCurentHotel, hourRate, lastDateChangeRate,  placeWorks);
            director.EmployeeType = EmployeeTypeEnum.EmployeeType.Director;
            director.InternshipDaysInCurentHotel = internshipDaysInCurentHotel;
            director.HourRate = hourRate;
            director.LastDateChangeRate = lastDateChangeRate;
            if (placeWorks.Length + director.PlaceWorks.Count > Person.EpmloyeeMaxPlaceWorkQuantity)
            {
                throw new Exception("Eployee can't have more than " + Person.EpmloyeeMaxPlaceWorkQuantity + "; You should remove some PlaceWork before additing new.");
            }
            for (int i = 0; i < placeWorks.Length; i++)
            {
                director.PlaceWorks.Add(placeWorks[i]);
            }
            return director;
            
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
