namespace HardwareEmulator.Lib.Factories;

public interface ITriStateBufferFactory
{
    public TriStateBuffer Create(int numberOfElements);
}

public class TriStateBufferFactory : ITriStateBufferFactory
{
    private readonly ITriStateFactory _triStateFactory;

    public TriStateBufferFactory(ITriStateFactory triStateFactory)
    {
        _triStateFactory = triStateFactory;
    }

    public TriStateBuffer Create(int numberOfElements)
    {
        return new TriStateBuffer(numberOfElements, _triStateFactory);
    }
}
