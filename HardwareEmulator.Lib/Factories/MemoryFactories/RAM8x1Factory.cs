using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.SelectorFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IRAM8x1Factory
{
    public RAM8x1 Create();
}

public class RAM8x1Factory : IRAM8x1Factory
{
    private readonly IThreeToEightDecoderFactory _decoderFactory;
    private readonly ILevelTriggeredDtypeFlipFlopFactory _flipFlopFactory;
    private readonly IEightToOneSelectorFactory _selectorFactory;

    public RAM8x1Factory(
        IThreeToEightDecoderFactory decoderFactory,
        ILevelTriggeredDtypeFlipFlopFactory flipFlopFactory,
        IEightToOneSelectorFactory selectorFactory)
    {
        _decoderFactory = decoderFactory;
        _flipFlopFactory = flipFlopFactory;
        _selectorFactory = selectorFactory;
    }

    public RAM8x1 Create()
    {
        return new RAM8x1(_decoderFactory, _flipFlopFactory, _selectorFactory);
    }
}
