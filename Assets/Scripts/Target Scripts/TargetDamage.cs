using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour
{
	public GameObject Explode;
	
	private int MAX_DAMAGE = 22;
	
	public void Damage(int DamageAmount)
	{
		if(DamageAmount > MAX_DAMAGE)
		{
			gameObject.SetActive(false);
			//INSTANTIATE EXPLODE ANIMATION
			Animator anim = Camera.main.GetComponent<Animator>();
			anim.SetTrigger("CameraShake");
			ExplodeOnCollision();
		}
	}
	
	void ExplodeOnCollision()
	{
		GameObject TempExplodeVar = Instantiate(Explode, transform.position, Quaternion.identity);
		TempExplodeVar.GetComponent<ParticleSystem>().Play();
		Destroy(TempExplodeVar, 1f);
	}
}
