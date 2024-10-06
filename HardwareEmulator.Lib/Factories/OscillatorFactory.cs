using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories;


public interface IOscillatorFactory
{
    public Oscillator Create();
}

public class OscillatorFactory : IOscillatorFactory
{
    private readonly IInverterFactory _inverterFactory;

    public OscillatorFactory(IInverterFactory inverterFactory)
    {
        _inverterFactory = inverterFactory;
    }

    public Oscillator Create()
    {
        return new Oscillator(_inverterFactory);
    }
}
