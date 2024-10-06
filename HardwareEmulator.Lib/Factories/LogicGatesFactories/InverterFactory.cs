using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Factories.LogicGatesFactories;

public interface IInverterFactory
{
    public Inverter Create();

    public Inverter[] CreateArray(int count);
}

public class InverterFactory : IInverterFactory
{
    private readonly IRelayFactory _relayFactory;

    public InverterFactory(IRelayFactory relayFactory)
    {
        _relayFactory = relayFactory;
    }

    public Inverter Create()
    {
        return new Inverter(_relayFactory);
    }

    public Inverter[] CreateArray(int count)
    {
        var inverters = new Inverter[count];

        for (int i = 0; i < count; i++)
        {
            inverters[i] = Create();
        }

        return inverters;
    }
}
