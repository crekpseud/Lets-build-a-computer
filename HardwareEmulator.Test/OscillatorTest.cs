using FluentAssertions;
using HardwareEmulator.Lib;
using HardwareEmulator.Lib.Factories;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HardwareEmulator.Test;
public class OscillatorTest : ScopedTest
{
    private readonly ITestOutputHelper _output;
    private readonly Oscillator _oscillator;

    public OscillatorTest(DependencyInjectionFixture fixture, ITestOutputHelper output) : base(fixture)
    {
        _output = output;

        var oscillatorFactory = Scope.ServiceProvider.GetRequiredService<IOscillatorFactory>();

        _oscillator = oscillatorFactory.Create();
    }

    [Fact]
    public void Test()
    {
        _oscillator.GetOutput().Should().Be(true);

        _oscillator.Start(1);
        _oscillator.GetOutput().Should().Be(false);

        _oscillator.Start(1);
        _oscillator.GetOutput().Should().Be(true);

        _oscillator.Start(98);
        _oscillator.GetOutput().Should().Be(true);

        _oscillator.Start(999);
        _oscillator.GetOutput().Should().Be(false);
    }
}
