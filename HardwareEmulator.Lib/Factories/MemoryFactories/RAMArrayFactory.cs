using HardwareEmulator.Lib.Factories.DecoderFactories;
using HardwareEmulator.Lib.Factories.LogicGatesFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Factories.MemoryFactories;

public interface IRAMArrayFactory
{
    IRAMArray Create(int order);

    IRAMArray[] CreateArray(int count, int order);
}

public class RAMArrayFactory : IRAMArrayFactory
{
    private readonly IRAM16x8Factory _ram16x8Factory;
    private readonly IFourToSixteenDecoderFactory _decoderFactory;
    private readonly IAndGateFactory _andGateFactory;

    public RAMArrayFactory(
        IRAM16x8Factory ram16x8Factory,
        IFourToSixteenDecoderFactory decoderFactory,
        IAndGateFactory andGateFactory)
    {
        _ram16x8Factory = ram16x8Factory;
        _decoderFactory = decoderFactory;
        _andGateFactory = andGateFactory;
    }

    public IRAMArray Create(int order)
    {
        if (order == 1)
        {
            return _ram16x8Factory.Create();
        }

        var subArray = CreateArray(16, order - 1);

        return new RAMArray(order, _decoderFactory, subArray, _andGateFactory);
    }

    public IRAMArray[] CreateArray(int count, int order)
    {
        var ramArrays = new IRAMArray[count];

        for (int i = 0; i < count; i++)
        {
            ramArrays[i] = Create(order);
        }

        return ramArrays;
    }
}
