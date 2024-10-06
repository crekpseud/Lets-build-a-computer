using FluentAssertions;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test.MemoryTests;

public class ByteLatchTest : ScopedTest
{
    private readonly ByteLatch _byteLatch;

    public ByteLatchTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var byteLatchFactory = Scope.ServiceProvider.GetRequiredService<IByteLatchFactory>();

        _byteLatch = byteLatchFactory.Create();
    }

    [Fact]
    public void Test()
    {
        byte inputByte = 0b_0000001;

        _byteLatch.SetInputs(false, inputByte);
        _byteLatch.GetOutput().Should().Be(0);

        _byteLatch.SetInputs(true, inputByte);
        _byteLatch.GetOutput().Should().Be(inputByte);

        _byteLatch.SetInputs(false, inputByte);
        _byteLatch.GetOutput().Should().Be(inputByte);

        byte newByte = 0b_10000000;

        _byteLatch.SetInputs(false, newByte);
        _byteLatch.GetOutput().Should().Be(inputByte);

        _byteLatch.SetInputs(true, newByte);
        _byteLatch.GetOutput().Should().Be(newByte);
    }
}
