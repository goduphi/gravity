using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallHealth : MonoBehaviour
{
	public float healthValue = 100f;
	private float speed = 10f;
	private Slider health_Slider;
	
	//private GameObject UI_Holder;
    // Start is called before the first frame update
    void Start()
    {
        health_Slider = GameObject.Find("Health Bar").GetComponent<Slider>();
		health_Slider.value = healthValue;
    }

    public void ReduceLifeSpan()
	{
		healthValue -= speed * Time.deltaTime;
		
		if(healthValue < 0)
			healthValue = 0;
		
		health_Slider.value = healthValue;
		
		if(healthValue == 0)
		{
			SceneManager.LoadScene("GameOver");
		}
	}
	
	public float Health
	{
		get
		{
			return healthValue;
		}
		set
		{
			healthValue = value;
		}
	}
	
	public void AddLifeSpan()
	{
		healthValue += Random.Range(5f, 10f);
	}
}
