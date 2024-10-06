using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IRAM16x8Factory
{
    public RAM16x8 Create();

    public RAM16x8[] CreateArray(int count);
}

public class RAM16x8Factory : IRAM16x8Factory
{
    private readonly IFourToSixteenDecoderFactory _decoderFactory;
    private readonly ILevelTriggeredDtypeFlipFlopFactory _flipFlopFactory;
    private readonly IAndGateFactory _andGateFactory;
    private readonly ITriStateFactory _triStateFactory;
    private readonly ITriStateBufferFactory _triStateBufferFactory;

    public RAM16x8Factory(
        IFourToSixteenDecoderFactory decoderFactory,
        ILevelTriggeredDtypeFlipFlopFactory flipFlopFactory,
        IAndGateFactory andGateFactory,
        ITriStateFactory triStateFactory,
        ITriStateBufferFactory triStateBufferFactory)
    {
        _decoderFactory = decoderFactory;
        _flipFlopFactory = flipFlopFactory;
        _andGateFactory = andGateFactory;
        _triStateFactory = triStateFactory;
        _triStateBufferFactory = triStateBufferFactory;
    }

    public RAM16x8 Create()
    {
        return new RAM16x8(_decoderFactory, _flipFlopFactory, _andGateFactory, _triStateFactory, _triStateBufferFactory);
    }

    public RAM16x8[] CreateArray(int count)
    {
        var rams = new RAM16x8[count];

        for (int i = 0; i < count; i++)
        {
            rams[i] = Create();
        }

        return rams;
    }
}
