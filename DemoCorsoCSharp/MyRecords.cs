namespace DemoCorsoCSharp;

//public record Product
//{
//    public string? Name { get; init; }
//    public int CategoryId { get; init; }

//    //public Product(string? name, int categoryId)
//    //{
//    //    (Name, CategoryId) = (name, categoryId);
//    //}
     
//    public Product(string? name, int categoryId)
//        => (Name, CategoryId) = (name, categoryId);

//    public void Deconstruct(out string? name, out int categoryId)
//        => (name, categoryId) = (Name, CategoryId);
//}

//public record Product(string? Name, int CategoryId);

//public record ProductSpecial
//{
//    public string? Name { get; init; }
//    public int CategoryId { get; init; }
//}


//public record Book : ProductSpecial
//{
//    public string? ISBN { get; init; }
//}