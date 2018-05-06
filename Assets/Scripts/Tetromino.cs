using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour
{

    public float deltaTime = 0.5f;
    float pastTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if (pastTime >= deltaTime)
        {
            Move(Vector3.down);
            pastTime = 0;
        }

        ListenInput();
    }

    void ListenInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Move(Vector3.down);
        }
    }

    void Move(Vector3 step)
    {
        if (transform != null)
        {
            transform.position += step;
            if (!GridPlayground.UpdateCellState())
            {
                transform.position -= step;
                if (step == Vector3.down)
                {
                    FindObjectOfType<Spawner>().CreateRandomTetramino();
                    enabled = false;
                }
            }

        }
    }

}
