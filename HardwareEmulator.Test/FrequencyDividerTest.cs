using FluentAssertions;
using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HardwareEmulator.Test;

public class FrequencyDividerTest : ScopedTest
{
    private readonly ITestOutputHelper _output;
    private readonly FrequencyDivider _frequencyDivider;

    public FrequencyDividerTest(DependencyInjectionFixture fixture, ITestOutputHelper output) : base(fixture)
    {
        _output = output;

        var frequencyDividerFactory = Scope.ServiceProvider.GetRequiredService<IFrequencyDividerFactory>();

        _frequencyDivider = frequencyDividerFactory.Create();
    }

    [Fact]
    public void Test()
    {
        _frequencyDivider.GetOutput().Should().BeFalse();
        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeFalse();

        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeTrue();
        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeTrue();

        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeFalse();
        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeFalse();

        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeTrue();
        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeTrue();

        _frequencyDivider.Start(1);
        _frequencyDivider.GetOutput().Should().BeFalse();

        _frequencyDivider.Start(10);
        _frequencyDivider.GetOutput().Should().BeTrue();
    }
}
