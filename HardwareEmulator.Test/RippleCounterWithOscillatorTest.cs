using HardwareEmulator.Lib.Factories;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace HardwareEmulator.Test;
public class RippleCounterWithOscillatorTest : ScopedTest
{
    private readonly IRippleCounterWithOscillatorFactory _rippleCounterFactory;

    public RippleCounterWithOscillatorTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        _rippleCounterFactory = Scope.ServiceProvider.GetRequiredService<IRippleCounterWithOscillatorFactory>();
    }

    [Theory]
    [InlineData(4)]
    [InlineData(8)]
    public void Count(int numberOfBits)
    {
        var rippleCounter = _rippleCounterFactory.Create(numberOfBits);

        rippleCounter.GetOutput().Should().Be(0);

        rippleCounter.Count((int)Math.Pow(2, numberOfBits));
        rippleCounter.GetOutput().Should().Be(0);

        rippleCounter.Count(1);
        rippleCounter.GetOutput().Should().Be(1);
        rippleCounter.Count(3);
        rippleCounter.GetOutput().Should().Be(4);
        rippleCounter.Count(2);
        rippleCounter.GetOutput().Should().Be(6);
    }
}
