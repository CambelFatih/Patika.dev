
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
        Employee employee1 = new Employee();
        employee1.Name = "Fatih Furkan";
        employee1.LastName = "Çambel";
        employee1.No = 2308;
        employee1.Department = "Information Technology";

        employee1.GetEmployeeInfo();
        Console.WriteLine("__________________________________\n");

        Employee employee2 = new Employee();
        employee2.Name = "Tevfik";
        employee2.LastName = "Saygıner";
        employee2.No = 2309;
        employee2.Department = "Purchasing Department";

        employee2.GetEmployeeInfo();
       
    class Employee
    {
        public string Name;
        public string LastName;
        public int No;
        public string Department;

        public void GetEmployeeInfo()
        {
            Console.WriteLine("Name of the employee: {0}",Name);
            Console.WriteLine("Last Name of the employee: {0}",LastName);
            Console.WriteLine("Id of the employee: {0}",No);
            Console.WriteLine("Department of the employee: {0}",Department);
        }
    }

