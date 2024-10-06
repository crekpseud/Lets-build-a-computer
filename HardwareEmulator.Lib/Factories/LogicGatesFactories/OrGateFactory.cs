using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Factories.LogicGatesFactories;

public interface IOrGateFactory
{
    public OrGate Create(int numberOfInputs);
}

public class OrGateFactory : IOrGateFactory
{
    private readonly IRelayFactory _relayFactory;

    public OrGateFactory(IRelayFactory relayFactory)
    {
        _relayFactory = relayFactory;
    }

    public OrGate Create(int numberOfInputs)
    {
        return new OrGate(_relayFactory, numberOfInputs);
    }
}
