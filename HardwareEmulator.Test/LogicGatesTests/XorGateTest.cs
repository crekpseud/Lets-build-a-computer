using HardwareEmulator.Lib.LogicGates;
using FluentAssertions;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HardwareEmulator.Test.LogicGatesTests;

public class XorGateTest : ScopedTest
{
    private readonly XorGate _xorGate;

    public XorGateTest(DependencyInjectionFixture fixture, ITestOutputHelper output)
        : base(fixture)
    {
        var xorGateFactory = Scope.ServiceProvider.GetRequiredService<IXorGateFactory>();

        _xorGate = xorGateFactory.Create(2);
    }

    [Fact]
    public void SetInputTest()
    {
        _xorGate.GetOutput().Should().BeFalse();

        _xorGate.SetInput(1, true);

        _xorGate.GetOutput().Should().BeTrue();

        _xorGate.SetInput(0, true);

        _xorGate.GetOutput().Should().BeFalse();

        _xorGate.SetInput(0, false);

        _xorGate.GetOutput().Should().BeTrue();
    }
}
