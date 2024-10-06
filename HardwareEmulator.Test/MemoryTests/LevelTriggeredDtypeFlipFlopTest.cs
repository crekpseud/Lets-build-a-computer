using FluentAssertions;
using HardwareEmulator.Lib.Memory;
using Microsoft.Extensions.DependencyInjection;
using HardwareEmulator.Lib.Factories.MemoryFactories;

namespace HardwareEmulator.Test.MemoryTests;

public class LevelTriggeredDtypeFlipFlopTest : ScopedTest
{
    private readonly LevelTriggeredDtypeFlipFlop _levelTriggeredDtypeFlipFlop;

    public LevelTriggeredDtypeFlipFlopTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var levelTriggeredDtypeFlipFlopFactory = Scope.ServiceProvider.GetRequiredService<ILevelTriggeredDtypeFlipFlopFactory>();

        _levelTriggeredDtypeFlipFlop = levelTriggeredDtypeFlipFlopFactory.Create();
    }

    [Fact]
    public void Test()
    {
        _levelTriggeredDtypeFlipFlop.GetOutput().Should().BeFalse();

        _levelTriggeredDtypeFlipFlop.SetInputs(false, true);
        _levelTriggeredDtypeFlipFlop.GetOutput().Should().BeFalse();

        _levelTriggeredDtypeFlipFlop.SetInputs(true, true);
        _levelTriggeredDtypeFlipFlop.GetOutput().Should().BeTrue();

        _levelTriggeredDtypeFlipFlop.SetInputs(false, true);
        _levelTriggeredDtypeFlipFlop.GetOutput().Should().BeTrue();

        _levelTriggeredDtypeFlipFlop.SetInputs(false, false);
        _levelTriggeredDtypeFlipFlop.GetOutput().Should().BeTrue();
    }
}
