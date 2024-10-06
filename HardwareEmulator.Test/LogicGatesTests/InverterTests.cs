using FluentAssertions;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.LogicGatesTests;

public class InverterTests : ScopedTest
{
    private readonly Inverter _inverter;

    public InverterTests(DependencyInjectionFixture fixture) : base(fixture)
    {
        var inverterFactory = Scope.ServiceProvider.GetRequiredService<IInverterFactory>();

        _inverter = inverterFactory.Create();
    }

    [Fact]
    public void SetInputTest()
    {
        _inverter.GetOutput().Should().BeTrue();

        _inverter.SetInput(false);
        _inverter.GetOutput().Should().BeTrue();

        _inverter.SetInput(true);
        _inverter.GetOutput().Should().BeFalse();
    }
}
