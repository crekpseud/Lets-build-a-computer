using HardwareEmulator.Lib.Adders;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface ISixteenBitAdderFactory
{
    public SixteenBitAdder Create();
}

public class SixteenBitAdderFactory : ISixteenBitAdderFactory
{
    private readonly IEightBitAdderFactory _eightBitAdderFactory;

    public SixteenBitAdderFactory(IEightBitAdderFactory eightBitAdderFactory)
    {
        _eightBitAdderFactory = eightBitAdderFactory;
    }

    public SixteenBitAdder Create()
    {
        return new SixteenBitAdder(_eightBitAdderFactory);
    }
}
