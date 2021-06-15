using System;
using System.Collections.Generic;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class PlaceWork
    {
        public int IdPlaceWork { get; set; }
        public string Name { get; set; }
        public int EmployeeIdPerson { get; set; }

        private Person employeeIdPersonNavigation;

        //  EmployeeIdPersonNavigation  have type Person for creating opportunity of existing overlapping among Client and Employee.
        public virtual Person EmployeeIdPersonNavigation { 
            get { return employeeIdPersonNavigation;  } 
            set 
            {
                if (value == null) throw new Exception("Employee couldn't be null.");
                if (this.EmployeeIdPersonNavigation != null) throw new Exception("PlaceWork already have connection/relation with Employee, and can't be connected to another one.");
                employeeIdPersonNavigation = value;
                EmployeeIdPerson = value.IdOsoba;
                // value.Add
                /// TO DO
            } 
        }


        
    }
}
