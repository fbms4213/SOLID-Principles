#region Before_LSP


//public class Document
//{
//    private string data;
//    private string fileName;
//    public void Open() { }
//    public void Save() { }
//}


//public class ReadOnlyDocument : Document
//{
//    public void Save() { throw new NotImplementedException(); }
//}



//public class Project
//{
//    List<Document> documents;

//    public void OpenAll()
//    {
//        foreach (var doc in documents)
//        {
//            doc.Open();
//        }
//    }

//    public void SaveAll()
//    {
//        foreach (var doc in documents)
//        {
//            doc.Save();
//        }
//    }
//}



#endregion





#region After_LSP



public class Document
{
    private string data;
    private string fileName;
    public void Open() { }
}



public class WritableDocument : Document
{
    public void Save() { }
}



public class Project
{
    List<Document> allDocuments;

    public void OpenAll()
    {
        foreach (var doc in allDocuments)
        {
            doc.Open();
        }
    }

    public void SaveAll()
    {
        foreach (var doc in allDocuments)
        {
            doc.Open();

            if (doc is WritableDocument wd)
                wd.Save();
        }
    }
}


#endregion