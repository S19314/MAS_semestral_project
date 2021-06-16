using System;
using System.Collections.Generic;


namespace MAS_semestral_project_MVS.Models.Enums
{
    public class EmployeeTypeEnum
    {
        public enum EmployeeType
        {
            Director = 0,
            Cleaner = 1,
            Receptionist = 2,
            Cleaner_Receptionist = 3
        }
        private static readonly string[] EmployeeTypeInString = { "Director", "Cleaner", "Receptionist", "Cleaner-Receptionist"};
        public EmployeeTypeEnum()
        {
        }

        public static string GetConformityEnumValue(EmployeeType enumValue)
        {
            // return  (string)EmployeeTypeInString.GetValue(((int)enumValue));
            return EmployeeTypeInString[(int)enumValue];
        }

    }
}
