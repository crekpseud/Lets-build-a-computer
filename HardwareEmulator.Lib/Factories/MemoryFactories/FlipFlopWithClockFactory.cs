using HardwareEmulator.Lib.Memory;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IFlipFlopWithClockFactory
{
    public FlipFlopWithClock Create();
}

public class FlipFlopWithClockFactory : IFlipFlopWithClockFactory
{
    private readonly IRSFlipFlopFactory _rsFlipFlopFactory;
    private readonly IAndGateFactory _andGateFactory;

    public FlipFlopWithClockFactory(IRSFlipFlopFactory rsFlipFlopFactory, IAndGateFactory andGateFactory)
    {
        _rsFlipFlopFactory = rsFlipFlopFactory;
        _andGateFactory = andGateFactory;
    }

    public FlipFlopWithClock Create()
    {
        return new FlipFlopWithClock(_rsFlipFlopFactory, _andGateFactory);
    }
}
