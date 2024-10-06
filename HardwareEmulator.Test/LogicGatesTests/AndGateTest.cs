using FluentAssertions;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.LogicGates;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.LogicGatesTests;
public class AndGateTest : ScopedTest
{
    private readonly AndGate _andGate;

    public AndGateTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var andGateFactory = Scope.ServiceProvider.GetRequiredService<IAndGateFactory>();

        _andGate = andGateFactory.Create(3);
    }

    [Fact]
    public void SetInputTest()
    {
        _andGate.GetOutput().Should().BeFalse();

        _andGate.SetInput(1, true);

        _andGate.GetOutput().Should().BeFalse();

        _andGate.SetInput(2, true);

        _andGate.GetOutput().Should().BeFalse();

        _andGate.SetInput(0, true);

        _andGate.GetOutput().Should().BeTrue();

        _andGate.SetInput(1, false);

        _andGate.GetOutput().Should().BeFalse();
    }

    [Fact]
    public void SetInputsTest()
    {
        _andGate.SetInputs([false, false, false]);

        _andGate.GetOutput().Should().BeFalse();

        _andGate.SetInputs([false, true, false]);

        _andGate.GetOutput().Should().BeFalse();

        _andGate.SetInputs([true, true, true]);

        _andGate.GetOutput().Should().BeTrue();
    }
}
