using FluentAssertions;
using HardwareEmulator.Lib;
using HardwareEmulator.Lib.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test;

public class RelayTest : ScopedTest
{
    private readonly Relay _relay1;

    private readonly Relay _relay2;

    public RelayTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var relayFactory = Scope.ServiceProvider.GetRequiredService<IRelayFactory>();

        _relay1 = relayFactory.Create(true);

        _relay2 = relayFactory.Create(false);
    }

    [Fact]
    public void EnergyOn()
    {
        _relay1.EnergyOn();
        _relay1.IsEnergized.Should().BeFalse();

        _relay2.EnergyOn();
        _relay2.IsEnergized.Should().BeTrue();
    }

    [Fact]
    public void EnergyOff()
    {
        _relay1.EnergyOff();
        _relay1.IsEnergized.Should().BeTrue();

        _relay2.EnergyOff();
        _relay2.IsEnergized.Should().BeFalse();
    }
}