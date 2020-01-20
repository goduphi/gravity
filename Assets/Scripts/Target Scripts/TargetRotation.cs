using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
	private float Speed;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
	
	void Rotate()
	{
		Speed = Random.Range(-25, 25);
		gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y, Speed * Time.deltaTime);
	}
}
