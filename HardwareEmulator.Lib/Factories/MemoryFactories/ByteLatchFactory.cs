using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IByteLatchFactory
{
    public ByteLatch Create();
}

public class ByteLatchFactory : IByteLatchFactory
{
    private readonly IEightBitLatchFactory _eightBitLatchFactory;

    public ByteLatchFactory(IEightBitLatchFactory eightBitLatchFactory)
    {
        _eightBitLatchFactory = eightBitLatchFactory;
    }

    public ByteLatch Create()
    {
        return new ByteLatch(_eightBitLatchFactory);
    }
}
