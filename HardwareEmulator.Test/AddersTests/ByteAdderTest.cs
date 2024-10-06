using FluentAssertions;
using HardwareEmulator.Lib.Adders;
using HardwareEmulator.Lib.Factories.AddersFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.AddersTests;

public class ByteAdderTest : ScopedTest
{
    private readonly ByteAdder _byteAdder;

    public ByteAdderTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var byteAdderFactory = Scope.ServiceProvider.GetRequiredService<IByteAdderfactory>();

        _byteAdder = byteAdderFactory.Create();
    }

    [Fact]
    public void Add()
    {
        byte byte1 = 0b_00000001;
        byte byte2 = 0b_00000011;

        _byteAdder.SetInputs(byte1, byte2);

        var sum = _byteAdder.GetSumOutput();

        sum.Should().Be(0b_00000100);
    }
}
