using System;
using System.Collections.Generic;



namespace MAS_semestral_project_MVS.Models.Enums
{
    public class WorkingShiftEnum
    {
        public enum WorkingShift
        {
            Day = 0,
            Night = 1,
            Day_Night = 2, 
            Night_Day = 3
        }
        private readonly string[] WorkingShiftInString = { "day", "night", "day-night", "night-day" };
        public WorkingShiftEnum()
        {
        }

        public string GetConformityEnumValue(WorkingShift enumValue)
        {
            // return  (string)WorkingShiftInString.GetValue(((int)enumValue));
            return WorkingShiftInString[(int)enumValue];
        }

    }
}
