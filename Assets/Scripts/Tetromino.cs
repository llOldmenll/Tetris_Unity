using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour
{

    public float deltaTime = 0.3f;
    float counter = 0;
    public ArrowBtnState btnRotate;
    public ArrowBtnState btnLeft;
    public ArrowBtnState btnRight;
    public ArrowBtnState btnDown;

    // Use this for initialization
    void Start()
    {
        btnRotate = GameObject.FindGameObjectWithTag("BtnRotate").GetComponent<ArrowBtnState>();
        btnLeft = GameObject.FindGameObjectWithTag("BtnLeft").GetComponent<ArrowBtnState>();
        btnRight = GameObject.FindGameObjectWithTag("BtnRight").GetComponent<ArrowBtnState>();
        btnDown = GameObject.FindGameObjectWithTag("BtnDown").GetComponent<ArrowBtnState>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= deltaTime)
        {
            Move(Vector3.down);
            counter = 0;
        }

        ListenInput();
    }

    void ListenInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || btnLeft.pressed)
        {
            btnLeft.pressed = false;
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || btnRight.pressed)
        {
            btnRight.pressed = false;
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || btnDown.pressed)
        {
            btnDown.pressed = false;
            Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || btnRotate.pressed)
        {
            if (transform != null)
            {
                btnRotate.pressed = false;
                GetComponent<Rotation>().rotateRight(false);
            }
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
