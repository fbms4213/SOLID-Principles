#region DI_Before

//class BudgetReport
//{
//    private MySQLDatabase database;
//    public void Open(string date) { }
//    public void Save() { }
//}


//class MySQLDatabase
//{
//    public void Insert() { }
//    public void Update() { }
//    public void Delete() { }
//}

#endregion







#region DI_After

using static System.Console;

class BudgetReport
{
    private IDataBase database;
    public void Open(string date) => Console.WriteLine("File Opened!");
    public void Save() => Console.WriteLine("File Saved!");
}



interface IDataBase
{
    void Insert();
    void Update();
    void Delete();
}


class MySQLDatabase : IDataBase
{
    public void Delete() => WriteLine("MySQLDatabase Delete");
    public void Insert() => WriteLine("MySQLDatabase Insert");
    public void Update() => WriteLine("MySQLDatabase Update");
}


class MongoDB : IDataBase
{
    public void Delete() => WriteLine("MongoDB Delete");
    public void Insert() => WriteLine("MongoDB Insert");
    public void Update() => WriteLine("MongoDB Update");
}

#endregion