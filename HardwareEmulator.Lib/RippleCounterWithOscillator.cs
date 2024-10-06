using HardwareEmulator.Lib.Factories;

namespace HardwareEmulator.Lib;
public class RippleCounterWithOscillator
{
    private readonly RippleCounter _rippleCounter;
    private readonly Oscillator _oscillator;

    public RippleCounterWithOscillator(
        int numberOfBits,
        IRippleCounterFactory rippleCounterFactory, 
        IOscillatorFactory oscillatorFactory)
    {
        _rippleCounter = rippleCounterFactory.Create(numberOfBits);
        _oscillator = oscillatorFactory.Create();
        _oscillator.OnStateChange += OnOscillatorStateChange;
        _rippleCounter.SetInput(_oscillator.GetOutput());
    }

    public void OnOscillatorStateChange(bool oscillatorOutput)
    {
        _rippleCounter.SetInput(oscillatorOutput);
    }

    public void Count(int numberOfOscillations)
    {
        _oscillator.Start(numberOfOscillations);
    }

    public int GetOutput()
    {
        return _rippleCounter.GetOutput();
    }
}
