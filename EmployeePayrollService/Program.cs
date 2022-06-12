using System;
using EmployeePayrollService;
class program
{
    public static void Main(string[] args)
    {
        EmployeeRepository repository = new EmployeeRepository();
        bool check = true;
        Console.WriteLine("1.Add Employee data\n2.Retrive Employee data \n3.Update Salary \n4.Deleting Employee Details \n5.Retrive employee details by data range \n6. Find sum avg");
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
                case 3:
                    EmployeeDetails detail = new EmployeeDetails();
                    detail.EmpId = 1;
                    detail.Salary = 30000;
                    repository.UpdateEmployeeSalary(detail);
                    break;
                case 4:
                    EmployeeDetails employee = new EmployeeDetails();
                    employee.EmpId = 1;
                    employee.Name = "Tanveer";
                    repository.DeleteEmployeeDetails(employee);
                    break;
                case 5:
                    List<EmployeeDetails> employees = repository.RetrieveEmployeeData();
                    Console.WriteLine("Enter date: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    repository.RetrieveEmployeesVByDataRange(date);
                    foreach (EmployeeDetails data in employees)
                    {
                        if (data.Startdate.Equals(date))
                        {
                            Console.WriteLine(data.EmpId + " " + data.Name + " " + data.Salary + data.Startdate + " " + data.Gender + " " + data.PhoneNumber + " " + data.Department + " " + data.Deduction + " " + data.Taxable_Pay + " " + data.Net_Pay);
                        }
                    }
                    break;
                case 6:
                    EmployeeDetails emp = new EmployeeDetails();
                    Console.WriteLine("Enter the gender");
                    emp.Gender = Console.ReadLine();
                    repository.FindSumAvgMaxMin(emp);
                    if (emp.Gender == "M")
                    {
                        Console.WriteLine(emp.Salary);
                    }
                    break;
            }
        }
    }
}