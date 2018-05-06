using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] tetromino;

	void Start () {
        CreateRandomTetramino();
	}
	
    public void CreateRandomTetramino(){
        Instantiate(tetromino[Random.Range(0, tetromino.Length)], 
                    new Vector3(6, 22, 0), Quaternion.identity);
    }
}
