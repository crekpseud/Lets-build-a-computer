using HardwareEmulator.Lib.Factories.AddersFactories;

namespace HardwareEmulator.Lib.Adders;

public class SixteenBitAdder
{
    private readonly EightBitAdder _mostSignificantAdder;

    private readonly EightBitAdder _leastSignificantAdder;

    public SixteenBitAdder(IEightBitAdderFactory eightBitAdderFactory)
    {
        _mostSignificantAdder = eightBitAdderFactory.Create();
        _leastSignificantAdder = eightBitAdderFactory.Create();
    }

    public void SetInputs(bool carryIn, bool[] firstNumber, bool[] secondNumber)
    {
        _leastSignificantAdder.SetInputs(carryIn, firstNumber[8..16], secondNumber[8..16]);
        _mostSignificantAdder.SetInputs(_leastSignificantAdder.GetCarryOut(), firstNumber[..8], secondNumber[..8]);
    }

    public bool GetCarryOut()
    {
        var res = _mostSignificantAdder.GetCarryOut();

        return res;
    }

    public bool[] GetSumOut()
    {
        var res = _mostSignificantAdder.GetSumOut()
            .Concat(_leastSignificantAdder.GetSumOut())
            .ToArray();

        return res;
    }

    public bool[] GetFullOut()
    {
        var res = new[] {GetCarryOut()}
            .Concat(GetSumOut())
            .ToArray();

        return res;
    }
}
