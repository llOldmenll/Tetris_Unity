using UnityEngine;
using System.Collections;

public static class GridPlayground
{
    public static float deltaX = 1;
    public static float deltaY = 3;
    public static int rows = 10;
    public static int columns = 23;
    public static bool[,] cellState;

    public static bool UpdateCellState()
    {
        cellState = new bool[rows, columns];
        bool isValide = true;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GameCube"))
        {
            int x = (int)obj.transform.position.x - 1;
            int y = (int)obj.transform.position.y - 3;

            Debug.Log("X: " + x);
            Debug.Log("Y: " + y);

            if (x >= 0 && x < rows && y >= 0 && y < columns)
            {
                if (cellState[x, y])
                    isValide = false;
                else
                    cellState[x, y] = true;
            }
            else
                isValide = false;

        }

        return isValide;
    }
}