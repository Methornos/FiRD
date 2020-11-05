using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1,1,0);

    public Maze maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
            }
        }
        Instantiate(Resources.Load("EndOfMaze", typeof(GameObject)) as GameObject, new Vector3(maze.finishPosition.x * 10 + 5, 5, maze.finishPosition.y * 10 + 5), Quaternion.identity);
    }
}