using HardwareEmulator.Lib.LogicGates;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Test.LogicGatesTests;
public class NorGateTest : ScopedTest
{
    private readonly NorGate _norGate;

    public NorGateTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var norGateFactory = Scope.ServiceProvider.GetRequiredService<INorGateFactory>();

        _norGate = norGateFactory.Create(3);
    }

    [Fact]
    public void SetInputTest()
    {
        _norGate.GetOutput().Should().BeTrue();

        _norGate.SetInput(1, true);

        _norGate.GetOutput().Should().BeFalse();

        _norGate.SetInput(2, true);

        _norGate.GetOutput().Should().BeFalse();

        _norGate.SetInput(0, true);

        _norGate.GetOutput().Should().BeFalse();

        _norGate.SetInput(1, false);

        _norGate.GetOutput().Should().BeFalse();
    }

    [Fact]
    public void SetInputsTest()
    {
        _norGate.GetOutput().Should().BeTrue();

        _norGate.SetInputs([false, false, false]);

        _norGate.GetOutput().Should().BeTrue();

        _norGate.SetInputs([false, true, false]);

        _norGate.GetOutput().Should().BeFalse();

        _norGate.SetInputs([true, true, true]);

        _norGate.GetOutput().Should().BeFalse();
    }
}
