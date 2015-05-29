using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionDestroy : MonoBehaviour 
{
	private float timeLeft;

	// Use this for initialization
	public void Awake () 
	{
		ParticleSystem system = GetComponent<ParticleSystem> ();
		timeLeft = system.startLifetime;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0)
		{
			GameObject.Destroy (gameObject);
		}
	}
}
