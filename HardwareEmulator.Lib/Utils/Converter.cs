namespace HardwareEmulator.Lib.Utils;

internal static class Converter
{
    internal static bool[] ByteToBoolArray(byte inputByte)
    {
        var boolArr = new bool[8];

        for (int i = 0; i < 8; i++)
        {
            boolArr[i] = (inputByte & (1 << (7 - i))) != 0;
        }

        return boolArr;
    }

    internal static bool[] ByteToBoolArray(byte inputByte, int numberOfElementsInArray)
    {
        var boolArr = ByteToBoolArray(inputByte);

        var output = new bool[numberOfElementsInArray];

        Array.Copy(boolArr, boolArr.Length - numberOfElementsInArray, output, 0, numberOfElementsInArray);

        return output;
    }

    internal static bool[] IntToBoolArray(int inputInt)
    {
        var boolArr = new bool[32];

        for (int i = 0; i < 32; i++)
        {
            boolArr[i] = (inputInt & (1 << (31 - i))) != 0;
        }

        return boolArr;
    }

    internal static bool[] IntToBoolArray(int inputInt, int numberOfElementsInArray)
    {
        var boolArr = IntToBoolArray(inputInt);

        var output = new bool[numberOfElementsInArray];

        Array.Copy(boolArr, boolArr.Length - numberOfElementsInArray, output, 0, numberOfElementsInArray);

        return output;
    }

    internal static byte BoolArrayToByte(bool[] boolArr)
    {
        byte resultByte = 0;

        for (int i = 0; i < 8; i++)
        {
            if (boolArr[i])
            {
                resultByte |= (byte)(1 << (7 - i));
            }
        }

        return resultByte;
    }

    internal static int BoolArrayToInt(bool[] boolArr)
    {
        int result = 0;

        for (int i = 0; i < boolArr.Length; i++)
        {
            if (boolArr[i])
            {
                result |= 1 << (boolArr.Length - 1 - i);
            }
        }

        return result;
    }

    internal static ushort BoolArrayToShort(bool[] boolArr)
    {
        ushort result = 0;
        for (int i = 0; i < 16; i++)
        {
            if (boolArr[i])
            {
                result |= (ushort)(1 << (15-i));
            }
        }

        return result;
    }
}
