using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;
using System.Collections;

namespace HardwareEmulator.Lib.Decoders;
public class ThreeToEightDecoder
{
    private readonly AndGate[] _andGateArr;
    private readonly Inverter[] _inverterArr;

    public ThreeToEightDecoder(IAndGateFactory andGateFactory, IInverterFactory inverterFactory)
    {
        _inverterArr = inverterFactory.CreateArray(3);
        _andGateArr = andGateFactory.CreateArray(8, 4);
    }

    public void SetInputs(bool write, bool s0, bool s1, bool s2)
    {
        _inverterArr[0].SetInput(s0);
        _inverterArr[1].SetInput(s1);
        _inverterArr[2].SetInput(s2);

        for (int i = 0; i < _andGateArr.Length; i++)
        {
            var inputsToInvert = new BitArray(new[] { i }).Cast<bool>().ToArray();

            _andGateArr[i].SetInputs([write, 
                inputsToInvert[0] ? _inverterArr[0].GetOutput() : s0,
                inputsToInvert[1] ? _inverterArr[1].GetOutput() : s1,
                inputsToInvert[2] ? _inverterArr[2].GetOutput() : s2]);
        }
    }

    public bool[] GetOutput()
    {
        var output = new bool[8];

        for (int i = 0; i < 8; i++)
        {
            output[i] = _andGateArr[i].GetOutput();
        }

        return output;
    }
}
