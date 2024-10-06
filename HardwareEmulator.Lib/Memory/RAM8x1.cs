using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Factories.SelectorFactories;
using HardwareEmulator.Lib.Selectors;

namespace HardwareEmulator.Lib.Memory;

public class RAM8x1
{
    private readonly ThreeToEightDecoder _decoder;
    private readonly LevelTriggeredDtypeFlipFlop[] _flipFlopArr;
    private readonly EightToOneSelector _selector;

    public RAM8x1(
        IThreeToEightDecoderFactory decoderFactory,
        ILevelTriggeredDtypeFlipFlopFactory flipFlopFactory,
        IEightToOneSelectorFactory selectorFactory)
    {
        _decoder = decoderFactory.Create();
        _flipFlopArr = flipFlopFactory.CreateArray(8);
        _selector = selectorFactory.Create();
    }

    public void Write(byte address, bool data)
    {
        var boolArrAddress = Utils.Converter.ByteToBoolArray(address, 3);

        Write(boolArrAddress, data);
    }

    public void Write(bool[] address, bool data)
    {
        SetInputs(address, true, data);

        SetInputs(address, false, data);
    }

    public bool Read(byte address)
    {
        var boolArrAddress = Utils.Converter.ByteToBoolArray(address, 3);

        return Read(boolArrAddress);
    }

    public bool Read(bool[] address)
    {
        SetInputs(address, false, false);
        return GetOutput();
    }

    private void SetInputs(bool[] address, bool write, bool data)
    {
        _decoder.SetInputs(write, address[2], address[1], address[0]);

        var flipFlopOutputs = new bool[8];
        for (int i = 0; i < _flipFlopArr.Length; i++)
        {
            _flipFlopArr[i].SetInputs(_decoder.GetOutput()[i], data);
            flipFlopOutputs[i] = _flipFlopArr[i].GetOutput();
        }

        _selector.SetInputs(address[2], address[1], address[0], flipFlopOutputs);
    }

    private bool GetOutput()
    {
        return _selector.GetOutput();
    }
}
