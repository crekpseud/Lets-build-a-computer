using HardwareEmulator.Lib.Factories;
using HardwareEmulator.Lib.Factories.AddersFactories;
using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Factories.SelectorFactories;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareEmulator.Test;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IRelayFactory, RelayFactory>();
        services.AddScoped<ITriStateFactory, TriStateFactory>();
        services.AddScoped<ITriStateBufferFactory, TriStateBufferFactory>();

        services.AddScoped<IAndGateFactory, AndGateFactory>();
        services.AddScoped<IOrGateFactory, OrGateFactory>();
        services.AddScoped<INandGateFactory, NandGateFactory>();
        services.AddScoped<INorGateFactory, NorGateFactory>();
        services.AddScoped<IInverterFactory, InverterFactory>();
        services.AddScoped<IXorGateFactory, XorGateFactory>();

        services.AddScoped<IHalfAdderFactory, HalfAdderFactory>();
        services.AddScoped<IFullAdderFactory, FullAdderFactory>();
        services.AddScoped<INBitAdderFactory, NBitAdderFactory>();
        services.AddScoped<IEightBitAdderFactory, EightBitAdderFactory>();
        services.AddScoped<IByteAdderfactory, ByteAdderFactory>();
        services.AddScoped<ISixteenBitAdderFactory, SixteenBitAdderFactory>();
        services.AddScoped<IAccumulatingByteAdderFactory, AccumulatingByteAdderFactory>();

        services.AddScoped<IThreeToEightDecoderFactory, ThreeToEightDecoderFactory>();
        services.AddScoped<IFourToSixteenDecoderFactory, FourToSixteenDecoderFactory>();

        services.AddScoped<IOscillatorFactory, OscillatorFactory>();
        services.AddScoped<IFrequencyDividerFactory, FrequencyDividerFactory>();
        services.AddScoped<IRippleCounterFactory, RippleCounterFactory>();
        services.AddScoped<IRippleCounterWithOscillatorFactory, RippleCounterWithOscillatorFactory>();

        services.AddScoped<IRSFlipFlopFactory, RSFlipFlopFactory>();
        services.AddScoped<IFlipFlopWithClockFactory, FlipFlopWithClockFactory>();
        services.AddScoped<ILevelTriggeredDtypeFlipFlopFactory, LevelTriggeredDtypeFlipFlopFactory>();
        services.AddScoped<IEdgeTriggeredDtypeFlipFlopFactory, EdgeTriggeredDtypeFlipFlopFactory>();
        services.AddScoped<IEightBitLatchFactory, EightBitLatchFactory>();
        services.AddScoped<IByteLatchFactory, ByteLatchFactory>();
        services.AddScoped<IRAM8x1Factory, RAM8x1Factory>();
        services.AddScoped<IRAM16x8Factory, RAM16x8Factory>();
        services.AddScoped<IRAM256x8Factory, RAM256x8Factory>();
        services.AddScoped<IRAMArrayFactory, RAMArrayFactory>();

        services.AddScoped<IEightToOneSelectorFactory, EightToOneSelectorFactory>();
    }
}

public class DependencyInjectionFixture
{
    public ServiceProvider ServiceProvider { get; set; }

    public DependencyInjectionFixture()
    {
        var serviceCollection = new ServiceCollection();
        var startup = new Startup();
        startup.ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}
