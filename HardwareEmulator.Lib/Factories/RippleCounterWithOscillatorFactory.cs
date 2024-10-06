namespace HardwareEmulator.Lib.Factories;

public interface IRippleCounterWithOscillatorFactory
{
    public RippleCounterWithOscillator Create(int numberOfBits);
}

public class RippleCounterWithOscillatorFactory : IRippleCounterWithOscillatorFactory
{
    private readonly IRippleCounterFactory _rippleCounterFactory;
    private readonly IOscillatorFactory _oscillatorFactory;

    public RippleCounterWithOscillatorFactory(
        IRippleCounterFactory rippleCounterFactory,
        IOscillatorFactory oscillatorFactory)
    {
        _rippleCounterFactory = rippleCounterFactory;
        _oscillatorFactory = oscillatorFactory;
    }

    public RippleCounterWithOscillator Create(int numberOfBits)
    {
        return new RippleCounterWithOscillator(
            numberOfBits,
            _rippleCounterFactory,
            _oscillatorFactory);
    }
}
