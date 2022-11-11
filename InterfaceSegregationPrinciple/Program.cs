#region IS_Before


//interface ICloudProvider
//{
//    void StoreFile(string name);
//    void GetFile(string name);
//    void CreateServer(string region);
//    void ListServers(string region);
//    void GetCDNAddress();
//}


//public class Amazon : ICloudProvider
//{
//    public void CreateServer(string region)
//    {
//        // CreateServer ...
//    }

//    public void ListServers(string region)
//    {
//        // ListServers ...
//    }

//    public void GetCDNAddress()
//    {
//        // GetCDNAddress ...
//    }

//    public void StoreFile(string name)
//    {
//        // Amazon StoreFile ...
//    }

//    public void GetFile(string name)
//    {
//        // Amazon GetFile ...
//    }
//}



//public class DropBox : ICloudProvider
//{
//    public void StoreFile(string name)
//    {
//        // DropBox StoreFile ...
//    }

//    public void GetFile(string name)
//    {
//        // DropBox GetFile ...
//    }



//    public void ListServers(string region)
//    {
//        throw new NotImplementedException();
//    }

//    public void GetCDNAddress()
//    {
//        throw new NotImplementedException();
//    }

//    public void CreateServer(string region)
//    {
//        throw new NotImplementedException();
//    }
//}


#endregion






#region IS_After



interface ICloudHostingProvider
{
    void CreateServer(string region);
    void ListServers(string region);
}

interface ICDNProdiver
{
    void GetCDNAddress();
}

interface ICloudStorageProdiver
{
    void StoreFile(string name);
    void GetFile(string name);
}



public class Amazon : ICloudHostingProvider, ICloudStorageProdiver, ICDNProdiver
{
    public void CreateServer(string region)
    {
        // CreateServer ...
    }

    public void ListServers(string region)
    {
        // ListServers ...
    }


    public void GetCDNAddress()
    {
        // GetCDNAddress ...
    }



    public void StoreFile(string name)
    {
        // Amazon StoreFile ...
    }
    public void GetFile(string name)
    {
        // Amazon GetFile ...
    }
}



public class DropBox : ICloudStorageProdiver
{
    public void StoreFile(string name)
    {
        // DropBox StoreFile ...
    }
    public void GetFile(string name)
    {
        // DropBox GetFile ...
    }
}



#endregion