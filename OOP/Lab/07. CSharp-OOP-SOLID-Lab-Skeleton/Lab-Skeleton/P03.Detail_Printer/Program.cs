using System;
using System.Collections.Generic; 

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employeeOne = new Employee("Ivan");
            Employee employeeTwo = new Employee("Petkan");
            var documents = new List<string>() { "ff", "AFASF" };
            Manager manager = new Manager("Shefa", documents);
            List<Employee> employees = new List<Employee>() { employeeOne, employeeTwo, manager };
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
