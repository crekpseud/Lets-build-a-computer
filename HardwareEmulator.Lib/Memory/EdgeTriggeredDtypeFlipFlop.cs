using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;

public class EdgeTriggeredDtypeFlipFlop
{
    private readonly FlipFlopWithClock _firstFlipFlopWithClock;
    private readonly FlipFlopWithClock _secondFlipFlopWithClock;
    private readonly Inverter _firstInverter;
    private readonly Inverter _secondInverter;

    public EdgeTriggeredDtypeFlipFlop(
        IFlipFlopWithClockFactory flipFlopWithClockFactory,
        IInverterFactory inverterFactory)
    {
        _firstFlipFlopWithClock = flipFlopWithClockFactory.Create();
        _secondFlipFlopWithClock = flipFlopWithClockFactory.Create();
        _firstInverter = inverterFactory.Create();
        _secondInverter = inverterFactory.Create();

        _firstFlipFlopWithClock.SetInputs(false, _firstInverter.GetOutput(), _secondInverter.GetOutput());
        _secondFlipFlopWithClock.SetInputs(_firstFlipFlopWithClock.GetQOutput(), false, _secondFlipFlopWithClock.GetQbarOutput());
    }

    public void SetInputs(bool clock, bool data)
    {
        _firstInverter.SetInput(clock);
        _secondInverter.SetInput(data);

        _firstFlipFlopWithClock.SetInputs(data, _firstInverter.GetOutput(), _secondInverter.GetOutput());
        _secondFlipFlopWithClock.SetInputs(_firstFlipFlopWithClock.GetQOutput(), clock, _firstFlipFlopWithClock.GetQbarOutput());
    }

    public bool GetQOutput()
    {
        return _secondFlipFlopWithClock.GetQOutput();
    }

    public bool GetQbarOutput()
    {
        return _secondFlipFlopWithClock.GetQbarOutput();
    }
}
