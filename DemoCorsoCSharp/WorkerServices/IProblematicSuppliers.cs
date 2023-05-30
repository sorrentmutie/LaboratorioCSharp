using System.Runtime.CompilerServices;

namespace DemoCorsoCSharp.WorkerServices;

public interface IProblematicSuppliers
{
    bool IsProblematic(string CompanyName);
}

public class RandomProblematicSupplier : IProblematicSuppliers
{
    private Random RandomGenerator = new Random();

    public bool IsProblematic(string CompanyName)
    {
        return RandomGenerator.NextDouble() > 0.5;
    }
}
