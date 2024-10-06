using HardwareEmulator.Lib.Factories;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace HardwareEmulator.Test;

public class RippleCounterTest : ScopedTest
{
    private readonly IRippleCounterFactory _rippleCounterFactory;

    public RippleCounterTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        _rippleCounterFactory = Scope.ServiceProvider.GetRequiredService<IRippleCounterFactory>();
    }

    [Theory]
    [InlineData(8)]
    [InlineData(16)]
    public void Count(int numberOfBits)
    {
        var rippleCounter = _rippleCounterFactory.Create(numberOfBits);

        rippleCounter.GetOutput().Should().Be(0);

        rippleCounter.SetInput(false);
        rippleCounter.GetOutput().Should().Be(1);
        rippleCounter.SetInput(false);
        rippleCounter.GetOutput().Should().Be(1);

        rippleCounter.SetInput(true);
        rippleCounter.GetOutput().Should().Be(2);

        rippleCounter.SetInput(false);
        rippleCounter.GetOutput().Should().Be(3);

        rippleCounter.SetInput(true);
        rippleCounter.GetOutput().Should().Be(4);
        rippleCounter.SetInput(true);
        rippleCounter.GetOutput().Should().Be(4);

        //_rippleCounter.GetOutputs().Should().Be(0);
        //_rippleCounter.Count(1);
        //_rippleCounter.GetOutputs().Should().Be(1);
        //_rippleCounter.Count(3);
        //_rippleCounter.GetOutputs().Should().Be(4);
        //_rippleCounter.Count(2);
        //_rippleCounter.GetOutputs().Should().Be(6);
        //_rippleCounter.Count(250);
        //_rippleCounter.GetOutputs().Should().Be(0);
    }
}
