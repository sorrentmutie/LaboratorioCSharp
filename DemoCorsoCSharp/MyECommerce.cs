namespace DemoCorsoCSharp;

public interface IProductModel
{
    string? Title { get; set; }
    bool HasOrderBeenCompleted { get; }
    void ShipItem(CustomerModel customer);
}

public interface IDigitalProductModel: IProductModel
{
    int TotalDownloadLeft { get; }
}

public class CustomerModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? City { get; set; }
    public string? EmailAddress { get; set; }
    public string? Phone { get; set; }
}

public class PhysicalProductModel: IProductModel
{
    public string? Title { get; set; }
    public bool HasOrderBeenCompleted { get; private set; }
    public void ShipItem(CustomerModel customer)
    {
        if(HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Simulazione shipping a {customer.FirstName} {customer.LastName}");
            HasOrderBeenCompleted = true;
        }
    }
}

public class DigitalProductModel: IDigitalProductModel
{
    public string? Title { get; set; }

    public bool HasOrderBeenCompleted { get; private set; }

    public int TotalDownloadLeft { get; private set; } = 5;

    public void ShipItem(CustomerModel customer)
    {
        Console.WriteLine($"Simulazione email a {customer.EmailAddress}");
        if (HasOrderBeenCompleted == false)
        {
            TotalDownloadLeft -= 1;
            if (TotalDownloadLeft == 0) {
                HasOrderBeenCompleted = true;
            }
        }
    }
}
