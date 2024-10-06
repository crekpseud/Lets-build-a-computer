using HardwareEmulator.Lib.Factories.AddersFactories;

namespace HardwareEmulator.Lib.Adders;

public class NBitAdder
{
    private readonly FullAdder[] _fullAdders;

    public NBitAdder(IFullAdderFactory fullAdderFactory, int numberOfBits)
    {
        _fullAdders = fullAdderFactory.CreateArray(numberOfBits);
    }

    public void SetInputs(bool carryIn, bool[] firstNumber, bool[] secondNumber)
    {
        _fullAdders[^1].SetInputs(carryIn, firstNumber[^1], secondNumber[^1]);

        for (int i = _fullAdders.Length - 2; i >= 0; i--)
        {
            _fullAdders[i].SetInputs(_fullAdders[i + 1].GetCarryOut(), firstNumber[i], secondNumber[i]);
        }
    }

    public bool[] GetFullOutput()
    {
        var carryOut = new[] { GetCarryOut() };

        var sumOut = GetSumOut();

        var res = carryOut.Concat(sumOut).ToArray();

        return res;
    }

    public bool[] GetSumOut()
    {
        var res = new bool[_fullAdders.Length];

        for (int i = 0; i < _fullAdders.Length; i++)
        {
            res[i] = _fullAdders[i].GetSumOut();
        }

        return res;
    }

    public bool GetCarryOut()
    {
        var res = _fullAdders[0].GetCarryOut();

        return res;
    }
}
