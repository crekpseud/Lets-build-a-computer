using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Factories.LogicGatesFactories;

public interface INorGateFactory
{
    public NorGate Create(int numberOfInputs);
}

public class NorGateFactory : INorGateFactory
{
    private readonly IRelayFactory _relayFactory;

    public NorGateFactory(IRelayFactory relayFactory)
    {
        _relayFactory = relayFactory;
    }

    public NorGate Create(int numberOfInputs)
    {
        return new NorGate(_relayFactory, numberOfInputs);
    }
}
