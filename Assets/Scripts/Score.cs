using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public Text textScore;
	public int score = 0;
	public float deltaTime = 0.3f;

	public void UpdateScore(int rowsNumber)
	{
		switch (rowsNumber)
		{
			case 1:
				score += rowsNumber * 40;
				break;
			case 2:
				score += rowsNumber * 100;
				break;
			case 3:
				score += rowsNumber * 300;
				break;
			default:
				score += rowsNumber * 1200;
				break;
		}



		float newDelta = (0.3f - score / 5000f);

		if (newDelta > 0)
			deltaTime = newDelta;

		textScore.text = score.ToString();
	}

}
