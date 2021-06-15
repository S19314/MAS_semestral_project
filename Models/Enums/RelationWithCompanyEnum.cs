using System;
using System.Collections.Generic;



namespace MAS_semestral_project_MVS.Models.Enums
{
    public class RelationWithCompanyEnum 
    {
        public enum RelationWithCompany
        {
            Client = 0,
            Employee = 1,
            Client_Employee = 2
        }
        private static string[] RelationInString = { "Client", "Employee", "Client_Employee" };
        public RelationWithCompanyEnum()
        {
        }

        public static string GetConformityEnumValue(RelationWithCompany enumValue)
        {
            // return  (string)RelationInString.GetValue(((int)enumValue));
            return RelationInString[(int)enumValue];
        }

    }
}
