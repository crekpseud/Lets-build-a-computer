using HardwareEmulator.Lib.Adders;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface IByteAdderfactory
{
    public ByteAdder Create();
}

public class ByteAdderFactory : IByteAdderfactory
{
    private readonly IEightBitAdderFactory _eightBitAdderFactory;

    public ByteAdderFactory(IEightBitAdderFactory eightBitAdderFactory)
    {
        _eightBitAdderFactory = eightBitAdderFactory;
    }

    public ByteAdder Create()
    {
        return new ByteAdder(_eightBitAdderFactory);
    }
}
