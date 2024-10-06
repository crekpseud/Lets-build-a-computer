using FluentAssertions;
using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.AddersFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.AddersTests;
public class AccumulatingByteAdderTest : ScopedTest
{
    private readonly AccumulatingByteAdder _byteAdder;

    public AccumulatingByteAdderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var byteAdderFactory = Scope.ServiceProvider.GetRequiredService<IAccumulatingByteAdderFactory>();

        _byteAdder = byteAdderFactory.Create();
    }

    [Fact]
    public void Test()
    {
        _byteAdder.GetSumOutput().Should().Be(0);

        byte byteToAdd = 0b_00000001;

        _byteAdder.SetInputs(false, byteToAdd);
        _byteAdder.GetSumOutput().Should().Be(0);

        _byteAdder.SetInputs(true, byteToAdd);
        _byteAdder.GetSumOutput().Should().Be(0b_00000001);

        _byteAdder.SetInputs(true, byteToAdd);
        _byteAdder.GetSumOutput().Should().Be(0b_00000001);

        _byteAdder.SetInputs(false, byteToAdd);
        _byteAdder.GetSumOutput().Should().Be(0b_00000001);

        _byteAdder.SetInputs(true, byteToAdd);
        _byteAdder.GetSumOutput().Should().Be(0b_00000010);

        _byteAdder.SetInputs(false, 0b_11111101);
        _byteAdder.GetSumOutput().Should().Be(0b_00000010);

        _byteAdder.SetInputs(true, 0);
        _byteAdder.GetSumOutput().Should().Be(0b_11111111);

        _byteAdder.SetInputs(false, 0b_00000001);
        _byteAdder.GetSumOutput().Should().Be(0b_11111111);

        _byteAdder.SetInputs(true, 0);
        _byteAdder.GetSumOutput().Should().Be(0);
    }
}
