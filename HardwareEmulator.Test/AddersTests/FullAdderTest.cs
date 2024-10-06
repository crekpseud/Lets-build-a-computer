using FluentAssertions;
using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.AddersFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.AddersTests;

public class FullAdderTest : ScopedTest
{
    private readonly FullAdder _fullAdder;

    public FullAdderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var fullAdderFactory = Scope.ServiceProvider.GetRequiredService<IFullAdderFactory>();

        _fullAdder = fullAdderFactory.Create();
    }

    [Fact]
    public void Add()
    {
        _fullAdder.SetInputs(false, false, false);
        _fullAdder.GetSumOut().Should().BeFalse();
        _fullAdder.GetCarryOut().Should().BeFalse();

        _fullAdder.SetInputs(false, false, true);
        _fullAdder.GetSumOut().Should().BeTrue();
        _fullAdder.GetCarryOut().Should().BeFalse();

        _fullAdder.SetInputs(false, true, false);
        _fullAdder.GetSumOut().Should().BeTrue();
        _fullAdder.GetCarryOut().Should().BeFalse();

        _fullAdder.SetInputs(false, true, true);
        _fullAdder.GetSumOut().Should().BeFalse();
        _fullAdder.GetCarryOut().Should().BeTrue();

        _fullAdder.SetInputs(true, false, false);
        _fullAdder.GetSumOut().Should().BeTrue();
        _fullAdder.GetCarryOut().Should().BeFalse();

        _fullAdder.SetInputs(true, false, true);
        _fullAdder.GetSumOut().Should().BeFalse();
        _fullAdder.GetCarryOut().Should().BeTrue();

        _fullAdder.SetInputs(true, true, false);
        _fullAdder.GetSumOut().Should().BeFalse();
        _fullAdder.GetCarryOut().Should().BeTrue();

        _fullAdder.SetInputs(true, true, true);
        _fullAdder.GetSumOut().Should().BeTrue();
        _fullAdder.GetCarryOut().Should().BeTrue();
    }
}
