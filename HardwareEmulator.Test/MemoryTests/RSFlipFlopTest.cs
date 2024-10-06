using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Test.MemoryTests;

public class RSFlipFlopTest : ScopedTest
{
    private readonly RSFlipFlop _rsFlipFlop;

    public RSFlipFlopTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var rsFlipFlopFactory = Scope.ServiceProvider.GetRequiredService<IRSFlipFlopFactory>();

        _rsFlipFlop = rsFlipFlopFactory.Create();
    }

    [Fact]
    public void TestFlipFlopOutputs()
    {
        _rsFlipFlop.SetInputs(false, true);
        var q = _rsFlipFlop.GetQOutput();
        var qbar = _rsFlipFlop.GetQbarOutput();
        q.Should().Be(true);
        qbar.Should().Be(false);

        _rsFlipFlop.SetInputs(true, false);
        q = _rsFlipFlop.GetQOutput();
        qbar = _rsFlipFlop.GetQbarOutput();
        q.Should().Be(false);
        qbar.Should().Be(true);

        _rsFlipFlop.SetInputs(false, false);
        var qNew = _rsFlipFlop.GetQOutput();
        var qbarNew = _rsFlipFlop.GetQbarOutput();
        qNew.Should().Be(q);
        qbarNew.Should().Be(qbar);
    }
}
