using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using HardwareEmulator.Lib.Factories.SelectorFactories;
using HardwareEmulator.Lib.Selectors;

namespace HardwareEmulator.Test.SelectorTests;
public class EightToOneSelectorTest : ScopedTest
{
    private readonly EightToOneSelector _selector;

    public EightToOneSelectorTest(DependencyInjectionFixture fixture) : base(fixture)
    {
        var eightToOneSelectorFactory = Scope.ServiceProvider.GetRequiredService<IEightToOneSelectorFactory>();

        _selector = eightToOneSelectorFactory.Create();
    }

    [Fact]
    public void Test()
    {
        //empty data
        _selector.SetInputs(false, false, false, 
            [false, false, false, false, false, false, false, false]);
        _selector.GetOutput().Should().BeFalse();

        _selector.SetInputs(false, true, false,
            [false, false, false, false, false, false, false, false]);
        _selector.GetOutput().Should().BeFalse();

        _selector.SetInputs(true, true, true,
            [false, false, false, false, false, false, false, false]);
        _selector.GetOutput().Should().BeFalse();

        //nonempty data
        _selector.SetInputs(false, false, false,
            [false, false, false, false, false, false, false, true]);
        _selector.GetOutput().Should().BeTrue();

        _selector.SetInputs(false, false, true,
            [false, false, false, false, false, false, false, true]);
        _selector.GetOutput().Should().BeFalse();

        _selector.SetInputs(true, false, false,
            [false, false, false, false, false, false, false, true]);
        _selector.GetOutput().Should().BeFalse();

        _selector.SetInputs(true, false, true,
            [false, false, true, false, false, false, false, false]);
        _selector.GetOutput().Should().BeTrue();

        _selector.SetInputs(true, false, true,
            [false, false, true, false, false, false, true, true]);
        _selector.GetOutput().Should().BeTrue();

        _selector.SetInputs(true, true, true,
            [true, false, false, false, false, false, false, false]);
        _selector.GetOutput().Should().BeTrue();

        _selector.SetInputs(true, true, true,
            [true, true, true, true, true, true, true, true]);
        _selector.GetOutput().Should().BeTrue();
    }
}
