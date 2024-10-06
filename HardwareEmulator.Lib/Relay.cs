namespace HardwareEmulator.Lib;

public class Relay
{
    private readonly bool _normallyOpenContactIsOutput;

    public bool IsEnergized { get; private set; }

    public event Action<bool> OnStateChange;

    public Relay(bool normallyOpenContactIsOutput)
    {
        _normallyOpenContactIsOutput = normallyOpenContactIsOutput;
        IsEnergized = normallyOpenContactIsOutput;
    }

    public void EnergyOn()
    {
        IsEnergized = !_normallyOpenContactIsOutput;
        OnStateChange?.Invoke(IsEnergized);
    }

    public void EnergyOff()
    {
        IsEnergized = _normallyOpenContactIsOutput;
        OnStateChange?.Invoke(IsEnergized);
    }
}
