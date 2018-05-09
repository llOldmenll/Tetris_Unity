using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour
{

	float counter = 0;
	ArrowBtnState btnRotate;
	ArrowBtnState btnLeft;
	ArrowBtnState btnRight;
	ArrowBtnState btnDown;
	Score score;
    
	void Start()
	{
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
		btnRotate = GameObject.FindGameObjectWithTag("BtnRotate").GetComponent<ArrowBtnState>();
		btnLeft = GameObject.FindGameObjectWithTag("BtnLeft").GetComponent<ArrowBtnState>();
		btnRight = GameObject.FindGameObjectWithTag("BtnRight").GetComponent<ArrowBtnState>();
		btnDown = GameObject.FindGameObjectWithTag("BtnDown").GetComponent<ArrowBtnState>();
	}

	void FixedUpdate()
	{
		//Debug.Log(score.deltaTime.ToString());
		counter += Time.deltaTime;
		if (counter >= score.deltaTime)
		{
			Move(Vector3.down);
			counter = 0;
		}

		ListenInput();
	}

	void ListenInput()
	{
		if (transform != null)
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
				Move(Vector3.down);
			}
			else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || btnRotate.pressed)
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
