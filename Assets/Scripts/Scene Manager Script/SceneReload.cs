using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
	private Text NewScore;
	
	void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		NewScore = GameObject.Find("Score").GetComponent<Text>();
		NewScore.text = "" + Score._score;
	}

	public void ReplayGame()
	{
		SceneManager.LoadScene("MainGameplay");
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
