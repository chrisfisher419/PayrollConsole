using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class Employee //Contains all Employee class logic
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double RateOfPay { get; set; }
        public double HoursWorked { get; set; }

        public Employee(int employeeid, string employeename, double rateofpay, double hoursworked)
        {
            EmployeeID = employeeid;
            EmployeeName = employeename;
            RateOfPay = rateofpay;
            HoursWorked = hoursworked;
        }
    }
}
