using FluentAssertions;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.LogicGatesTests;

public class OrGateTest : ScopedTest
{
    private readonly OrGate _orGate;

    public OrGateTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var orGateFactory = Scope.ServiceProvider.GetRequiredService<IOrGateFactory>();

        _orGate = orGateFactory.Create(3);
    }

    [Fact]
    public void SetInputTest()
    {
        _orGate.GetOutput().Should().BeFalse();

        _orGate.SetInput(1, true);

        _orGate.GetOutput().Should().BeTrue();

        _orGate.SetInput(2, true);

        _orGate.GetOutput().Should().BeTrue();

        _orGate.SetInput(0, true);

        _orGate.GetOutput().Should().BeTrue();

        _orGate.SetInput(1, false);

        _orGate.GetOutput().Should().BeTrue();
    }

    [Fact]
    public void SetInputsTest()
    {
        _orGate.SetInputs([false, false, false]);

        _orGate.GetOutput().Should().BeFalse();

        _orGate.SetInputs([false, true, false]);

        _orGate.GetOutput().Should().BeTrue();

        _orGate.SetInputs([true, true, true]);

        _orGate.GetOutput().Should().BeTrue();
    }
}
