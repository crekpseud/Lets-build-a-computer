using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;

public class RAM256x8 : IRAMArray
{
    private readonly FourToSixteenDecoder _decoder;
    private readonly RAM16x8[] _ramArr;
    private readonly AndGate[] _writeAndGateArr;
    private readonly AndGate[] _enableAndGateArr;

    public RAM256x8(
        IFourToSixteenDecoderFactory decoderFactory,
        IRAM16x8Factory ramFactory,
        IAndGateFactory andGateFactory)
    {
        _decoder = decoderFactory.Create();
        _ramArr = ramFactory.CreateArray(16);
        _writeAndGateArr = andGateFactory.CreateArray(16, 2);
        _enableAndGateArr = andGateFactory.CreateArray(16, 2);
    }

    public void Write(int address, byte data)
    {
        var boolArrAddress = Utils.Converter.IntToBoolArray(address, 8);

        var boolArrData = Utils.Converter.ByteToBoolArray(data);

        Write(boolArrAddress, boolArrData);
    }

    public void Write(bool[] address, bool[] data)
    {
        SetInputs(false, address, true, data);

        SetInputs(false, address, false, data);
    }

    public byte? Read(int address)
    {
        var boolArrAddress = Utils.Converter.IntToBoolArray(address, 8);

        var output = Read(boolArrAddress);

        return output == null ? null : Utils.Converter.BoolArrayToByte(output);
    }

    public bool[]? Read(bool[] address)
    {
        SetInputs(true, address, false, new bool[8]);
        return GetOutputs();
    }

    public void SetInputs(bool enable, bool[] address, bool write, bool[] data)
    {
        _decoder.SetInputs(address[3], address[2], address[1], address[0]);

        var decoderOutputs = _decoder.GetOutput();

        for (int i = 0; i < decoderOutputs.Length; i++)
        {
            _writeAndGateArr[i].SetInputs([decoderOutputs[i], write]);

            _enableAndGateArr[i].SetInputs([decoderOutputs[i], enable]);

            _ramArr[i].SetInputs(
                _enableAndGateArr[i].GetOutput(),
                [address[7], address[6], address[5], address[4]],
                _writeAndGateArr[i].GetOutput(),
                data);
        }
    }

    public bool[]? GetOutputs()
    {
        bool[]? outputs = null;

        for (int i = 0; i < _ramArr.Length; i++)
        {
            outputs = _ramArr[i].GetOutputs();
            if (outputs != null)
            {
                return outputs;
            }
        }

        return outputs;
    }
}
