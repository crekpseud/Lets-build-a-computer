using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib.Memory;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Xunit.Abstractions;

namespace HardwareEmulator.Test.MemoryTests;
public class RAM256x8Test : ScopedTest
{
    private readonly RAM256x8 _ram;

    private readonly ITestOutputHelper _output;
    private readonly IRelayFactory _relayFactory;

    public RAM256x8Test(DependencyInjectionFixture fixture, ITestOutputHelper output) : base(fixture)
    {
        var ramFactory = Scope.ServiceProvider.GetRequiredService<IRAM256x8Factory>();

        _ram = ramFactory.Create();

        _relayFactory = Scope.ServiceProvider.GetRequiredService<IRelayFactory>();

        _output = output;
    }

    [Fact]
    public void Test()
    {
        _ram.Write(0b_0000_0000, 0b_0100_0000);

        _ram.Read(0b_0000_0000).Should().Be(0b_0100_0000);

        _ram.Write(0b_0001_0000, 0b_1000_0000);

        _ram.Read(0b_0000_0000).Should().Be(0b_0100_0000);

        _ram.Read(0b_0001_0000).Should().Be(0b_1000_0000);

        _ram.Write(0b_0000_0000, 0b_1111_1111);

        _ram.Read(0b_0000_0000).Should().Be(0b_1111_1111);

        _output.WriteLine($"RAM256x8 number of relays: {_relayFactory.RelayCount}");
    }
}
