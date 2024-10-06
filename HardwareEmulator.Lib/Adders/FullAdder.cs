using HardwareEmulator.Lib.Factories.AddersFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Adders;

public class FullAdder
{
    private readonly HalfAdder _halfAdder1;

    private readonly HalfAdder _halfAdder2;

    private readonly OrGate _orGate;

    public FullAdder(IHalfAdderFactory halfAdderFactory, IOrGateFactory orGateFactory)
    {
        _halfAdder1 = halfAdderFactory.Create();
        _halfAdder2 = halfAdderFactory.Create();
        _orGate = orGateFactory.Create(2);
    }

    public void SetInputs(bool carryIn, bool aIn, bool bIn)
    {
        _halfAdder1.SetInputs(aIn, bIn);

        _halfAdder2.SetInputs(carryIn, _halfAdder1.GetSumOut());

        _orGate.SetInputs([_halfAdder2.GetCarryOut(), _halfAdder1.GetCarryOut()]);
    }

    public bool GetSumOut()
    {
        return _halfAdder2.GetSumOut();
    }

    public bool GetCarryOut()
    {
        return _orGate.GetOutput();
    }
}
