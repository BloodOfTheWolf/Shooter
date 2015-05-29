using UnityEngine;
using System.Collections;

public class ZombieGrenadeCollisions : MonoBehaviour 
{
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Grenade") 
		{
			Destroy (gameObject);
		}
	}
}
