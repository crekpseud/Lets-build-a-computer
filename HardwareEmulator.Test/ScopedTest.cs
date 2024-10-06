using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test;

public abstract class ScopedTest : IClassFixture<DependencyInjectionFixture>, IDisposable
{
    protected readonly IServiceScope Scope;

    protected ScopedTest(DependencyInjectionFixture fixture)
    {
        Scope = fixture.ServiceProvider.CreateScope();
    }

    public void Dispose()
    {
        Scope.Dispose();
    }
}
