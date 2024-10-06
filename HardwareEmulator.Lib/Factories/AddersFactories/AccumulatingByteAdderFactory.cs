using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.MemoryFactories;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface IAccumulatingByteAdderFactory
{
    public AccumulatingByteAdder Create();
}

public class AccumulatingByteAdderFactory : IAccumulatingByteAdderFactory
{
    private readonly IByteAdderfactory _byteAdderFactory;
    private readonly IByteLatchFactory _byteLatchFactory;

    public AccumulatingByteAdderFactory(IByteAdderfactory byteAdderFactory, IByteLatchFactory byteLatchFactory)
    {
        _byteAdderFactory = byteAdderFactory;
        _byteLatchFactory = byteLatchFactory;
    }

    public AccumulatingByteAdder Create()
    {
        return new AccumulatingByteAdder(_byteAdderFactory, _byteLatchFactory);
    }
}
