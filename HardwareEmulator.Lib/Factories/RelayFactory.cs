namespace HardwareEmulator.Lib.Factories;

public interface IRelayFactory
{
    public Relay Create(bool normallyOpenContactIsOutput);

    public Relay[] CreateArray(bool normallyOpenContactIsOutput, int count);

    public int RelayCount { get; }
}

public class RelayFactory : IRelayFactory
{
    private int _count;

    public Relay Create(bool normallyOpenContactIsOutput)
    {
        _count++;
        return new Relay(normallyOpenContactIsOutput);
    }

    public Relay[] CreateArray(bool normallyOpenContactIsOutput, int count)
    {
        var relays = new Relay[count];

        for (int i = 0; i < count; i++)
        {
            relays[i] = Create(normallyOpenContactIsOutput);
        }

        return relays;
    }

    public int RelayCount => _count;
}
