namespace DemoCorsoCSharp.SOLID;

public class OpenInvoice
{

    //public double GetDiscount(double amount, InvoiceType invoiceType)
    //{
    //    double finalAmount = 0.0;

    //    if(invoiceType == InvoiceType.Proposed)
    //    {
    //        finalAmount = amount - 100;
    //    } else if (invoiceType == InvoiceType.Final)
    //    {
    //        finalAmount = amount - 50;
    //    }
    //    return finalAmount;
    //}

    public virtual double GetDiscount(double amount)
    {
        return amount;
    }


}


public class ProposedInvoice: OpenInvoice
{
    public override double GetDiscount(double amount)
    {
        return amount - 100;
    }
}

public class FinalInvoice: OpenInvoice
{
    public override double GetDiscount(double amount)
    {
        return amount - 50;
    }
}

public class SpecialInvoice: OpenInvoice
{
    public override double GetDiscount(double amount)
    {
        return amount - 75;
    }
}



public enum InvoiceType
{
    Proposed,
    Final
}
