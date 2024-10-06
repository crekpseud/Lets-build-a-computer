using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Memory;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace HardwareEmulator.Test.MemoryTests;

public class EdgeTriggeredDtypeFlipFlopTest : ScopedTest
{
    private readonly EdgeTriggeredDtypeFlipFlop _edgeTriggeredDtypeFlipFlop;

    public EdgeTriggeredDtypeFlipFlopTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var edgeTriggeredDtypeFlipFlopFactory = Scope.ServiceProvider.GetRequiredService<IEdgeTriggeredDtypeFlipFlopFactory>();

        _edgeTriggeredDtypeFlipFlop = edgeTriggeredDtypeFlipFlopFactory.Create();
    }

    [Fact]
    public void Test()
    {
        _edgeTriggeredDtypeFlipFlop.SetInputs(false, false);
        _edgeTriggeredDtypeFlipFlop.GetQOutput().Should().Be(false);
        _edgeTriggeredDtypeFlipFlop.GetQbarOutput().Should().Be(true);

        _edgeTriggeredDtypeFlipFlop.SetInputs(false, true);
        _edgeTriggeredDtypeFlipFlop.GetQOutput().Should().Be(false);
        _edgeTriggeredDtypeFlipFlop.GetQbarOutput().Should().Be(true);

        _edgeTriggeredDtypeFlipFlop.SetInputs(true, true);
        _edgeTriggeredDtypeFlipFlop.GetQOutput().Should().Be(true);
        _edgeTriggeredDtypeFlipFlop.GetQbarOutput().Should().Be(false);

        _edgeTriggeredDtypeFlipFlop.SetInputs(true, false);
        _edgeTriggeredDtypeFlipFlop.GetQOutput().Should().Be(true);
        _edgeTriggeredDtypeFlipFlop.GetQbarOutput().Should().Be(false);

        _edgeTriggeredDtypeFlipFlop.SetInputs(false, false);
        _edgeTriggeredDtypeFlipFlop.GetQOutput().Should().Be(true);
        _edgeTriggeredDtypeFlipFlop.GetQbarOutput().Should().Be(false);

        _edgeTriggeredDtypeFlipFlop.SetInputs(true, true);
        _edgeTriggeredDtypeFlipFlop.GetQOutput().Should().Be(false);
        _edgeTriggeredDtypeFlipFlop.GetQbarOutput().Should().Be(true);
    }
}
