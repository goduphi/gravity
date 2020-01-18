using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour
{
	private int MAX_DAMAGE = 22;
	
	public void Damage(int DamageAmount)
	{
		if(DamageAmount > MAX_DAMAGE)
		{
			gameObject.SetActive(false);
			//INSTANTIATE EXPLODE ANIMATION
		}
	}
}
