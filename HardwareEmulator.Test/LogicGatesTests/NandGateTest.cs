using HardwareEmulator.Lib.LogicGates;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Test.LogicGatesTests;

public class NandGateTest : ScopedTest
{
    private readonly NandGate _nandGate;

    public NandGateTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var nandGateFactory = Scope.ServiceProvider.GetRequiredService<INandGateFactory>();

        _nandGate = nandGateFactory.Create(3);
    }

    [Fact]
    public void SetInputTest()
    {
        _nandGate.GetOutput().Should().BeTrue();

        _nandGate.SetInput(1, true);

        _nandGate.GetOutput().Should().BeTrue();

        _nandGate.SetInput(2, true);

        _nandGate.GetOutput().Should().BeTrue();

        _nandGate.SetInput(0, true);

        _nandGate.GetOutput().Should().BeFalse();

        _nandGate.SetInput(1, false);

        _nandGate.GetOutput().Should().BeTrue();
    }

    [Fact]
    public void SetInputsTest()
    {
        _nandGate.SetInputs([false, false, false]);

        _nandGate.GetOutput().Should().BeTrue();

        _nandGate.SetInputs([false, true, false]);

        _nandGate.GetOutput().Should().BeTrue();

        _nandGate.SetInputs([true, true, true]);

        _nandGate.GetOutput().Should().BeFalse();
    }
}
