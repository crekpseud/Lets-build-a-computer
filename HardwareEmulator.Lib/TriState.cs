namespace HardwareEmulator.Lib;

public enum TriStateOutput
{
    Zero,
    One,
    None
}

public class TriState
{
    private bool _input;
    private bool _enable;

    public void SetInputs(bool enable, bool input)
    {
        _enable = enable;
        _input = input;
    }

    public TriStateOutput GetOutput()
    {
        if (_enable)
        {
            return _input ? TriStateOutput.One : TriStateOutput.Zero;
        }

        return TriStateOutput.None;
    }
}
