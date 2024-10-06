using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;

public class LevelTriggeredDtypeFlipFlop
{
    private readonly RSFlipFlop _rsFlipFlop;
    private readonly AndGate _firstAndGate;
    private readonly AndGate _secondAndGate;
    private readonly Inverter _inverter;

    public LevelTriggeredDtypeFlipFlop(
        IRSFlipFlopFactory rsFlipFlopFactory, 
        IAndGateFactory andGateFactory, 
        IInverterFactory inverterFactory)
    {
        _rsFlipFlop = rsFlipFlopFactory.Create();
        _firstAndGate = andGateFactory.Create(2);
        _secondAndGate = andGateFactory.Create(2);
        _inverter = inverterFactory.Create();
    }

    public void SetInputs(bool write, bool data)
    {
        _inverter.SetInput(data);
        _firstAndGate.SetInputs([_inverter.GetOutput(), write]);
        _secondAndGate.SetInputs([write, data]);
        _rsFlipFlop.SetInputs(_firstAndGate.GetOutput(), _secondAndGate.GetOutput());
    }

    public bool GetOutput()
    {
        return _rsFlipFlop.GetQOutput();
    }
}
