namespace DemoCorsoCSharp;

//public class Floor
//{
//    public string BuildFloor()
//    {
//        return "floor"; 
//    }
//}

//public class Ceiling
//{
//    public string BuildCeiling()
//    {
//        return "ceiling";
//    }
//}

//public class House
//{
//    private readonly Ceiling _ceiling;
//    private readonly Floor _floor;

//    public House()
//    {
//        _ceiling = new Ceiling();
//        _floor = new Floor();
//    }

//    public string GetCeiling() => _ceiling.BuildCeiling();
//    public string GetFloor() => _floor.BuildFloor();

//}

public class Address
{
    public virtual string GetAddress() => "Address";
}

public class House
{

}


public class BrickHouse: House
{
    private readonly Address _address;
    public BrickHouse()
    {
        _address = new Address();
    }

    public string GetAddress()
    {
        return _address.GetAddress();
    }
}

public class Caravan: House
{

}


//public class House
//{
//    public virtual string GetAddress() => "Address";
//}

//public class Caravan: House
//{
//    public override string GetAddress()
//    {
//        throw new Exception("Non c'è indirizzo");
//    }
//}