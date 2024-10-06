using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories.AddersFactories;

public interface IFullAdderFactory
{
    public FullAdder Create();

    public FullAdder[] CreateArray(int count);
}

public class FullAdderFactory : IFullAdderFactory
{
    private readonly IHalfAdderFactory _halfAdderFactory;
    private readonly IOrGateFactory _orGateFactory;

    public FullAdderFactory(IHalfAdderFactory halfAdderFactory, IOrGateFactory orGateFactory)
    {
        _halfAdderFactory = halfAdderFactory;
        _orGateFactory = orGateFactory;
    }

    public FullAdder Create()
    {
        return new FullAdder(_halfAdderFactory, _orGateFactory);
    }

    public FullAdder[] CreateArray(int count)
    {
        var fullAdders = new FullAdder[count];

        for (int i = 0; i < count; i++)
        {
            fullAdders[i] = Create();
        }

        return fullAdders;
    }
}