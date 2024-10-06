using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;

namespace HardwareEmulator.Lib;

public class OnesComplement
{
    private readonly XorGate[] _xorGates;

    public OnesComplement(IXorGateFactory xorGateFactory)
    {
        _xorGates = xorGateFactory.CreateArray(8, 2);
    }

    public void SetInputs(bool invert, bool[] inputs)
    {
        for (var i = 0; i < _xorGates.Length; i++)
        {
            _xorGates[i].SetInputs([invert, inputs[i]]);
        }
    }

    public bool[] GetOutputs()
    {
        var res = new bool[_xorGates.Length];

        for (var i = 0; i < _xorGates.Length; i++)
        {
            res[i] = _xorGates[i].GetOutput();
        }

        return res;
    }
}
