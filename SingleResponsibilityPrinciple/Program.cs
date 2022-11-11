#nullable disable







#region SRP_Before

//class Employee
//{
//    public string Name { get; set; }
//    public string Surname { get; set; }
//    public DateOnly BirthOfDate { get; set; }

//    public void PrintTimeSheetReport()
//    {
//        // ... do something

//        Console.WriteLine($"{Name} {Surname} {BirthOfDate.ToShortDateString()}");
//    }
//}


#endregion







#region SRP_After

class Employee
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthOfDate { get; set; }
}

class TimeSheetReport
{
    // ...

    public void Print(Employee e)
    {
        // ... do something
        Console.WriteLine($"{e.Name} {e.Surname} {e.BirthOfDate.ToShortDateString()}");
    }
}

#endregion