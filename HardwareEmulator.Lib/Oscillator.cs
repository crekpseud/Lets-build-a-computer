using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib;

public class Oscillator
{
    private readonly Inverter _inverter;

    private int _numberOfOscillations;
    private int _oscillationsCount;

    public event Action<bool> OnStateChange;

    public Oscillator(IInverterFactory inverterFactory)
    {
        _inverter = inverterFactory.Create();
        _inverter.OnStateChange += OnInverterStateChange;
    }

    public void OnInverterStateChange(bool inverterOutput)
    {
        _oscillationsCount++;

        OnStateChange?.Invoke(GetOutput());

        if (_oscillationsCount >= _numberOfOscillations)
        {
            return;
        }

        _inverter.SetInput(inverterOutput);
    }

    public void Start(int numberOfOscillations)
    {
        _oscillationsCount = 0;
        _numberOfOscillations = numberOfOscillations;
        _inverter.SetInput(_inverter.GetOutput());
    }

    public bool GetOutput()
    {
        return _inverter.GetOutput();
    }
}
