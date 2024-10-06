using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;

namespace HardwareEmulator.Lib.Factories;

public interface IRippleCounterFactory
{
    public RippleCounter Create(int numberOfBits);
}

public class RippleCounterFactory : IRippleCounterFactory
{
    //private readonly IOscillatorFactory _oscillatorFactory;
    private readonly IEdgeTriggeredDtypeFlipFlopFactory _flipFlopFactory;
    private readonly IInverterFactory _inverterFactory;

    public RippleCounterFactory(
        //IOscillatorFactory oscillatorFactory,
        IEdgeTriggeredDtypeFlipFlopFactory flipFlopFactory,
        IInverterFactory inverterFactory)
    {
        //_oscillatorFactory = oscillatorFactory;
        _flipFlopFactory = flipFlopFactory;
        _inverterFactory = inverterFactory;
    }

    public RippleCounter Create(int numberOfBits)
    {
        return new RippleCounter(numberOfBits, /*_oscillatorFactory,*/ _flipFlopFactory, _inverterFactory);
    }
}
