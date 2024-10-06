using HardwareEmulator.Lib.Factories.MemoryFactories;

namespace HardwareEmulator.Lib.Factories;

public interface IFrequencyDividerFactory
{
    public FrequencyDivider Create();

    public FrequencyDivider[] CreateArray(int count);
}

public class FrequencyDividerFactory : IFrequencyDividerFactory
{
    private readonly IOscillatorFactory _oscillatorFactory;
    private readonly IEdgeTriggeredDtypeFlipFlopFactory _flipFlopFactory;

    public FrequencyDividerFactory(IOscillatorFactory oscillatorFactory, IEdgeTriggeredDtypeFlipFlopFactory flipFlopFactory)
    {
        _oscillatorFactory = oscillatorFactory;
        _flipFlopFactory = flipFlopFactory;
    }

    public FrequencyDivider Create()
    {
        return new FrequencyDivider(_oscillatorFactory, _flipFlopFactory);
    }

    public FrequencyDivider[] CreateArray(int count)
    {
        var frequencyDividers = new FrequencyDivider[count];

        for (int i = 0; i < count; i++)
        {
            frequencyDividers[i] = Create();
        }

        return frequencyDividers;
    }
}
