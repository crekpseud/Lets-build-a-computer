using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;

public class FlipFlopWithClock
{
    private RSFlipFlop _rsFlipFlop;

    private AndGate _firstAndGate;

    private AndGate _secondAndGate;

    public FlipFlopWithClock(IRSFlipFlopFactory rsFlipFlopFactory, IAndGateFactory andGatefactory)
    {
        _rsFlipFlop = rsFlipFlopFactory.Create();

        _firstAndGate = andGatefactory.Create(2);

        _secondAndGate = andGatefactory.Create(2);

        _rsFlipFlop.SetInputs(_firstAndGate.GetOutput(), _secondAndGate.GetOutput());
    }

    public void SetInputs(bool reset, bool clock, bool set)
    {
        _firstAndGate.SetInputs([reset, clock]);

        _secondAndGate.SetInputs([clock, set]);

        _rsFlipFlop.SetInputs(_firstAndGate.GetOutput(), _secondAndGate.GetOutput());
    }

    public bool GetQOutput()
    {
        return _rsFlipFlop.GetQOutput();
    }

    public bool GetQbarOutput()
    {
        return _rsFlipFlop.GetQbarOutput();
    }
}
