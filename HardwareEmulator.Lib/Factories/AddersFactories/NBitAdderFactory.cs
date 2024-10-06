using HardwareEmulator.Lib.Adders;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface INBitAdderFactory
{
    public NBitAdder Create(int numberOfBits);
}

public class NBitAdderFactory : INBitAdderFactory
{
    private readonly IFullAdderFactory _fullAdderFactory;

    public NBitAdderFactory(IFullAdderFactory fullAdderFactory)
    {
        _fullAdderFactory = fullAdderFactory;
    }

    public NBitAdder Create(int numberOfBits)
    {
        return new NBitAdder(_fullAdderFactory, numberOfBits);
    }
}