using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Factories.LogicGatesFactories;

public interface INandGateFactory
{
    public NandGate Create(int numberOfInputs);
}

public class NandGateFactory : INandGateFactory
{
    private readonly IRelayFactory _relayFactory;

    public NandGateFactory(IRelayFactory relayFactory)
    {
        _relayFactory = relayFactory;
    }

    public NandGate Create(int numberOfInputs)
    {
        return new NandGate(_relayFactory, numberOfInputs);
    }
}
