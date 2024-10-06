using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.LogicGates;
using HardwareEmulator.Lib.Memory;
using HardwareEmulator.Lib.Utils;

namespace HardwareEmulator.Lib;

public class RippleCounter
{
    private readonly EdgeTriggeredDtypeFlipFlop[] _flipFlopArr;
    private readonly Inverter _inverter;

    public RippleCounter(
        int numberOfBits,
        IEdgeTriggeredDtypeFlipFlopFactory flipFlopFactory,
        IInverterFactory inverterFactory)
    {
        _flipFlopArr = flipFlopFactory.CreateArray(numberOfBits - 1);
        _inverter = inverterFactory.Create();
        _inverter.SetInput(true);
    }

    public void SetInput(bool clock)
    {
        _inverter.SetInput(clock);

        for (int i = 0; i < _flipFlopArr.Length; i++)
        {
            if (i != 0)
            {
                _flipFlopArr[i].SetInputs(_flipFlopArr[i - 1].GetQbarOutput(), _flipFlopArr[i].GetQbarOutput());
            }
            else
            {
                _flipFlopArr[i].SetInputs(clock, _flipFlopArr[i].GetQbarOutput());
            }
        }
    }

    public int GetOutput()
    {
        var output = new bool[_flipFlopArr.Length + 1];

        var j = 0;
        for (int i = _flipFlopArr.Length - 1; i >= 0; i--)
        {
            output[j] = _flipFlopArr[i].GetQOutput();
            j++;
        }

        output[_flipFlopArr.Length] = _inverter.GetOutput();

        return Converter.BoolArrayToInt(output);
    }
}
