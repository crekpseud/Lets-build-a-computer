using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IEightBitLatchFactory
{
    public EightBitLatch Create();
}

public class EightBitLatchFactory : IEightBitLatchFactory
{
    private readonly IEdgeTriggeredDtypeFlipFlopFactory _flipFlopFactory;

    public EightBitLatchFactory(IEdgeTriggeredDtypeFlipFlopFactory flipFlopFactory)
    {
        _flipFlopFactory = flipFlopFactory;
    }

    public EightBitLatch Create()
    {
        return new EightBitLatch(_flipFlopFactory);
    }
}
