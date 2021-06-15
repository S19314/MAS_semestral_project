using System;
using System.Collections.Generic;



namespace MAS_semestral_project_MVS.Models.Enums
{
    public class RelationWithCompanyEnum 
    {
        public enum RelationWithCompany
        {
            Client = 0,
            Employee = 1
        }
        private readonly string[] RelationInString = { "Client", "Employee" };
        public RelationWithCompanyEnum()
        {
        }

        public string GetConformityEnumValue(RelationWithCompany enumValue)
        {
            // return  (string)RelationInString.GetValue(((int)enumValue));
            return RelationInString[(int)enumValue];
        }

    }
}
