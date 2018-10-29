using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Payroll
{
    class Program
    {
       //NOTE, I TOOK TWO DIFFERENT APPROACHES TO THIS, ONE CREATES LISTS FOR EACH PROPERTY, THE OTHER CREATES A LIST FOR THE ENTIRE CLASS


        static void Main(string[] args)
        {
            Create(); //Creates lists from Paring.cs [OPTION 1]
            
            EmployeeList emplist = new EmployeeList(); //Creates lists from EmployeeList.cs using Employee.cs [OPTION 2]
            emplist.MakeList();



        }

        static void Create()
        {
         //Initializes a list for each property
        List<int> empid = new List<int>();
        List<string> empname = new List<string>();
        List<double> rateofpay = new List<double>();
        List<double> hoursworked = new List<double>();
        Pairing pairing = new Pairing(empid, empname, rateofpay, hoursworked);

        Console.WriteLine("Adding Information....");

            //Creates the lists
            pairing.AddID();
            pairing.AddHours();
            pairing.AddName();
            pairing.AddRate();

            //Calculates then serializes
            pairing.Calculate();
        }

       
    }
}
