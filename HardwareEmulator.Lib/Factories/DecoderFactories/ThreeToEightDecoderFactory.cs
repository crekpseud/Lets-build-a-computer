using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories.DecoderFactories;

public interface IThreeToEightDecoderFactory
{
    public ThreeToEightDecoder Create();
}

public class ThreeToEightDecoderFactory : IThreeToEightDecoderFactory
{
    private readonly IAndGateFactory _andGateFactory;
    private readonly IInverterFactory _inverterFactory;

    public ThreeToEightDecoderFactory(IAndGateFactory andGateFactory, IInverterFactory inverterFactory)
    {
        _andGateFactory = andGateFactory;
        _inverterFactory = inverterFactory;
    }
    public ThreeToEightDecoder Create()
    {
        return new ThreeToEightDecoder(_andGateFactory, _inverterFactory);
    }
}
