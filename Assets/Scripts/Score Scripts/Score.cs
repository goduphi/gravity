using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private Text ScoreText;
	public static int _score = 0;
	
    public void IncrementScore()
	{
		ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		_score += 1;
		ScoreText.text = "" + _score;
	}
}
