using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;

namespace Payroll
{
    public class EmployeeList
    {
        List<Employee> Employees = new List<Employee>(); //Makes list for Employees

        public void MakeList()
        {

            //Adds Employee objects to Employees list
            Employees.Add(new Employee(223445, "John Landry", 15.00, 35.50));
            Employees.Add(new Employee(223476, "Angela Rush", 15.00, 32.25));
            Employees.Add(new Employee(223487, "Bill Marsh", 16.50, 45.50));
            Employees.Add(new Employee(223504, "Peggy Simon", 16.75, 50));
            Employees.Add(new Employee(223512, "Carl Yost", 15.75, 40));
            Employees.Add(new Employee(223519, "Joe Miles", 15.00, 40));
            Employees.Add(new Employee(223525, "Joan Jefferies", 14.25, 25.75));
            Employees.Add(new Employee(223536, "George Mills", 13.65, 38));
            Employees.Add(new Employee(223542, "Gary Cooper", 15.25, 37.25));
            Employees.Add(new Employee(223558, "Mary Millicent", 15.75, 40));

            double total = 0;
            double totalpay = 0;
            double overtimehours;
            int i = 0;
            //These need to be initalized outside the foreach loop

            using (var sw = new StreamWriter(@"C:\Users\Chris\employeestuff.txt")) //used for file writing NOTES: YOUR DIRECTORY WILL BE DIFFERENT

                foreach (Employee emp in Employees)
                {
                    //All variables used throughout loop
                    string yes = "";
                    var ID = emp.EmployeeID;
                    var name = emp.EmployeeName;
                    var rate = emp.RateOfPay;
                    var hours = emp.HoursWorked;
                    double overtimepay = 0;
                    string payroll = "";
                    var pay = rate * hours;
                    total = rate + total;
                    double standard = total / (i + 1);
                    i++;


                    if (hours > 40) //If greater than hours, modifies the overtimepay/hours variables and outputs another string
                    {
                        overtimehours = hours - 40;
                        overtimepay = ((hours - 40) * rate * 1.5);
                        yes = ($"{name} worked {overtimehours} hours overtime for a total of ${overtimepay}");

                    }

                    if (i <= Employees.Count - 1) //If below or equal to the second to last employee count, modifies payroll string 
                    {
                        payroll =
                            ($"Employee ID {ID}: {name} worked {hours} hours for ${rate} and hour and made ${pay} total" +
                          
                             "\n " + yes + "\n");
                    }

                    totalpay = totalpay + pay + overtimepay; //Calculated after conditional statements to decide value

                    if (i == Employees.Count) //At the end, output a different payroll string
                    {

                        payroll =
                            ($"Employee ID {ID}: {name} worked {hours} hours for ${rate} and hour and made ${pay} total" +
                             "\n" +
                             $"\n Total pay for this period is now ${totalpay}" + "\n " + yes + "\n" +
                             $"Standard rate of pay is  ${standard}" + "\n");

                    }

                    sw.WriteLine(payroll); //writes to file
                    Console.WriteLine(payroll);
                    
                }
            Console.WriteLine("Written to file.");
            Console.ReadLine();

        }


    }
}
