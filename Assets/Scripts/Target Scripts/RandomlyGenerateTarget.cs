using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyGenerateTarget : MonoBehaviour
{
	//stores the height and width of the camera in world units
	private float hHeight;
	private float hWidth;
	
	//holds information about the target game object
	public GameObject SquareTarget;
	private GameObject TempObject;
	
	void Start()
	{
		hHeight = Camera.main.orthographicSize;
		hWidth = Camera.main.aspect * hHeight;
		StartCoroutine(RandomlyGenerate(2f, 0.5f, 2f));
	}
	
    IEnumerator RandomlyGenerate(float DestroyAfter, float SpawnAfter, float SetBound)
	{
		yield return new WaitForSeconds(SpawnAfter);
		Vector2 pos = new Vector2(Random.Range(-hHeight/SetBound, hHeight/SetBound), Random.Range(-hWidth/SetBound, hWidth/SetBound));
		TempObject = Instantiate(SquareTarget, pos, Quaternion.identity);
		Destroy(TempObject, DestroyAfter);
		StartCoroutine(RandomlyGenerate(DestroyAfter, SpawnAfter, SetBound));
	}
}
