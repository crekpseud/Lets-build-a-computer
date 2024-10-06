using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Adders;

public class HalfAdder
{
    private readonly XorGate _xorGate;

    private readonly AndGate _andGate;

    public HalfAdder(IXorGateFactory xorGateFactory, IAndGateFactory andGateFactory)
    {
        _xorGate = xorGateFactory.Create(2);
        _andGate = andGateFactory.Create(2);
    }

    public void SetInputs(bool bit1, bool bit2)
    {
        _xorGate.SetInput(0, bit1);
        _xorGate.SetInput(1, bit2);

        _andGate.SetInput(0, bit1);
        _andGate.SetInput(1, bit2);
    }

    public bool GetSumOut()
    {
        return _xorGate.GetOutput();
    }

    public bool GetCarryOut()
    {
        return _andGate.GetOutput();
    }
}
