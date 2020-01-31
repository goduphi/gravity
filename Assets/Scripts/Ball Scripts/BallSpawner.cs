using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public GameObject BallPrefab;
	private GameObject TempObj;
	
	private bool Died = true;
	
	void Start()
	{
		//TempObj = Instantiate(BallPrefab, new Vector2(0f, 0f), Quaternion.identity);
	}

    // Update is called once per frame
    void Update()
    {
        if(Died)
		{
			Died = false;
			//BallPrefab.SetActive(true);
			TempObj = Instantiate(BallPrefab, new Vector2(0f, 0f), Quaternion.identity);
		}
		CheckBounds();
    }
	
	void CheckBounds()
	{
		Vector3 screenPos = Camera.main.WorldToScreenPoint(TempObj.transform.position);
		
		if(!Died)
		{
			if(screenPos.x < 0 || screenPos.y < 0 || screenPos.x > Screen.width || screenPos.y > Screen.height)
			{
				GameObject.Find("Health Bar").GetComponent<BallHealth>().Health /= 2;
				Died = true;
				Destroy(TempObj);
			}
		}
	}
}
