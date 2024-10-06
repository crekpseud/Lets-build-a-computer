using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;

public class RSFlipFlop
{
    private readonly NorGate _firstNorGate;

    private readonly NorGate _secondNorGate;

    public RSFlipFlop(INorGateFactory norGateFactory)
    {
        _firstNorGate = norGateFactory.Create(2);

        _secondNorGate = norGateFactory.Create(2);

        _firstNorGate.SetInputs([false, _secondNorGate.GetOutput()]);

        _secondNorGate.SetInputs([_firstNorGate.GetOutput(), false]);
    }

    public void SetInputs(bool reset, bool set)
    {
        if (_firstNorGate.GetOutput())
        {
            _firstNorGate.SetInputs([reset, _secondNorGate.GetOutput()]);
            _secondNorGate.SetInputs([_firstNorGate.GetOutput(), set]);
        }
        else
        {
            _secondNorGate.SetInputs([_firstNorGate.GetOutput(), set]);
            _firstNorGate.SetInputs([reset, _secondNorGate.GetOutput()]);
        }
    }

    public bool GetQOutput()
    {
        return _firstNorGate.GetOutput();
    }

    public bool GetQbarOutput()
    {
        return _secondNorGate.GetOutput();
    }
}
