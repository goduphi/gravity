using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInfo
{
	private Camera cam = Camera.main;
    //stores the height and width of the camera in world units
	private float hHeight;
	private float hWidth;
	
	public CameraInfo()
	{
		hHeight = cam.orthographicSize;
		hWidth = cam.aspect * hHeight;
	}
	
	//Half camera height and with in world units
	public float HalfCamHeightWU
	{
		get
		{
			return this.hHeight;
		}
	}
	
	public float HalfCamWidthWU
	{
		get
		{
			return this.hWidth;
		}
	}
}
