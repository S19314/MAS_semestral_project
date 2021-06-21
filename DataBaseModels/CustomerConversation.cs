using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class CustomerConversation
    {
        public int IdCustomerConversation { get; set; }
        public int ClientIdOsoba { get; set; }
        public int EmployeIdOsoba { get; set; }
        public int MarkServiceQuality { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int ConversationDurationInSeconds { get; set; }

        public virtual Person ClientIdOsobaNavigation { get; set; }
        public virtual Person EmployeIdOsobaNavigation { get; set; }

        public static IEnumerable<Person> GetClients(IEnumerable<CustomerConversation> customerConversations) 
        {
            var clients = new List<Person>();
            foreach (var converation in customerConversations)
            {
                var person = converation.ClientIdOsobaNavigation;
                /*
                if (person.IsClient()) 
                {
                */
                    clients.Add(person);
                // }
            }
            return clients;
        }
        public static IEnumerable<Person> GetReceptionists(IEnumerable<CustomerConversation> customerConversations) 
        {
            var receptionists = new List<Person>();
            foreach (var converation in customerConversations)
            {
                var person = converation.EmployeIdOsobaNavigation;
                if (person.IsEmployee() && person.IsReceptionist()) 
                {
                    receptionists.Add(person);
                }
            }
            return receptionists;
        }
    }
}
