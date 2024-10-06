using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IRSFlipFlopFactory
{
    public RSFlipFlop Create();
}

public class RSFlipFlopFactory : IRSFlipFlopFactory
{
    private readonly INorGateFactory _norGateFactory;

    public RSFlipFlopFactory(INorGateFactory norGateFactory)
    {
        _norGateFactory = norGateFactory;
    }

    public RSFlipFlop Create()
    {
        return new RSFlipFlop(_norGateFactory);
    }
}
