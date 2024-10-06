using HardwareEmulator.Lib.Factories.MemoryFactories;
using HardwareEmulator.Lib.Utils;

namespace HardwareEmulator.Lib.Memory;

public class ByteLatch
{
    private readonly EightBitLatch _eightBitLatch;

    public ByteLatch(IEightBitLatchFactory eightBitLatchFactory)
    {
        _eightBitLatch = eightBitLatchFactory.Create();
    }

    public void SetInputs(bool clock, byte inputByte)
    {
        _eightBitLatch.SetInputs(clock, Converter.ByteToBoolArray(inputByte));
    }

    public byte GetOutput()
    {
        return Converter.BoolArrayToByte(_eightBitLatch.GetOutputs());
    }
}
