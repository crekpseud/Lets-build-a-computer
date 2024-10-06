using FluentAssertions;
using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.DecodersTests;

public class FourToSixteenDecoderTest : ScopedTest
{
    private readonly FourToSixteenDecoder _decoder;

    public FourToSixteenDecoderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var decoderFactory = Scope.ServiceProvider.GetRequiredService<IFourToSixteenDecoderFactory>();

        _decoder = decoderFactory.Create();
    }

    [Fact]
    public void Test()
    {
        _decoder.SetInputs(false, false, false, false);
        _decoder.GetOutputShort().Should().Be(0b_0000_0000_0000_0001);

        _decoder.SetInputs(true, false, false, false);
        _decoder.GetOutputShort().Should().Be(0b_0000_0000_0000_0010);

        _decoder.SetInputs(false, true, false, false);
        _decoder.GetOutputShort().Should().Be(0b_0000_0000_0000_0100);

        _decoder.SetInputs(true, true, false, false);
        _decoder.GetOutputShort().Should().Be(0b_0000_0000_0000_1000);

        _decoder.SetInputs(true, true, true, true);
        _decoder.GetOutputShort().Should().Be(0b_1000_0000_0000_0000);


    }
}
