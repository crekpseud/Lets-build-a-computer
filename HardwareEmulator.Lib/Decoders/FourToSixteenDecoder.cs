using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;
using System.Collections;

namespace HardwareEmulator.Lib.Decoders;

public class FourToSixteenDecoder
{
    private readonly AndGate[] _andGateArr;
    private readonly Inverter[] _inverterArr;

    public FourToSixteenDecoder(IAndGateFactory andGateFactory, IInverterFactory inverterFactory)
    {
        _inverterArr = inverterFactory.CreateArray(4);
        _andGateArr = andGateFactory.CreateArray(16, 4);
    }

    public void SetInputs(bool a0, bool a1, bool a2, bool a3)
    {
        _inverterArr[0].SetInput(a0);
        _inverterArr[1].SetInput(a1);
        _inverterArr[2].SetInput(a2);
        _inverterArr[3].SetInput(a3);

        for (int i = 0; i < _andGateArr.Length; i++)
        {
            var inputsToInvert = new BitArray(new[] { i }).Cast<bool>().ToArray();

            _andGateArr[i].SetInputs([
                inputsToInvert[0] ? _inverterArr[0].GetOutput() : a0,
                inputsToInvert[1] ? _inverterArr[1].GetOutput() : a1,
                inputsToInvert[2] ? _inverterArr[2].GetOutput() : a2,
                inputsToInvert[3] ? _inverterArr[3].GetOutput() : a3]);
        }
    }

    public bool[] GetOutput()
    {
        var output = new bool[16];

        for (int i = 0; i < 16; i++)
        {
            output[i] = _andGateArr[i].GetOutput();
        }

        return output;
    }

    public ushort GetOutputShort()
    {
        var output = GetOutput();

        return Utils.Converter.BoolArrayToShort(output);
    }
}
