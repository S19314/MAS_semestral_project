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
        public static RelationWithCompany GetConformityEnumValue(string enumValue)
        {
            if (enumValue.Equals(RelationInString[0])) 
            {
                return RelationWithCompany.Client;
            }
            if (enumValue.Equals(RelationInString[1])) 
            {
                return RelationWithCompany.Employee;
            }
            if (enumValue.Equals(RelationInString[2])) 
            {
                return RelationWithCompany.Client_Employee;
            }

            throw new Exception("Enum doesn't exist that equals string: " + enumValue);
        }

        public static bool IsEmployee(string enumValue)
        { 
            if (RelationInString[1].Equals(enumValue) || RelationInString[2].Equals(enumValue))
            {
                return true;
            }  
            return false;
        }
        public static bool IsClient(string enumValue)
        {
            if (RelationInString[0].Equals(enumValue) || RelationInString[2].Equals(enumValue))
            {
                return true;
            }
            return false;
        }

        public static bool Contains(string enumName)
        {
            for (int i = 0; i < RelationInString.Length; i++)
            {
                if (RelationInString[i].Equals(enumName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
