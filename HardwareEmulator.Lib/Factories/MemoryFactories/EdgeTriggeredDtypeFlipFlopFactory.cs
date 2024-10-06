using HardwareEmulator.Lib.Memory;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IEdgeTriggeredDtypeFlipFlopFactory
{
    public EdgeTriggeredDtypeFlipFlop Create();

    public EdgeTriggeredDtypeFlipFlop[] CreateArray(int count);
}

public class EdgeTriggeredDtypeFlipFlopFactory : IEdgeTriggeredDtypeFlipFlopFactory
{
    private readonly IFlipFlopWithClockFactory _flipFlopWithClockFactory;
    private readonly IInverterFactory _inverterFactory;

    public EdgeTriggeredDtypeFlipFlopFactory(IFlipFlopWithClockFactory flipFlopWithClockFactory, IInverterFactory inverterFactory)
    {
        _flipFlopWithClockFactory = flipFlopWithClockFactory;
        _inverterFactory = inverterFactory;
    }

    public EdgeTriggeredDtypeFlipFlop Create()
    {
        return new EdgeTriggeredDtypeFlipFlop(_flipFlopWithClockFactory, _inverterFactory);
    }

    public EdgeTriggeredDtypeFlipFlop[] CreateArray(int count)
    {
        var flipFlops = new EdgeTriggeredDtypeFlipFlop[count];

        for (int i = 0; i < count; i++)
        {
            flipFlops[i] = Create();
        }

        return flipFlops;
    }
}
