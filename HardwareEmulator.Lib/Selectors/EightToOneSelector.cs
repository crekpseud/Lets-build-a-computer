using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;
using System.Collections;

namespace HardwareEmulator.Lib.Selectors;

public class EightToOneSelector
{
    private readonly OrGate _orGate;
    private readonly AndGate[] _andGateArr;
    private readonly Inverter[] _inverterArr;

    public EightToOneSelector(
        IOrGateFactory orGateFactory, 
        IAndGateFactory andGateFactory, 
        IInverterFactory inverterFactory)
    {
        _orGate = orGateFactory.Create(8);
        _andGateArr = andGateFactory.CreateArray(8, 4);
        _inverterArr = inverterFactory.CreateArray(3);
    }

    public void SetInputs(bool s0, bool s1, bool s2, bool[] data)
    {
        _inverterArr[0].SetInput(s0);
        _inverterArr[1].SetInput(s1);
        _inverterArr[2].SetInput(s2);

        for (int i = 0; i < _andGateArr.Length; i++)
        {
            var inputsToInvert = new BitArray(new[] { i }).Cast<bool>().ToArray();

            _andGateArr[i].SetInputs([data[i],
                inputsToInvert[0] ? _inverterArr[0].GetOutput() : s0,
                inputsToInvert[1] ? _inverterArr[1].GetOutput() : s1,
                inputsToInvert[2] ? _inverterArr[2].GetOutput() : s2]);
        }

        _orGate.SetInputs([
            _andGateArr[0].GetOutput(),
            _andGateArr[1].GetOutput(),
            _andGateArr[2].GetOutput(),
            _andGateArr[3].GetOutput(),
            _andGateArr[4].GetOutput(),
            _andGateArr[5].GetOutput(),
            _andGateArr[6].GetOutput(),
            _andGateArr[7].GetOutput()]);
    }

    public bool GetOutput()
    {
        return _orGate.GetOutput();
    }
}
