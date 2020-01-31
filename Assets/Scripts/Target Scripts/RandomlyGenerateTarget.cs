using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyGenerateTarget : MonoBehaviour
{
	//get camera information
	private CameraInfo cam;
	
	//holds information about the target game object
	public GameObject SquareTarget;
	private GameObject TempObject;
	
	void Start()
	{
		cam = new CameraInfo();
		StartCoroutine(RandomlyGenerate(2f, 0.5f, 2f));
	}
	
    IEnumerator RandomlyGenerate(float DestroyAfter, float SpawnAfter, float SetBound)
	{
		yield return new WaitForSeconds(SpawnAfter);
		Vector2 pos = new Vector2(Random.Range(-cam.HalfCamHeightWU/SetBound, cam.HalfCamHeightWU/SetBound), Random.Range(-cam.HalfCamWidthWU/SetBound, cam.HalfCamWidthWU/SetBound));
		TempObject = Instantiate(SquareTarget, pos, Quaternion.identity);
		Destroy(TempObject, DestroyAfter);
		StartCoroutine(RandomlyGenerate(DestroyAfter, SpawnAfter, SetBound));
	}
}
