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
        public string relationWithCompany;
        public string RelationWithCompany
        {
            get { return relationWithCompany; }
            set
            {
                if (!RelationWithCompanyEnum.Contains(value))
                {
                    throw new Exception("U  nsupported RealtionWithCompany.");
                }
                relationWithCompany = value;
            }
        }
        public string employeeType;

        public string EmployeeType
        {
            get
            {
                if (!IsEmployee())
                {
                    throw new Exception("This type of object have no permission for access EmployeeType property.");
                }
                return employeeType;
            }  // Добваить ограниечение: мол если ты не работник, то доступ не имеешь.
            set
            {
                if (!IsEmployee())
                {
                    throw new Exception("This type of object have no permission for access EmployeeType property.");
                }
                if (!EmployeeExperienceTypeEnum.Contains(employeeType))
                {
                    throw new Exception("Unsupported EmployeeType.");
                }
                employeeType = value;
            }
        }
        public string employeeExperienceType;

        public string EmployeeExperienceType
        {
            get {
                if (!IsEmployee())
                {
                    throw new Exception("This type of object have no permission for access EmployeeType property.");
                }
                return employeeType;
            }
            set
            {
                if (!IsEmployee())
                {
                    throw new Exception("This type of object have no permission for access EmployeeType property.");
                }
                if (!EmployeeExperienceTypeEnum.Contains(employeeType))
                {
                    throw new Exception("Unsupported EmployeeType.");
                }
                employeeExperienceType = value;
            }
        }
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
                if (IsEmployee())
                {
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Cleaner)))
                    {
                        return (decimal)DataBaseService.GetCleanerMaxHourRateFromClassAttributesInColumn();
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Cleaner_Receptionist)))
                    {
                        return (decimal)DataBaseService.GetCleanerReceptionistMaxHourRateFromClassAttributesInColumn();
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Director)))
                    {
                        return (decimal)DataBaseService.GetDirectorMaxHourRateFromClassAttributesInColumn();
                    }
                    if (EmployeeType.Equals(EmployeeTypeEnum.GetConformityEnumValue(EmployeeTypeEnum.EmployeeType.Receptionist)))
                    {
                        return (decimal)DataBaseService.GetReceptionistMaxHourRateFromClassAttributesInColumn();
                    }
                }
                throw new Exception("This object doesn't have permission for MaxHourRate property.");
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
            get { return (int)DataBaseService.GetCleanerMaxToolsQuantityFromClassAttributesInColumn(); }
            set { DataBaseService.SetCleanerMaxToolsQuantityFromClassAttributesInColumn(value); }
        }
        public static int EpmloyeeMaxPlaceWorkQuantity
        {
            get { return (int)DataBaseService.GetEpmloyeeMaxPlaceWorkQuantity(); }
            set { DataBaseService.SetEpmloyeeMaxPlaceWorkQuantity(value); }
        }
        public static int ReceptionistMaxKnowedLanguages
        {
            get { return (int)DataBaseService.GetReceptionistMaxKnowedLanguages(); }
            set { DataBaseService.SetReceptionistMaxKnowedLanguages(value); }
        }
        public static int ReceptionistMinKnowedLanguages
        {
            get { return (int)DataBaseService.GetReceptionistMinKnowedLanguages(); }
            set { DataBaseService.SetReceptionistMinKnowedLanguages(value); }
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
        public void SetRelationWithCompanyAsClient_Employee()
        {
            this.RelationWithCompany = RelationWithCompanyEnum.GetConformityEnumValue(
                RelationWithCompanyEnum.RelationWithCompany.Client_Employee
                );
        }
        public void SetEmployeeTypeAsDirector()
        {
            this.EmployeeType = EmployeeTypeEnum.GetConformityEnumValue(
                EmployeeTypeEnum.EmployeeType.Director
                );
        }

        public void SetEmployeeTypeAsCleaner()
        {
            this.EmployeeType = EmployeeTypeEnum.GetConformityEnumValue(
                EmployeeTypeEnum.EmployeeType.Cleaner
                );
        }

        public void SetEmployeeTypeAsReceptionist()
        {
            this.EmployeeType = EmployeeTypeEnum.GetConformityEnumValue(
                EmployeeTypeEnum.EmployeeType.Receptionist
                );
        }

        public void SetEmployeeTypeAsCleaner_Receptionist()
        {
            this.EmployeeType = EmployeeTypeEnum.GetConformityEnumValue(
                EmployeeTypeEnum.EmployeeType.Cleaner_Receptionist
                );
        }
        public void SetEmployeeExperienceTypeAsCleaner_Apprentice()
        {
            this.EmployeeType = EmployeeExperienceTypeEnum.GetConformityEnumValue(
                    EmployeeExperienceTypeEnum.EmployeeExperienceType.Apprentice
                );
        }
        public void SetEmployeeExperienceTypeAsCleaner_Experienced()
        {
            this.EmployeeType = EmployeeExperienceTypeEnum.GetConformityEnumValue(
                    EmployeeExperienceTypeEnum.EmployeeExperienceType.Experienced
                );
        }


        public void DefineEmployeeExperienceType()
        {
            if (InternshipDaysInCurentHotel > 182)
            {
                SetEmployeeExperienceTypeAsCleaner_Experienced();
            }
            else
            {
                SetEmployeeExperienceTypeAsCleaner_Apprentice();
            }
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
            client.SetRelationWithCompanyAsClient();
            client.PassportData = passportData;
            client.PhoneNumber = phoneNumber;
            return client;
        }
        
        

        /// TO DO: ДОбавить: 1. статические поля; 2. Как статическое поле сделать ограничение количества последних мест работы.

        /// <summary>
        ///  Move definition HorRate from CreatingEmployee to creating specefic EmployeeType, because - MaxHourRate depenends of EmployeeType. MaxHourRate influence on Hour Rate.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="internshipDaysInCurentHotel"></param>
        /// <param name="hourRate"></param>
        /// <param name="lastDateChangeRate"></param>
        /// <param name="placeWorks"></param>
        /// <returns></returns>
        private static Person CreateEmployee(string firstName, string secondName, int internshipDaysInCurentHotel, DateTime lastDateChangeRate, PlaceWork[] placeWorks)
        {
            var employee = CreatePerson(firstName, secondName);
            employee.SetRelationWithCompanyAsEmployee();
            employee.InternshipDaysInCurentHotel = internshipDaysInCurentHotel;
            employee.LastDateChangeRate = lastDateChangeRate;
            employee.DefineEmployeeExperienceType();
            if (placeWorks.Length + employee.PlaceWorks.Count > Person.EpmloyeeMaxPlaceWorkQuantity)
            {
                throw new Exception("Employee can't have more than " + Person.EpmloyeeMaxPlaceWorkQuantity + "; You should remove some PlaceWork before additing new.");
            }
            for (int i = 0; i < placeWorks.Length; i++) {
                employee.PlaceWorks.Add(placeWorks[i]);
            }
            return employee;
        }
        private static Person ConfigurationDirectorDuringCreation(Person director, decimal hourRate)
        {
            director.SetEmployeeTypeAsDirector();
            director.HourRate = hourRate;
            return director;
        }
        public static Person CreateDirector(string firstName, string secondName, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks)
        {
            var director = CreateEmployee(firstName, secondName, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            director = Person.ConfigurationDirectorDuringCreation(director, hourRate);
            return director;
        }
        public static Person CreateDirector_Client(string firstName, string secondName, string passportData, string phoneNumber, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks)
        {
            var director = CreateEmployee_Client(firstName, secondName, passportData, phoneNumber, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            director = Person.ConfigurationDirectorDuringCreation(director, hourRate);
            return director;
        }

        private static Person ConfigurationCleanerDuringCreation(Person cleaner, decimal hourRate, CleaningTool[] cleaningTools)
        {
            cleaner.SetEmployeeTypeAsCleaner();
            cleaner.HourRate = hourRate;

            if (cleaningTools.Length + cleaner.CleaningTools.Count > Person.CleanerMaxToolsQuantity)
            {
                throw new Exception("Employee can't have more than " + Person.CleanerMaxToolsQuantity + "; You should remove some CleaningTools before additing new.");
            }
            for (int i = 0; i < cleaningTools.Length; i++)
            {
                cleaner.CleaningTools.Add(cleaningTools[i]);
            }
            return cleaner;
        }
        public static Person CreateCleaner(string firstName, string secondName, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks, CleaningTool[] cleaningTools)
        {
            var cleaner = CreateEmployee(firstName, secondName, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            cleaner = ConfigurationCleanerDuringCreation(cleaner, hourRate, cleaningTools);
            return cleaner;
        }

        public static Person CreateCleaner_Client(string firstName, string secondName, string passportData, string phoneNumber,  int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks, CleaningTool[] cleaningTools)
        {
            var cleaner = CreateEmployee_Client(firstName, secondName, passportData, phoneNumber, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            cleaner = ConfigurationCleanerDuringCreation(cleaner, hourRate, cleaningTools);
            return cleaner;
        }

        public void AddConnectionBetweenPersonAndKnowedLanguage(KnowedLanguage knowedLanguage){
            if (knowedLanguage.Equals(null)) 
            {
                throw new Exception("Can't be added KnowedLanguage as null.");
            }
            var languageEmployee = new LanguageEmployee
            {
                KnowedLanguageIdLanguage = knowedLanguage.IdLanguage,
                KnowedLanguageIdLanguageNavigation = knowedLanguage,
                OsobaIdOsoba = this.IdOsoba,
                OsobaIdOsobaNavigation = this
            };
            this.LanguageEmployees.Add(languageEmployee);
        }

        
        private static Person ConfigurationReceptionistDuringCreation(Person receptionist, decimal hourRate, KnowedLanguage[] knowedLanguages, string workShift) 
        {
            receptionist.SetEmployeeTypeAsReceptionist();
            receptionist.HourRate = hourRate;
            if (knowedLanguages.Length + receptionist.LanguageEmployees.Count > Person.ReceptionistMaxKnowedLanguages)
            {
                throw new Exception("Employee can't have more than " + Person.ReceptionistMaxKnowedLanguages + "; You should remove some CleaningTools before additing new.");
            }
            for (int i = 0; i < knowedLanguages.Length; i++)
            {
                receptionist.AddConnectionBetweenPersonAndKnowedLanguage(knowedLanguages[i]);
            }
            receptionist.WorkShift = workShift;
            return receptionist;
        }
        public static Person CreateReceptionist(string firstName, string secondName, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks, KnowedLanguage[] knowedLanguages, string workShift)
        {
            var receptionist = CreateEmployee(firstName, secondName, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            receptionist = ConfigurationReceptionistDuringCreation(receptionist, hourRate, knowedLanguages, workShift);
            return receptionist;
        }
        private static Person ConfigurationReceptionist_CleanerDuringCreation(Person receptionist_cleaner, decimal hourRate, KnowedLanguage[] knowedLanguages, string workShift, CleaningTool[] cleaningTools)
        {
            receptionist_cleaner.SetEmployeeTypeAsCleaner_Receptionist();
            receptionist_cleaner.HourRate = hourRate;
            if (knowedLanguages.Length + receptionist_cleaner.LanguageEmployees.Count > Person.ReceptionistMaxKnowedLanguages)
            {
                throw new Exception("Employee can't have more than " + Person.ReceptionistMaxKnowedLanguages + "; You should remove some CleaningTools before additing new.");
            }
            for (int i = 0; i < knowedLanguages.Length; i++)
            {
                receptionist_cleaner.AddConnectionBetweenPersonAndKnowedLanguage(knowedLanguages[i]);
            }
            receptionist_cleaner.WorkShift = workShift;
            if (cleaningTools.Length + receptionist_cleaner.CleaningTools.Count > Person.CleanerMaxToolsQuantity)
            {
                throw new Exception("Employee can't have more than " + Person.CleanerMaxToolsQuantity + "; You should remove some CleaningTools before additing new.");
            }
            for (int i = 0; i < cleaningTools.Length; i++)
            {
                receptionist_cleaner.CleaningTools.Add(cleaningTools[i]);
            }

            return receptionist_cleaner;
        }

        public static Person CreateReceptionist_Cleaner(string firstName, string secondName, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks, KnowedLanguage[] knowedLanguages, string workShift, CleaningTool[] cleaningTools)
        {
            var receptionist = CreateEmployee(firstName, secondName, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            receptionist = ConfigurationReceptionist_CleanerDuringCreation(receptionist, hourRate, knowedLanguages, workShift, cleaningTools);
            return receptionist;
        }
        public static Person CreateReceptionist_Cleaner_Client(string firstName, string secondName, string passportData, string phoneNumber, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks, KnowedLanguage[] knowedLanguages, string workShift, CleaningTool[] cleaningTools)
        {
            var receptionist = CreateEmployee_Client(firstName, secondName, passportData, phoneNumber, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            receptionist = ConfigurationReceptionist_CleanerDuringCreation(receptionist, hourRate, knowedLanguages, workShift, cleaningTools);
            return receptionist;
        }
        public static Person CreateReceptionist_Client(string firstName, string secondName, string passportData, string phoneNumber, int internshipDaysInCurentHotel, decimal hourRate, DateTime lastDateChangeRate, PlaceWork[] placeWorks, KnowedLanguage[] knowedLanguages, string workShift)
        {
            var receptionist_client = CreateEmployee_Client(firstName, secondName, passportData, phoneNumber, internshipDaysInCurentHotel, lastDateChangeRate,  placeWorks);
            receptionist_client = ConfigurationReceptionistDuringCreation(receptionist_client, hourRate, knowedLanguages, workShift);
            return receptionist_client;
        }

        private static Person CreateEmployee_Client(string firstName, string secondName, string passportData, string phoneNumber, int internshipDaysInCurentHotel, DateTime lastDateChangeRate, PlaceWork[] placeWorks)
        {
            var employee = Person.CreateEmployee(firstName, secondName, internshipDaysInCurentHotel, lastDateChangeRate, placeWorks);
            employee.SetRelationWithCompanyAsClient_Employee();
            employee.PassportData = passportData;
            employee.PhoneNumber = phoneNumber;
            return employee;
        }
    }
}
