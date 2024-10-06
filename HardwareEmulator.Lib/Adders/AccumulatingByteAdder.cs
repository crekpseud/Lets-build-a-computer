using HardwareEmulator.Lib.Factories.AddersFactories;
using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Memory;

namespace HardwareEmulator.Lib.Adders;

public class AccumulatingByteAdder
{
    private readonly ByteAdder _byteAdder;

    private readonly ByteLatch _byteLatch;

    public AccumulatingByteAdder(IByteAdderfactory byteAdderFactory, IByteLatchFactory byteLatchFactory)
    {
        _byteAdder = byteAdderFactory.Create();

        _byteLatch = byteLatchFactory.Create();
    }

    public void SetInputs(bool clock, byte byteToAdd)
    {
        _byteAdder.SetInputs(byteToAdd, _byteLatch.GetOutput());

        _byteLatch.SetInputs(clock, _byteAdder.GetSumOutput());
    }

    public byte GetSumOutput()
    {
        return _byteLatch.GetOutput();
    }
}
