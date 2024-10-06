using HardwareEmulator.Lib.Factories;

namespace HardwareEmulator.Lib;
public class TriStateBuffer
{
    private readonly TriState[] _triStateArr;

    private bool _enabled;

    public TriStateBuffer(int numberOfElements, ITriStateFactory triStateFactory)
    {
        _triStateArr = triStateFactory.CreateArray(numberOfElements);
    }

    public void SetInputs(bool enable, byte input)
    {
        var inputBoolArr = Utils.Converter.ByteToBoolArray(input);

        SetInputs(enable, inputBoolArr);
    }

    public void SetInputs(bool enable, bool[] input)
    {
        for (int i = 0; i < _triStateArr.Length; i++)
        {
            _triStateArr[i].SetInputs(enable, input[i]);
        }

        _enabled = enable;
    }

    public byte? GetOutputByte()
    {
        var output = GetOutputBoolArr();

        return output == null ? null : Utils.Converter.BoolArrayToByte(output);
    }

    public bool[]? GetOutputBoolArr()
    {
        if (!_enabled)
        {
            return null;
        }

        var output = new bool[8];

        for (int i = 0; i < _triStateArr.Length; i++)
        {
            output[i] = _triStateArr[i].GetOutput() == TriStateOutput.One;
        }

        return output;
    }
}
