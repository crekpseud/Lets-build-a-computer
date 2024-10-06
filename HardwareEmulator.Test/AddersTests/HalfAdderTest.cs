using FluentAssertions;
using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.AddersFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.AddersTests;

public class HalfAdderTest : ScopedTest
{
    private readonly HalfAdder _halfAdder;

    public HalfAdderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var halfAdderFactory = Scope.ServiceProvider.GetRequiredService<IHalfAdderFactory>();

        _halfAdder = halfAdderFactory.Create();
    }

    [Fact]
    public void Add()
    {
        _halfAdder.SetInputs(false, false);
        _halfAdder.GetSumOut().Should().BeFalse();
        _halfAdder.GetCarryOut().Should().BeFalse();

        _halfAdder.SetInputs(false, true);
        _halfAdder.GetSumOut().Should().BeTrue();
        _halfAdder.GetCarryOut().Should().BeFalse();

        _halfAdder.SetInputs(true, false);
        _halfAdder.GetSumOut().Should().BeTrue();
        _halfAdder.GetCarryOut().Should().BeFalse();

        _halfAdder.SetInputs(true, true);
        _halfAdder.GetSumOut().Should().BeFalse();
        _halfAdder.GetCarryOut().Should().BeTrue();
    }
}
