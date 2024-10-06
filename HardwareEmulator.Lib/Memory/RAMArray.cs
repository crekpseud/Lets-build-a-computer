using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;

public interface IRAMArray
{
    public void Write(int address, byte data);

    public void Write(bool[] address, bool[] data);

    public byte? Read(int address);

    public bool[]? Read(bool[] address);

    public void SetInputs(bool enable, bool[] address, bool write, bool[] data);

    public bool[]? GetOutputs();
}

public class RAMArray : IRAMArray
{
    private readonly int _order;
    private readonly FourToSixteenDecoder _decoder;
    private readonly IRAMArray[] _ramArr;
    private readonly AndGate[] _writeAndGateArr;
    private readonly AndGate[] _enableAndGateArr;

    public RAMArray(
        int order,
        IFourToSixteenDecoderFactory decoderFactory,
        IRAMArray[] subArray,
        IAndGateFactory andGateFactory)
    {
        _order = order;
        _decoder = decoderFactory.Create();
        _ramArr = subArray;
        _writeAndGateArr = andGateFactory.CreateArray(16, 2);
        _enableAndGateArr = andGateFactory.CreateArray(16, 2);
    }

    public void Write(int address, byte data)
    {
        var boolArrAddress = Utils.Converter.IntToBoolArray(address, 4 * _order);

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
        var boolArrAddress = Utils.Converter.IntToBoolArray(address, 4 * _order);

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
                address.Skip(4).Reverse().ToArray(),
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
