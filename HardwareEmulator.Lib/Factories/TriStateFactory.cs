namespace HardwareEmulator.Lib.Factories;

public interface ITriStateFactory
{
    public TriState Create();

    public TriState[] CreateArray(int count);

    public TriState[,] CreateGrid(int numberOfRows, int numberOfColumns);
}

public class TriStateFactory : ITriStateFactory
{
    public TriState Create()
    {
        return new TriState();
    }

    public TriState[] CreateArray(int count)
    {
        var triStates = new TriState[count];

        for (int i = 0; i < count; i++)
        {
            triStates[i] = Create();
        }

        return triStates;
    }

    public TriState[,] CreateGrid(int numberOfRows, int numberOfColumns)
    {
        TriState[,] triStateGrid = new TriState[numberOfRows, numberOfColumns];

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                triStateGrid[i, j] = Create();
            }
        }

        return triStateGrid;
    }
}
