﻿/*
	Author: Sarker Nadir Afridi Azmi
	
	Resources used: https://www.youtube.com/watch?v=7-8nE9_FwWs
					https://answers.unity.com/questions/50391/how-to-round-a-float-to-2-dp.html
					https://www.youtube.com/watch?v=jmTUUP33GHs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	private Camera MainCamera;
	
	private Rigidbody2D rb;
	private Vector3 CursorPosition;
	private Vector3 TouchPosition;
	
	public float ForceMagnitude = 50f;
	
	//private Vector2 BallDirection;
	public Vector3 ForceDirection;
	
	//these variables determine how long the ball can bolt for
	private float BoltStart;
	private float BoltMaxRange = 0.5f;
	
	//these variables only allow the ball to move if the player pulls back with his finger
	
	
    void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		MainCamera = Camera.main;
	}
	
	void Start()
	{
		BoltStart = BoltMaxRange;
		Time.timeScale = 1f;
	}

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
		print((int)Mathf.Abs((transform.position - CursorPosition).magnitude));
		GameObject.Find("Health Bar").GetComponent<BallHealth>().ReduceLifeSpan();
    }
	
	void ChangeDirection()
	{
		//we need to convert the mouse position from screen space to world space
		CursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, MainCamera.transform.position.z));
		
		//Touch touch = Input.GetTouch(0);
		//TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, MainCamera.transform.position.z));
		
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
			
			if(BoltStart > 0)
			{
				//get the distance between the ball and the cursor
				ForceDirection = (transform.position - CursorPosition).normalized;
				//ForceDirection = (transform.position - TouchPosition).normalized;
				
				rb.AddForce(ForceDirection * ForceMagnitude, ForceMode2D.Impulse);
				
				//the bolt time is decreased so that when it reaches zero, the ball starts falling again
				BoltStart -= Time.deltaTime;
				
				print(BoltStart);
			}
			else
			{
				BoltStart = BoltMaxRange;
			}
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D target)
	{
		target.gameObject.GetComponent<TargetDamage>().Damage((int)Mathf.Abs((transform.position - CursorPosition).magnitude));
		rb.AddForce(-ForceDirection * ForceMagnitude/3, ForceMode2D.Impulse);
	}
}
