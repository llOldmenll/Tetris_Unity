using System.Collections;
using UnityEngine;

public class GridPlayground : MonoBehaviour
{
	public static float deltaX = 1;
	public static float deltaY = 3;
	public static int rows = 10;
	public static int columns = 28;
	public static bool[,] cellState;

	public static bool UpdateCellState()
	{
		cellState = new bool[rows, columns];
		bool isValide = true;

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GameCube"))
		{
			int x = (int)obj.transform.position.x - 1;
			int y = (int)obj.transform.position.y - 3;
			//Debug.Log("X: " + x);
			//Debug.Log("Y: " + y);

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


	public static void DeleteFullLines()
	{
		ArrayList fullLines = new ArrayList();

		for (int i = 0; i < columns; i++)
		{
			bool isRowFull = true;
			for (int j = 0; j < rows; j++)
			{
				isRowFull &= cellState[j, i];
			}
			if (isRowFull)
				fullLines.Add(i);
		}
        

		for (int i = 0; i < fullLines.Count; i++)
		{
			foreach (GameObject cube in GameObject.FindGameObjectsWithTag("GameCube"))
			{
				if ((int)fullLines[i] == (int)cube.transform.position.y - 3)
					Destroy(cube);
			}

			foreach (GameObject cube in GameObject.FindGameObjectsWithTag("GameCube"))
			{
				int y = (int)cube.transform.position.y - 3;
				if ((int)fullLines[i] < y)
				{
					cube.transform.position += Vector3.down;
				}
			}

			for (int j = 0; j < fullLines.Count; j++)
				fullLines[j] = (int)fullLines[j] - 1;
		}

		if (fullLines.Count > 0)
			GameObject.FindGameObjectWithTag("Score")
					  .GetComponent<Score>()
					  .UpdateScore(fullLines.Count);

	}
}