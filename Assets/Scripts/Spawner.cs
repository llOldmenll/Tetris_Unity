using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public GameObject[] tetromino;
    public GameObject[] nextTetromino;
    public GameObject preview;
    int nextIndex;


    void Start()
    {
        Instantiate(tetromino[Random.Range(0, tetromino.Length)],
                    new Vector3(6, 21, 0), Quaternion.identity);
        generateNextIndex();
    }

    public void CreateRandomTetramino()
    {
        Instantiate(tetromino[nextIndex],
                    new Vector3(6, 23, 0), Quaternion.identity);
        if (!GridPlayground.UpdateCellState())
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
        {
            GridPlayground.DeleteFullLines();
            generateNextIndex();
        }
    }


    void generateNextIndex()
    {
        nextIndex = Random.Range(0, tetromino.Length);
		Vector3 corrective = new Vector3(0, -0.2f, 0);

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("NextTetromino"))
            Destroy(obj);

		if (nextIndex == 0)
			corrective = new Vector3(0, -0.7f, 0);
		else if (nextIndex == 3)
			corrective = new Vector3(-0.2f, -0.2f, 0);

        Instantiate(nextTetromino[nextIndex], 
		            preview.transform.position + corrective, 
		            Quaternion.identity);
    }
}
