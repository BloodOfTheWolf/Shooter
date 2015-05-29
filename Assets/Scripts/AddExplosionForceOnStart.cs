﻿using UnityEngine;
using System.Collections;

public class AddExplosionForceOnStart : MonoBehaviour 
{
	public float force = 100.0f;
	public float radius = 5.0f;
	public float upwardsModifier = 0.0f;
	public ForceMode forceMode;

	// Use this for initialization
	void Start () 
	{
		foreach (Collider col in Physics.OverlapSphere(transform.position, radius))
		{
			if(col.rigidbody != null)
			{
				col.rigidbody.AddExplosionForce(force, transform.position, radius, upwardsModifier, forceMode);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
