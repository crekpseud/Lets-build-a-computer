using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Factories.LogicGatesFactories;

public interface IAndGateFactory
{
    public AndGate Create(int numberOfInputs);

    public AndGate[] CreateArray(int count, int numberOfInputs);
}

public class AndGateFactory : IAndGateFactory
{
    private readonly IRelayFactory _relayFactory;

    public AndGateFactory(IRelayFactory relayFactory)
    {
        _relayFactory = relayFactory;
    }

    public AndGate Create(int numberOfInputs)
    {
        return new AndGate(_relayFactory, numberOfInputs);
    }

    public AndGate[] CreateArray(int count, int numberOfInputs)
    {
        var andGates = new AndGate[count];

        for (int i = 0; i < count; i++)
        {
            andGates[i] = Create(numberOfInputs);
        }

        return andGates;
    }
}
