using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface ILevelTriggeredDtypeFlipFlopFactory
{
    public LevelTriggeredDtypeFlipFlop Create();

    public LevelTriggeredDtypeFlipFlop[] CreateArray(int count);

    public LevelTriggeredDtypeFlipFlop[,] CreateFlipFlopGrid(int numberOfRows, int numberOfColumns);
}

public class LevelTriggeredDtypeFlipFlopFactory : ILevelTriggeredDtypeFlipFlopFactory
{
    private readonly IRSFlipFlopFactory _rsFlipFlopFactory;
    private readonly IAndGateFactory _andGateFactory;
    private readonly IInverterFactory _inverterFactory;

    public LevelTriggeredDtypeFlipFlopFactory(
        IRSFlipFlopFactory rsFlipFlopFactory,
        IAndGateFactory andGateFactory,
        IInverterFactory inverterFactory)
    {
        _rsFlipFlopFactory = rsFlipFlopFactory;
        _andGateFactory = andGateFactory;
        _inverterFactory = inverterFactory;
    }

    public LevelTriggeredDtypeFlipFlop Create()
    {
        return new LevelTriggeredDtypeFlipFlop(_rsFlipFlopFactory, _andGateFactory, _inverterFactory);
    }

    public LevelTriggeredDtypeFlipFlop[] CreateArray(int count)
    {
        var flipFlops = new LevelTriggeredDtypeFlipFlop[count];

        for (int i = 0; i < count; i++)
        {
            flipFlops[i] = Create();
        }

        return flipFlops;
    }

    public LevelTriggeredDtypeFlipFlop[,] CreateFlipFlopGrid(int numberOfRows, int numberOfColumns)
    {
        var flipFlopGrid = new LevelTriggeredDtypeFlipFlop[numberOfRows, numberOfColumns];

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                flipFlopGrid[i, j] = Create();
            }
        }

        return flipFlopGrid;
    }
}
