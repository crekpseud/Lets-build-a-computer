using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IRAM256x8Factory
{
    public RAM256x8 Create();
}

public class RAM256x8Factory : IRAM256x8Factory
{
    private readonly IFourToSixteenDecoderFactory _decoderFactory;
    private readonly IRAM16x8Factory _ramFactory;
    private readonly IAndGateFactory _andGateFactory;

    public RAM256x8Factory(
        IFourToSixteenDecoderFactory decoderFactory,
        IRAM16x8Factory ramFactory,
        IAndGateFactory andGateFactory)
    {
        _decoderFactory = decoderFactory;
        _ramFactory = ramFactory;
        _andGateFactory = andGateFactory;
    }

    public RAM256x8 Create()
    {
        return new RAM256x8(_decoderFactory, _ramFactory, _andGateFactory);
    }
}
