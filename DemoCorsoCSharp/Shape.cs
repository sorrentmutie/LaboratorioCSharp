namespace DemoCorsoCSharp;

public class Shape {
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Height { get;  set; }
    public int Width { get; set; }

    public virtual int WorkProperty { get { return 1; } }

    public virtual void Draw()
    {
        Console.WriteLine("Drawing Base Class");
    }
}

public class Circle: Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
        base.Draw();
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
        base.Draw();
    }


    public override int WorkProperty { get { return 0; } }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a triangle");
        base.Draw();
    }
}


public class BaseClass
{
    public virtual void DoSomething() { }
    public virtual int MyProperty { get { return 0;} }
}

public class DerivedClass : BaseClass
{
    public override int MyProperty => base.MyProperty;
    public override void DoSomething()
    {
        base.DoSomething();
    }
}

public class SpecialDerivedClass : BaseClass
{
    public override int MyProperty => base.MyProperty;

    public new void DoSomething()
    {
        
    }
}


public class A
{
    public virtual void DoSomething() { }
}

public class B : A
{
    public override void DoSomething()
    {
        base.DoSomething();
    }
}

public class C: B
{
    public sealed override void DoSomething()
    {
        base.DoSomething();
    }
}

public class D : C
{
    public new void DoSomething()
    {
        base.DoSomething();
    }
}