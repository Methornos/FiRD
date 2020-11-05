using UnityEngine;

public class MazeMP
{
    public MazeGeneratorCellMP[,] cells;
    public Vector2Int finishPosition;
}

public class MazeGeneratorCellMP
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
    public int DistanceFromStart;
}
