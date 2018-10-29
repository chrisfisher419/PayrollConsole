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
    [Serializable] //Allows for seriaization
    public class Pairing //makes a seperate list for each property
    {
        public List<int> EmployeeID { get; set; }
        public List<string> EmployeeName { get; set; }
        public List<double> RateOfPay { get; set; }
        public List<double> HoursWorked { get; set; }

        //Constructor
        public Pairing(List<int> employeeid, List<string> employeename, List<double> rateofpay, List<double> hoursworked)
        {
            EmployeeID = employeeid;
            EmployeeName = employeename;
            RateOfPay = rateofpay;
            HoursWorked = hoursworked;
        }

        //Serializes NOTE: YOUR DIRECTORY WILL BE DIFFERENT
        public void Serialization()
        {
            //Console.Clear();
            Console.WriteLine("Serializing");
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\Chris\employee.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, EmployeeID);
            formatter.Serialize(stream, EmployeeName);
            formatter.Serialize(stream, RateOfPay);
            formatter.Serialize(stream, HoursWorked);

            stream.Close();
            Console.WriteLine("Serialized to C -> Users -> Chris -> Employee.txt ");
            Console.ReadLine();

        }
        

        //Adds all IDs to ID list
        public void AddID()
        {
            EmployeeID.Add(223445);
            EmployeeID.Add(223476);
            EmployeeID.Add(223487);
            EmployeeID.Add(223504);
            EmployeeID.Add(223512);
            EmployeeID.Add(223519);
            EmployeeID.Add(223525);
            EmployeeID.Add(223536);
            EmployeeID.Add(223542);
            EmployeeID.Add(223558);
        }

        //Adds all Names to names list
        public void AddName()
        {
            EmployeeName.Add("John Landry");
            EmployeeName.Add("Angela Rush");
            EmployeeName.Add("Bill Marsh");
            EmployeeName.Add("Peggy Simon");
            EmployeeName.Add("Call Yost");
            EmployeeName.Add("Joe Miles");
            EmployeeName.Add("Joan Jefferies");
            EmployeeName.Add("George Mills");
            EmployeeName.Add("Gary Cooper");
            EmployeeName.Add("Mary Millicent");

        }

        //Adds all rates to rates list
        public void AddRate()
        {
            RateOfPay.Add(15.00);
            RateOfPay.Add(15.00);
            RateOfPay.Add(16.50);
            RateOfPay.Add(16.75);
            RateOfPay.Add(15.75);
            RateOfPay.Add(15.00);
            RateOfPay.Add(14.25);
            RateOfPay.Add(13.65);
            RateOfPay.Add(15.25);
            RateOfPay.Add(15.75);
        }

        //Adds all hours to hours list
        public void AddHours()
        {
            HoursWorked.Add(35.50);
            HoursWorked.Add(32.25);
            HoursWorked.Add(45.50);
            HoursWorked.Add(50);
            HoursWorked.Add(40);
            HoursWorked.Add(40);
            HoursWorked.Add(25.75);
            HoursWorked.Add(38);
            HoursWorked.Add(37.25);
            HoursWorked.Add(40);
        }
       
        //executes everything
        public void Calculate()
        {
            double total = 0;
            double totalpay = 0;
            
            double overtimehours;
            

            using (var sw = new StreamWriter(@"C:\Users\Chris\payroll.txt")) //Allows for file writing NOTE: YOUR DIRECTORY WILL BE DIFFERENT

                for (int i = 0; i < EmployeeID.Count; i++)
                {
                string yes = "";
                var ID = EmployeeID[i];
                var name = EmployeeName[i];
                var rate = RateOfPay[i];
                var hours = HoursWorked[i];
                double overtimepay = 0;
                string payroll = "";
                var pay = rate * hours;
                total = rate + total;
                double standard = total / (i+1);

                if (hours > 40) //If hours greater than 40, calculate overtime and provide new string
                {
                    overtimehours = hours - 40;
                    overtimepay = ((hours - 40) * rate * 1.5);
                        yes = ($"{name} worked {overtimehours} hours overtime for a total of ${overtimepay}");
                    
                }

                if (i < EmployeeID.Count - 1) //If second to last, modify payroll string
                {
                         payroll =
                            ($"Employee ID {ID}: {name} worked {hours} hours for ${rate} and hour and made ${pay} total" +
                              "\n " + yes + "\n");
                }

                totalpay = totalpay + pay + overtimepay; //calculates total pay after conditonal statements

                if (i == EmployeeID.Count - 1) //at the end, modify payroll string
                {

                        payroll =
                            ($"Employee ID {ID}: {name} worked {hours} hours for ${rate} and hour and made ${pay} total" + "\n" +
                             $"\n Total pay for this period is now ${totalpay}" + "\n " + yes + "\n" +
                             $"Standard rate of pay is  ${standard}" + "\n");

                }

                    sw.WriteLine(payroll); //Writes to file
                    Console.WriteLine(payroll);
                    
            }

            Console.WriteLine("Written to file.");
            Console.ReadLine();
            
            Serialization(); //Serializes

        }

    }
}

