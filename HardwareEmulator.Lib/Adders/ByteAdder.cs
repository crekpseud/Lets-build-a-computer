using HardwareEmulator.Lib.Factories.AddersFactories;
using HardwareEmulator.Lib.Utils;

namespace HardwareEmulator.Lib.Adders;

public class ByteAdder
{
    private readonly EightBitAdder _eightBitAdder;

    public ByteAdder(IEightBitAdderFactory eightBitAdderFactory)
    {
        _eightBitAdder = eightBitAdderFactory.Create();
    }

    public void SetInputs(byte firstByte, byte secondByte)
    {
        var firstBoolArr = Converter.ByteToBoolArray(firstByte);

        var secondBoolArr = Converter.ByteToBoolArray(secondByte);

        _eightBitAdder.SetInputs(false, firstBoolArr, secondBoolArr);
    }

    public byte GetSumOutput()
    {
        return Converter.BoolArrayToByte(_eightBitAdder.GetSumOut());
    }

    public bool GetCarryOut()
    {
        return _eightBitAdder.GetCarryOut();
    }
}
