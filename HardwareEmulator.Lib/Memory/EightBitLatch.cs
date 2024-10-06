using HardwareEmulator.Lib.Factories.MemoryFactories;

namespace HardwareEmulator.Lib.Memory;

public class EightBitLatch
{
    private readonly EdgeTriggeredDtypeFlipFlop[] _flipFlopArr;

    public EightBitLatch(IEdgeTriggeredDtypeFlipFlopFactory flipFlopFactory)
    {
        _flipFlopArr = flipFlopFactory.CreateArray(8);
    }

    public void SetInputs(bool clock, bool[] data)
    {
        for (int i = 0; i < _flipFlopArr.Length; i++)
        {
            _flipFlopArr[i].SetInputs(clock, data[i]);
        }
    }

    public bool[] GetOutputs()
    {
        var outputArr = new bool[_flipFlopArr.Length];

        for (int i = 0; i < _flipFlopArr.Length; i++)
        {
            outputArr[i] = _flipFlopArr[i].GetQOutput();
        }

        return outputArr;
    }

    public bool[] GetQOutputs()
    {
        var outputArr = new bool[_flipFlopArr.Length];

        for (int i = 0; i < _flipFlopArr.Length; i++)
        {
            outputArr[i] = _flipFlopArr[i].GetQbarOutput();
        }

        return outputArr;
    }
}
