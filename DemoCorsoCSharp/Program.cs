// See https://aka.ms/new-console-template for more information
using DemoCorsoCSharp;

Console.WriteLine("Hello, World!");

//var shapes = new List<Shape> {
//    new Rectangle(),
//    new Triangle(),
//    new Circle()
//};

//foreach (var shape in shapes)
//{
//    shape.Draw();
//}

//var product = new Product
//{
//    Name = "Video Game",
//    CategoryId = 1
//};

//var newProduct = product with { CategoryId = 2 };

//var anotherProduct = newProduct with { CategoryId = 1 };

//var eq1 = product.Equals(anotherProduct);
//Console.WriteLine(eq1);

//var eq2 = product ==  anotherProduct;
//Console.WriteLine(eq2);

var product = new Product("Video Game", 1);
//string? a = "";
//int b = 0;

//product.Deconstruct(out a, out b);
//Console.WriteLine(b);

var (a, b) = product;
Console.WriteLine(b);