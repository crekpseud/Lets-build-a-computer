using FluentAssertions;
using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib.Factories.AddersFactories;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HardwareEmulator.Test.AddersTests;
public class SixteenBitAdderTest : ScopedTest
{
    private readonly ITestOutputHelper _output;

    private readonly SixteenBitAdder _sixteenBitAdder;

    private readonly IRelayFactory _relayFactory;

    public SixteenBitAdderTest(DependencyInjectionFixture fixture, ITestOutputHelper output)
        : base(fixture)
    {
        _output = output;

        var sixteenBitAdderFactory = Scope.ServiceProvider.GetRequiredService<ISixteenBitAdderFactory>();

        _sixteenBitAdder = sixteenBitAdderFactory.Create();

        _relayFactory = Scope.ServiceProvider.GetRequiredService<IRelayFactory>();
    }

    [Fact]
    public void Add()
    {
        var firstNumber = new[]
        {
            false, false, false, false,
            false, false, true, false,
            false, false, false, true,
            false, false, false, false,
        };

        var secondNumber = new[]
        {
            false, true, false, false,
            false, false, true, false,
            false, false, false, false,
            false, false, false, false,
        };

        var expectedResult = new[]
        {
            false,
            false, true, false, false,
            false, true, false, false,
            false, false, false, true,
            false, false, false, false,
        };

        _sixteenBitAdder.SetInputs(false, firstNumber, secondNumber);

        var res = _sixteenBitAdder.GetFullOut();

        res.Should().BeEquivalentTo(expectedResult, options => options.WithStrictOrdering());

        _output.WriteLine($"16-bit adder total relay count: {_relayFactory.RelayCount}");
    }
}
