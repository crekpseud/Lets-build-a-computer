using FluentAssertions;
using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.AddersFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.AddersTests;
public class NBitAdderTest : ScopedTest
{
    private readonly NBitAdder _nBitAdder;

    public NBitAdderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var nBitAdderFactory = Scope.ServiceProvider.GetRequiredService<INBitAdderFactory>();

        _nBitAdder = nBitAdderFactory.Create(3);
    }

    [Fact]
    public void Add()
    {
        var firstNumber = new[] { false, true, false };
        var secondNumber = new[] { false, false, true };
        _nBitAdder.SetInputs(false, firstNumber, secondNumber);
        var res = _nBitAdder.GetFullOutput();
        res.Should().BeEquivalentTo(new[] { false, false, true, true }, options => options.WithStrictOrdering());

        firstNumber = [true, true, true];
        secondNumber = [true, true, true];
        _nBitAdder.SetInputs(false, firstNumber, secondNumber);
        res = _nBitAdder.GetFullOutput();
        res.Should().BeEquivalentTo(new[] { true, true, true, false }, options => options.WithStrictOrdering());
    }
}
