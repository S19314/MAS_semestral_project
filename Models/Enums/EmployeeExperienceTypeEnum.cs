using System;
using System.Collections.Generic;


namespace MAS_semestral_project_MVS.Models.Enums
{
    public class EmployeeExperienceTypeEnum
    {
        public enum EmployeeExperienceType
        {
            Apprentice= 0,
            Experienced = 1
        }
        private readonly string[] EmployeeExperienceTypeInString = { "Apprentice", "Experienced" };
        public EmployeeExperienceTypeEnum()
        {
        }

        public string GetConformityEnumValue(EmployeeExperienceType enumValue)
        {
            // return  (string)EmployeeExperienceTypeInString.GetValue(((int)enumValue));
            return EmployeeExperienceTypeInString[(int)enumValue];
        }

    }
}
