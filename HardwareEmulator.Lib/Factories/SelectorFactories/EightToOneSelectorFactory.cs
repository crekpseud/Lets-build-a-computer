using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Selectors;

namespace HardwareEmulator.Lib.Factories.SelectorFactories;

public interface IEightToOneSelectorFactory
{
    public EightToOneSelector Create();
}
public class EightToOneSelectorFactory : IEightToOneSelectorFactory
{
    private readonly IOrGateFactory _orGateFactory;
    private readonly IAndGateFactory _andGateFactory;
    private readonly IInverterFactory _inverterFactory;

    public EightToOneSelectorFactory(
        IOrGateFactory orGateFactory, 
        IAndGateFactory andGateFactory, 
        IInverterFactory inverterFactory)
    {
        _orGateFactory = orGateFactory;
        _andGateFactory = andGateFactory;
        _inverterFactory = inverterFactory;
    }

    public EightToOneSelector Create()
    {
        return new EightToOneSelector(_orGateFactory, _andGateFactory, _inverterFactory);
    }
}
