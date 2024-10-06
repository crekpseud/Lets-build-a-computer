using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface IHalfAdderFactory
{
    public HalfAdder Create();
}

public class HalfAdderFactory : IHalfAdderFactory
{
    private readonly IXorGateFactory _xorGateFactory;
    private readonly IAndGateFactory _andGateFactory;

    private int _count = 0;

    public HalfAdderFactory(IXorGateFactory xorGateFactory, IAndGateFactory andGateFactory)
    {
        _xorGateFactory = xorGateFactory;
        _andGateFactory = andGateFactory;
    }

    public HalfAdder Create()
    {
        _count++;
        return new HalfAdder(_xorGateFactory, _andGateFactory);
    }
}
