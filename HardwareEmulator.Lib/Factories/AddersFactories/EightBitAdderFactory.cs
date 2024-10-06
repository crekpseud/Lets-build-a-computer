using HardwareEmulator.Lib.Adders;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface IEightBitAdderFactory
{
    public EightBitAdder Create();
}

public class EightBitAdderFactory : IEightBitAdderFactory
{
    private readonly IFullAdderFactory _fullAdderFactory;

    public EightBitAdderFactory(IFullAdderFactory fullAdderFactory)
    {
        _fullAdderFactory = fullAdderFactory;
    }

    public EightBitAdder Create()
    {
        return new EightBitAdder(_fullAdderFactory);
    }
}