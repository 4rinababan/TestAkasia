using System;
using System.Collections.Generic;

class Program
{
    static List<Employee> employees = new List<Employee>(); // list Employee in Memory

    static void Main() // main  method call on load
    {
        try 
        {
             // Menu 
            while (true) 
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Remove Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(); // add employee method
                        break;

                    case "2":
                        DisplayEmployees(); // show all employees method on memory save
                        break;

                    case "3":
                        RemoveEmployee(); //remove employee method
                        break;

                    case "4":
                        Environment.Exit(0); // end of program method
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again."); // if out of menu input user
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void AddEmployee() // add employee method
    {
        Console.WriteLine("\nAdd New Employee:");

        Console.Write("EmployeeId: ");
        string employeeId = Console.ReadLine(); // input user 

        Console.Write("FullName: ");
        string fullName = Console.ReadLine(); // input user

        Console.Write("BirthDate (DD-MM-YY): "); // input user

        if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-YY", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate)) // check valid date if not valid show message validation
        {
            // Validation successful
            Employee newEmployee = new Employee
            {
                EmployeeId = employeeId,
                FullName = fullName,
                BirthDate = birthDate
            };

            // Check for duplicate employeeId if not duplicate save to list employee
            if (!employees.Exists(e => e.EmployeeId == newEmployee.EmployeeId))
            {
                employees.Add(newEmployee);
                Console.WriteLine("Employee added successfully.\n");
            }
            else 
            {
                Console.WriteLine("Employee with the same EmployeeId already exists.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please use DD-MM-YY format.\n");
        }
    }

    static void DisplayEmployees() // show all employees in list employee
    {
        Console.WriteLine("\nList of Employees:");

        if (employees.Count > 0)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("EmployeeId\tFullName\tBirthDate");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeId} \t\t {employee.FullName} \t\t {employee.BirthDate:dd-MMM-yy}");

            }
            Console.WriteLine("---------------------------------------------");
        }
        else // show message if not exist
        {
            Console.WriteLine("No employees found.\n");
        }
    }

    static void RemoveEmployee() // remove/delete employee method
    {
        Console.WriteLine("\nRemove Employee:");

        Console.Write("Enter EmployeeId to remove: ");
        string employeeIdToRemove = Console.ReadLine();

        var employeeToRemove = employees.Find(e => e.EmployeeId == employeeIdToRemove);

        if (employeeToRemove != null)
        {
            employees.Remove(employeeToRemove);
            Console.WriteLine("Employee removed successfully.\n");
        }
        else
        {
            Console.WriteLine("Employee not found.\n");
        }
    }
}

class Employee
{
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}
