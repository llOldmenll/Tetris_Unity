using System.Collections;
using System.Collections.Generic;
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
                    new Vector3(6, 22, 0), Quaternion.identity);
        generateNextIndex();
    }

    public void CreateRandomTetramino()
    {
        Instantiate(tetromino[nextIndex],
                    new Vector3(6, 22, 0), Quaternion.identity);
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
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("NextTetromino"))
            Destroy(obj);
        Instantiate(nextTetromino[nextIndex], preview.transform.position, Quaternion.identity);
    }
}
