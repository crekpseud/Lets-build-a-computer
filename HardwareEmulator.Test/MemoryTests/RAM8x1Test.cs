using FluentAssertions;
using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Memory;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HardwareEmulator.Test.MemoryTests;

public class RAM8x1Test : ScopedTest
{
    private readonly RAM8x1 _ram;

    private readonly ITestOutputHelper _output;
    private readonly IRelayFactory _relayFactory;

    public RAM8x1Test(DependencyInjectionFixture fixture, ITestOutputHelper output) : base(fixture)
    {
        var ramFactory = Scope.ServiceProvider.GetRequiredService<IRAM8x1Factory>();

        _ram = ramFactory.Create();

        _relayFactory = Scope.ServiceProvider.GetRequiredService<IRelayFactory>();

        _output = output;
    }

    [Fact]
    public void Test()
    {
        _ram.Write(0b_000, true);

        _ram.Read(0b_000).Should().BeTrue();

        _ram.Read(0b_101).Should().BeFalse();

        _ram.Write(0b_101, true);

        _ram.Read(0b_101).Should().BeTrue();

        _ram.Read(0b_000).Should().BeTrue();

        _ram.Write(0b_101, false);

        _ram.Read(0b_101).Should().BeFalse();

        _output.WriteLine($"RAM8x1 number of relays: {_relayFactory.RelayCount}");
    }
}
