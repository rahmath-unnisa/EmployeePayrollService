using System;
using EmployeePayrollService;
class program
{
    public static void Main(string[] args)
    {
        EmployeeRepository repository = new EmployeeRepository();
        bool check = true;
        Console.WriteLine("1.Add Employee data\n2.Retrive Employee data");
        while (check)
        {
            Console.WriteLine("Choose an option");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    EmployeeDetails details = new EmployeeDetails();
                    details.EmpId = 1;
                    details.Name = "Manha";
                    details.Salary = 50000;
                    details.Startdate = DateTime.Now;
                    details.Gender = "F";
                    details.PhoneNumber = 474768;
                    details.Department = "Marketing";
                    details.Deduction = 500;
                    details.Taxable_Pay = 3000;
                    details.Net_Pay = 20000;
                    repository.AddEmployee(details);
                    break;
                case 2:
                    repository.RetrieveEmployeeData();
                    break;
            }
        }
    }
}