using HardwareEmulator.Lib.Factories;

namespace HardwareEmulator.Lib.LogicGates;

public class Inverter
{
    private readonly Relay _relay;

    public event Action<bool> OnStateChange;

    public Inverter(IRelayFactory relayFactory)
    {
        _relay = relayFactory.Create(true);
        _relay.OnStateChange += OnRelayStateChange;
    }

    private void OnRelayStateChange(bool relayState)
    {
        OnStateChange?.Invoke(GetOutput());
    }

    public void SetInput(bool bit)
    {
        if (bit)
        {
            _relay.EnergyOn();
        }
        else
        {
            _relay.EnergyOff();
        }
    }

    public bool GetOutput()
    {
        return _relay.IsEnergized;
    }
}
