using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMovement : MonoBehaviour
{
	private CameraInfo cam;
	private float Speed = 5f;
	
    // Start is called before the first frame update
    void Start()
    {
        cam = new CameraInfo();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlank();
    }
	
	void MovePlank()
	{
		Vector3 temp = transform.position;
		
		transform.position = temp;
	}
}
