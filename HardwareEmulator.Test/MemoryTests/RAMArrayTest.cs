using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Factories;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;
using FluentAssertions;

namespace HardwareEmulator.Test.MemoryTests;

public class RAMArrayTest : ScopedTest
{
    private readonly IRAMArrayFactory _ramArrayFactory;

    private readonly ITestOutputHelper _output;
    private readonly IRelayFactory _relayFactory;

    public RAMArrayTest(DependencyInjectionFixture fixture, ITestOutputHelper output) : base(fixture)
    {
        _ramArrayFactory = Scope.ServiceProvider.GetRequiredService<IRAMArrayFactory>();

        _relayFactory = Scope.ServiceProvider.GetRequiredService<IRelayFactory>();

        _output = output;
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    public void Test(int order)
    {
        var ram = _ramArrayFactory.Create(order);

        ram.Write(0b_0000_0000, 0b_0100_0000);

        ram.Read(0b_0000_0000).Should().Be(0b_0100_0000);

        ram.Write(0b_0001_0000, 0b_1000_0000);

        ram.Read(0b_0000_0000).Should().Be(0b_0100_0000);

        ram.Read(0b_0001_0000).Should().Be(0b_1000_0000);

        ram.Write(0b_0000_0000, 0b_1111_1111);

        ram.Read(0b_0000_0000).Should().Be(0b_1111_1111);

        _output.WriteLine($"RAM{Math.Pow(16,order)}x8 number of relays: {_relayFactory.RelayCount}");
    }
}
