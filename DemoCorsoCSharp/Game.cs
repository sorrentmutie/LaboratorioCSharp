using System.Runtime.CompilerServices;

namespace DemoCorsoCSharp;

public interface IVisible
{
    void Paint();
}

public interface ICollidable
{
    void Collide();
}

public interface IUpdatable
{
    void Update();
}

public class Visible : IVisible
{
    public void Paint()
    {
        Console.WriteLine("Io Apparirò sullo schermo");
    }
}

public class Invisible : IVisible
{
    public void Paint()
    {
        Console.WriteLine("Io Non Apparirò sullo schermo");
    }
}

public class Solid : ICollidable
{
    public void Collide()
    {
        Console.WriteLine("Bang!");
    }
}
public class Liquid : ICollidable
{
    public void Collide()
    {
        Console.WriteLine("Splash!");
    }
}

public class Fixed : IUpdatable
{
    public void Update()
    {
        Console.WriteLine("Sono fermo");
    }
}

public class Movable : IUpdatable
{
    public void Update()
    {
        Console.WriteLine("Mi sposto");
    }
}


public class GameElement : ICollidable, IUpdatable, IVisible
{
    private readonly ICollidable _collidable;
    private readonly IUpdatable updatable;
    private readonly IVisible visible;

    public GameElement(ICollidable collidable, IUpdatable updatable, IVisible visible)
    {
       _collidable = collidable;
        this.updatable = updatable;
        this.visible = visible;
    }

    public void Collide()
    {
        _collidable.Collide();
    }

    public void Paint()
    {
        visible.Paint();
    }

    public void Update()
    {
       updatable.Update();
    }
}

public class Mago: GameElement
{
    public Mago(ICollidable collidable, IUpdatable updatable, IVisible visible) 
        : base(collidable, updatable, visible)
    {
        
    }
}