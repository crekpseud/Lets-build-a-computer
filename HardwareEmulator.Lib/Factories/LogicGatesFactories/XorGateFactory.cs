using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Factories.LogicGatesFactories;

public interface IXorGateFactory
{
    public XorGate Create(int numberOfInputs);

    public XorGate[] CreateArray(int count, int numberOfInputs);
}

public class XorGateFactory : IXorGateFactory
{
    private readonly IAndGateFactory _andGateFactory;
    private readonly IOrGateFactory _orGateFactory;
    private readonly INandGateFactory _nandGateFactory;

    public XorGateFactory(
        IAndGateFactory andGateFactory, 
        IOrGateFactory orGateFactory, 
        INandGateFactory nandGateFactory)
    {
        _andGateFactory = andGateFactory;
        _orGateFactory = orGateFactory;
        _nandGateFactory = nandGateFactory;
    }

    public XorGate Create(int numberOfInputs)
    {
        return new XorGate(_andGateFactory, _orGateFactory, _nandGateFactory, numberOfInputs);
    }

    public XorGate[] CreateArray(int count, int numberOfInputs)
    {
        var xorGates = new XorGate[count];

        for (int i = 0; i < count; i++)
        {
            xorGates[i] = Create(numberOfInputs);
        }

        return xorGates;
    }
}
