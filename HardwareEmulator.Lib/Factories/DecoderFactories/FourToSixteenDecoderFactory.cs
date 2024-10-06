using HardwareEmulator.Lib.Decoders;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;

namespace HardwareEmulator.Lib.Factories.DecoderFactories;

public interface IFourToSixteenDecoderFactory
{
    public FourToSixteenDecoder Create();
}

public class FourToSixteenDecoderFactory : IFourToSixteenDecoderFactory
{
    private readonly IAndGateFactory _andGateFactory;
    private readonly IInverterFactory _inverterFactory;

    public FourToSixteenDecoderFactory(IAndGateFactory andGateFactory, IInverterFactory inverterFactory)
    {
        _andGateFactory = andGateFactory;
        _inverterFactory = inverterFactory;
    }
    public FourToSixteenDecoder Create()
    {
        return new FourToSixteenDecoder(_andGateFactory, _inverterFactory);
    }
}