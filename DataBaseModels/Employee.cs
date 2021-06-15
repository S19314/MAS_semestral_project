using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public class Employee : Person
    {
        public Employee() : base() 
        {
            PlaceWorks = new HashSet<PlaceWork>();
        }
        public virtual ICollection<PlaceWork> PlaceWorks { get; set; }
        /*
          Допилить создание ассоциации.
        */

        /// <summary>
        /// Adding an employee's place of last Work.
        /// </summary>
        /// <param name="placeWorkName"></param>
        public void AddPlaceWork(string placeWorkName) 
        {
            if (placeWorkName.Equals("") || placeWorkName == null) throw new Exception("PlaceWorkName can't be null or empty.");
            var placeWork = new PlaceWork { Name = placeWorkName, EmployeeIdPerson = this.IdOsoba};
            
            // PlaceWorks.Add(placeWork);
            // this.PlaceWorks.Add(placeWork);
        }
        /// <summary>
        /// Adding an employee's place of last Work.
        /// </summary>
        /// <param name="placeWork"></param>
        public void AddPlaceWork(PlaceWork placeWork) 
        {
            if (placeWork == null) throw new Exception("PlaceWork can't be null.");
            // placeWork.EmployeeIdPersonNavigation = this; // special method

            PlaceWorks.Add(placeWork);
            // placeWork.SetEmployee(this); 
            /// TO DO <paramref name="placeWork"/>.SetEmployee(this); 

            // this.PlaceWorks.Add(placeWork);
        }


        // public void UnSetPlaceWork() { }

    }
}
