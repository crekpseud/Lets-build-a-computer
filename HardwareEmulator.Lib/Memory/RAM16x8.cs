using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib.Memory;
public class RAM16x8 : IRAMArray
{
    private readonly FourToSixteenDecoder _decoder;
    private readonly LevelTriggeredDtypeFlipFlop[,] _flipFlopGrid;
    private readonly AndGate[] _andGateArr;
    private readonly TriState[,] _triStateGrid;
    private readonly TriStateBuffer _triStateBuffer;

    public RAM16x8(
        IFourToSixteenDecoderFactory decoderFactory,
        ILevelTriggeredDtypeFlipFlopFactory flipFlopFactory,
        IAndGateFactory andGateFactory,
        ITriStateFactory triStateFactory,
        ITriStateBufferFactory triStateBufferFactory)
    {
        _decoder = decoderFactory.Create();
        _flipFlopGrid = flipFlopFactory.CreateFlipFlopGrid(16, 8);
        _andGateArr = andGateFactory.CreateArray(16, 2);
        _triStateGrid = triStateFactory.CreateGrid(16, 8);
        _triStateBuffer = triStateBufferFactory.Create(8);
    }

    public void Write(int address, byte data)
    {
        var boolArrAddress = Utils.Converter.IntToBoolArray(address, 4);

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
        var boolArrAddress = Utils.Converter.IntToBoolArray(address, 4);

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

        for (int i = 0; i < 16; i++)
        {
            _andGateArr[i].SetInputs([write, _decoder.GetOutput()[i]]);
        }

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _flipFlopGrid[i, j].SetInputs(_andGateArr[15 - i].GetOutput(), data[j]);
                _triStateGrid[i, j].SetInputs(_decoder.GetOutput()[15 - i], _flipFlopGrid[i, j].GetOutput());
            }
        }

        var triStateBufferInputs = new bool[8];

        for (int column = 0; column < 8; column++)
        {
            var triStatesAccumulatedOutput = TriStateOutput.None;

            for (int row = 0; row < 16; row++)
            {
                if (_triStateGrid[row, column].GetOutput() != TriStateOutput.None
                    && triStatesAccumulatedOutput != TriStateOutput.None)
                {
                    throw new Exception("Several tri-state elements have same output at the same time");
                }

                triStatesAccumulatedOutput = triStatesAccumulatedOutput == TriStateOutput.One
                    ? triStatesAccumulatedOutput
                    : _triStateGrid[row, column].GetOutput();
            }

            triStateBufferInputs[column] = triStatesAccumulatedOutput == TriStateOutput.One;
        }

        _triStateBuffer.SetInputs(enable, triStateBufferInputs);
    }

    public bool[]? GetOutputs()
    {
        return _triStateBuffer.GetOutputBoolArr();
    }
}
