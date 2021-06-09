using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            CleaningTools = new HashSet<CleaningTool>();
            CustomerConversationClientIdOsobaNavigations = new HashSet<CustomerConversation>();
            CustomerConversationEmployeeIdOsobaNavigations = new HashSet<CustomerConversation>();
            LanguageEmployees = new HashSet<LanguageEmployee>();
            OrderOsoba2IdOsobaNavigations = new HashSet<Order>();
            OrderOsobaIdOsobaNavigations = new HashSet<Order>();
        }

        public int IdOsoba { get; set; }
        public string EmployeeType { get; set; }
        public string RelationWithCompany { get; set; }
        public string EmployeeExperienceType { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PassportData { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstLastPlaceWork { get; set; }
        public string SecondLastPlaceWork { get; set; }
        public string ThirdLastPlaceWork { get; set; }
        public int InternshipDaysInCurentHotel { get; set; }
        public decimal HourRate { get; set; }
        public decimal MaxRate { get; set; }
        public DateTime LastDateChangeRate { get; set; }
        public string WorkShift { get; set; }
        public int CleaningGroupIdGroup { get; set; }

        public virtual CleaningGroup CleaningGroupIdGroupNavigation { get; set; }
        public virtual ICollection<CleaningTool> CleaningTools { get; set; }
        public virtual ICollection<CustomerConversation> CustomerConversationClientIdOsobaNavigations { get; set; }
        public virtual ICollection<CustomerConversation> CustomerConversationEmployeeIdOsobaNavigations { get; set; }
        public virtual ICollection<LanguageEmployee> LanguageEmployees { get; set; }
        public virtual ICollection<Order> OrderOsoba2IdOsobaNavigations { get; set; }
        public virtual ICollection<Order> OrderOsobaIdOsobaNavigations { get; set; }
    }
}
