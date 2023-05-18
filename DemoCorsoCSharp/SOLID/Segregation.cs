namespace DemoCorsoCSharp.SOLID;

public interface  IPrinterTasks
{
    void Print(string content);
    void Scan(string scanContent);
   // void Fax(string faxContent);
   // void Duplex(string duplexContent);
}


public interface IFaxTasks
{
    void Fax(string faxContent);
}


public interface IDuplexTasks
{
    void Duplex(string duplexContent);
}



public class LiquidInkPrinter : IPrinterTasks
{
    public void Print(string content)
    {
      
    }

    public void Scan(string scanContent)
    {
        
    }
}



public class HPLaserJet : IPrinterTasks, IFaxTasks, IDuplexTasks
{
    public void Duplex(string duplexContent)
    {
        throw new NotImplementedException();
    }

    public void Fax(string faxContent)
    {
        throw new NotImplementedException();
    }

    public void Print(string content)
    {
        throw new NotImplementedException();
    }

    public void Scan(string scanContent)
    {
        throw new NotImplementedException();
    }
}
