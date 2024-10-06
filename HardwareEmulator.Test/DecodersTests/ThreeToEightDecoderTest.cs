using FluentAssertions;
using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.DecodersTests;
public class ThreeToEightDecoderTest : ScopedTest
{
    private readonly ThreeToEightDecoder _decoder;

    public ThreeToEightDecoderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var decoderFactory = Scope.ServiceProvider.GetRequiredService<IThreeToEightDecoderFactory>();

        _decoder = decoderFactory.Create();
    }

    [Fact]
    public void Test()
    {
        //write = false
        _decoder.SetInputs(false, false, false, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(false, true, false, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(false, false, false, true);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(false, true, true, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(false, true, true, true);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, false, false],
            options => options.WithStrictOrdering());

        //write = true
        _decoder.SetInputs(true, false, false, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, false, true], 
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, true, false, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, false, true, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, false, true, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, false, true, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, true, true, false);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, false, true, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, false, false, true);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, false, true, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, true, false, true);
        _decoder.GetOutput().Should().BeEquivalentTo([false, false, true, false, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, false, true, true);
        _decoder.GetOutput().Should().BeEquivalentTo([false, true, false, false, false, false, false, false],
            options => options.WithStrictOrdering());

        _decoder.SetInputs(true, true, true, true);
        _decoder.GetOutput().Should().BeEquivalentTo([true, false, false, false, false, false, false, false],
            options => options.WithStrictOrdering());
    }
}
