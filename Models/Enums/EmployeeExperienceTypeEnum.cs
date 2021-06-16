using System;
using System.Collections.Generic;


namespace MAS_semestral_project_MVS.Models.Enums
{
    public class EmployeeExperienceTypeEnum
    {
        public enum EmployeeExperienceType
        {
            Apprentice  = 0,
            Experienced = 1
        }
        private readonly static string[] EmployeeExperienceTypeInString = { "Apprentice", "Experienced" };
        public EmployeeExperienceTypeEnum()
        {
        }

        public static string GetConformityEnumValue(EmployeeExperienceType enumValue)
        {
            return EmployeeExperienceTypeInString[(int)enumValue];
        }

        public static bool Contains(string enumName) 
        {
            for (int i = 0; i < EmployeeExperienceTypeInString.Length; i++) 
            {
                if (EmployeeExperienceTypeInString[i].Equals(enumName)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
