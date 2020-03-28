/*
	Author: Sarker Nadir Afridi Azmi
	
	Resources used: https://www.youtube.com/watch?v=7-8nE9_FwWs
					https://answers.unity.com/questions/50391/how-to-round-a-float-to-2-dp.html
					https://www.youtube.com/watch?v=jmTUUP33GHs
					https://www.youtube.com/watch?v=Tsha7rp58LI&t=827s
					https://unity3d.college/2017/07/03/using-vector3-reflect-to-cheat-ball-bouncing-physics-in-unity/
					
					*SHOWVIK INPUT
					*Show aim direction
					*Change Menu Size
					*Increase Time
					*Add something like a red item which will kill player
					
					*MY INPUT
					*Fix direction
					*Implement Save Game
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
	private Vector3 lastKnownVelocity;


	public float ForceMagnitude = 1f;
	private float ForceReductionFactor = 2f;
	
	//private Vector2 BallDirection;
	public Vector3 ForceDirection;
	
	//these variables determine how long the ball can bolt for
	private float BoltStart;
	private float BoltMaxRange = 0.5f;
	private float BallSpeed = 10f;
	
	//these variables only allow the ball to move if the player pulls back with his finger
	private Vector3 startPos;
	
	private LineTrajectory lt;
	
    void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		MainCamera = Camera.main;
		lt = GetComponent<LineTrajectory>();
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
		lastKnownVelocity = rb.velocity;

	}
	
	void ChangeDirection()
	{
		//we need to convert the mouse position from screen space to world space
		CursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, MainCamera.transform.position.z));
		
		//Touch touch = Input.GetTouch(0);
		//CursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, MainCamera.transform.position.z));
		
		if(Input.GetMouseButtonDown(0))
		{
			startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			startPos.z = CursorPosition.z;
		}
		
		if(Input.GetMouseButton(0))
		{
			rb.velocity = new Vector2(0f, 0f);
			lt.RenderTrajectoryLine(transform.position, transform.position + (startPos - CursorPosition));
		}
		
		if(Input.GetMouseButtonUp(0) && Mathf.Abs((startPos - CursorPosition).magnitude) > 0)
		{
			lt.DestroyLine();
			
			if(BoltStart > 0)
			{
				//get the distance between the ball and the cursor
				ForceDirection = (startPos - CursorPosition).normalized/ForceReductionFactor;
				//ForceDirection = (transform.position - TouchPosition).normalized/ForceReductionFactor;
				
				rb.AddForce(ForceDirection * ForceMagnitude, ForceMode2D.Impulse);
				
				//the bolt time is decreased so that when it reaches zero, the ball starts falling again
				BoltStart -= Time.deltaTime;
			}
			else
			{
				BoltStart = BoltMaxRange;
			}
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Base")
		{
			// Retrieve the last known velocity/speed
			float speed = lastKnownVelocity.magnitude;
			// Use Vector3.Reflect, to create a reflection about a normal point
			// We need to provide the normal at the point of contact
			// To get the normal at the point of contact, use GetContact
			// When normalized, a vector keeps the same direction but its length is 1.0.
			// https://docs.unity3d.com/ScriptReference/Vector3.Reflect.html
			Vector3 direction = Vector3.Reflect(lastKnownVelocity.normalized, target.GetContact(0).normal);
			rb.velocity = direction * Mathf.Max(speed, BallSpeed);
		}

		if(target.gameObject.tag == "Target")
		{
			target.gameObject.GetComponent<TargetDamage>().Damage((int)Mathf.Abs((startPos - CursorPosition).magnitude));
			rb.AddForce(-ForceDirection * ForceMagnitude/3, ForceMode2D.Impulse);
			return;
		}
	}
}
