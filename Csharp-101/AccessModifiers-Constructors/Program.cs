namespace AccessModifiersConstructors;
class Program
{
    static void Main(string[] args)
    {
        // Syntax
        // Class ClassName
        //{
        //    [Access Modifiers]    [Data Type] PropertyName:
        //    [Access Modifiers]    [Return Type] MethodsName ([List of parameters])
        //    {
        //        // Operations
        //    }

        //Access Modifiers
        // * Public
        // * Private
        // * Internal
        // * Protected
        Console.WriteLine("****Employee 1****");
        //Using constructor with parameters.
        Employee employeeOne = new Employee("Ozcan", "Kahya", 2300, "Human Resources");
        employeeOne.GetEmployeeInfo();

        Console.WriteLine("****Employee 2****");
        Employee employeeTwo = new Employee();
        employeeTwo.Name = "Okan";
        employeeTwo.LastName = "Buruk";
        employeeTwo.No = 2308;
        employeeTwo.Department = "Information Technology";

        employeeTwo.GetEmployeeInfo();

        Console.WriteLine("****Employee 3****");
        Employee employeeThree = new Employee("Fatih", "Terim");
        employeeThree.GetEmployeeInfo();

    }
}
class Employee
{
    public string Name;
    public string LastName;
    public int No;
    public string Department;

    //constructor method
    public Employee(string name, string lastName, int no, string department)
    {
        this.Name = name;
        this.LastName = lastName;
        this.No = no;
        this.Department = department;

    }
    public Employee(string name, string lastName)
    {
        this.Name = name;
        this.LastName = lastName;

    }
    public Employee() { }
    public void GetEmployeeInfo()
    {
        Console.WriteLine("Name of the employee: {0}", Name);
        Console.WriteLine("Last Name of the employee: {0}", LastName);
        Console.WriteLine("Id of the employee: {0}", No);
        Console.WriteLine("Department of the employee: {0}", Department);
    }
}
