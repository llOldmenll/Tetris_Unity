using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] tetromino;

	void Start () {
        CreateRandomTetramino();
	}
	
    void CreateRandomTetramino(){
        Instantiate(tetromino[Random.Range(0, tetromino.Length)], 
                    transform.position, Quaternion.identity);
    }
}
