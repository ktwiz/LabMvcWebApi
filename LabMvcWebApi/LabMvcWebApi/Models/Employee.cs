using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMvcWebApi.Models
{
    public class Employee
    {
        public int Empl_id { get; set; }

        public string Empl_name { get; set; }

        public string Empl_email { get; set; }

        public DateTime Empl_birthdt { get; set; }

        public DateTime? Empl_terminatedt { get; set; }

        public decimal Empl_salary { get; set; }

        public static List<Employee> initListEmpl()
        {
            return new List<Employee>
            {
                new Employee{ Empl_id = 1, Empl_name = "Harry", Empl_birthdt = new DateTime(1988,01,01), Empl_email = "harry@email.com", Empl_salary = 7000000, Empl_terminatedt = null },
                new Employee{ Empl_id = 2, Empl_name = "Ronald", Empl_birthdt = new DateTime(1985,05,01), Empl_email = "ron@email.com", Empl_salary = 17000000, Empl_terminatedt = DateTime.Now },
                new Employee{ Empl_id = 3, Empl_name = "Herminone", Empl_birthdt = new DateTime(1989,01,12), Empl_email = "cutegirl@email.com", Empl_salary = 3500000, Empl_terminatedt = null },
            };
        }
    }
}