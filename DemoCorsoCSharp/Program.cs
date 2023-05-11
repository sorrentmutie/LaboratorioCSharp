// See https://aka.ms/new-console-template for more information
using DemoCorsoCSharp;

Console.WriteLine("Hello, World!");

var shapes = new List<Shape> {
    new Rectangle(),
    new Triangle(),
    new Circle()
};

foreach (var shape in shapes)
{
    shape.Draw();
}