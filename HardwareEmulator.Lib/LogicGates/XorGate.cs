using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.LogicGates;

public class XorGate
{
    private readonly OrGate _orGate;

    private readonly NandGate _nandGate;

    private readonly AndGate _andGate;

    public XorGate(
        IAndGateFactory andGateFactory, 
        IOrGateFactory orGateFactory, 
        INandGateFactory nandGateFactory,
        int numberOfInputs)
    {
        _orGate = orGateFactory.Create(numberOfInputs);

        _nandGate = nandGateFactory.Create(numberOfInputs);

        _andGate = andGateFactory.Create(2);
    }

    public void SetInput(int index, bool bit)
    {
        _orGate.SetInput(index, bit);

        _nandGate.SetInput(index, bit);

        _andGate.SetInput(0, _orGate.GetOutput());

        _andGate.SetInput(1, _nandGate.GetOutput());
    }

    public void SetInputs(bool[] bits)
    {
        for (int i = 0; i < bits.Length; i++)
        {
            SetInput(i, bits[i]);
        }
    }

    public bool GetOutput()
    {
        return _andGate.GetOutput();
    }
}
