/*
	Author: Sarker Nadir Afridi Azmi
	
	Resources used: https://www.youtube.com/watch?v=7-8nE9_FwWs
					https://answers.unity.com/questions/50391/how-to-round-a-float-to-2-dp.html
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	public GameObject MainCamera;
	
	private Rigidbody2D rb;
	private Vector3 CursorPosition;
	
	public float ForceMagnitude = 50f;
	
	private Vector2 BallDirection;
	
	//these variables determine how long the ball can bolt for
	private float BoltStart;
	private float BoltMaxRange = 5f;
	
    void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Start()
	{
		BoltStart = BoltMaxRange;
	}

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }
	
	void ChangeDirection()
	{
		//we need to convert the mouse position from screen space to world space
		CursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, MainCamera.transform.position.z));
		
		if(Input.GetMouseButton(0))
		{	
			rb.velocity = new Vector2(0f, 0f);
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			/*
			BallDirection.x = Mathf.Abs(transform.position.x) - CursorPosition.x * Speed;
			BallDirection.y = Mathf.Abs(transform.position.y) - CursorPosition.y * Speed;
			
			rb.velocity = new Vector2(BallDirection.x, BallDirection.y);
			*/
			
			if(BoltStart != 0)
			{
				//get the distance between the ball and the cursor
				Vector3 ForceDirection = (transform.position - CursorPosition).normalized;
				
				rb.AddForce(ForceDirection * ForceMagnitude, ForceMode2D.Impulse);
				
				//the bolt time is decreased so that when it reaches zero, the ball starts falling again
				BoltStart -= Time.deltaTime;
			}
		}
	}
}
