using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib;

public class FrequencyDivider
{
    private readonly Oscillator _oscillator;
    private readonly EdgeTriggeredDtypeFlipFlop _flipFlop;

    public FrequencyDivider(IOscillatorFactory oscillatorFactory, IEdgeTriggeredDtypeFlipFlopFactory flipFlopFactory)
    {
        _oscillator = oscillatorFactory.Create();

        _flipFlop = flipFlopFactory.Create();

        _oscillator.OnStateChange += OnOscillatorStateChange;
    }

    public void OnOscillatorStateChange(bool oscillatorOutput)
    {
        _flipFlop.SetInputs(oscillatorOutput, _flipFlop.GetQbarOutput());
    }

    public void Start(int numberOfOscillations)
    {
        _oscillator.Start(numberOfOscillations);
    }

    public bool GetOutput()
    {
        return _flipFlop.GetQOutput();
    }
}
