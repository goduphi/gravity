using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrajectory : MonoBehaviour
{
    private LineRenderer lr;
	
	void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}
	
	public void RenderTrajectoryLine(Vector3 startPos, Vector3 endPos)
	{
		lr.positionCount = 2;
		
		Vector3[] points = new Vector3[2];
		points[0] = startPos;
		points[1] = endPos;
		
		lr.SetPositions(points);
	}
	
	public void DestroyLine()
	{
		lr.positionCount = 0;
	}
}
