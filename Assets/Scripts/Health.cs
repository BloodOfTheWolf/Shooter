using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour 
{
	public int maxHealth;

	int health;

	// Update is called once per frame
	void Start () 
	{
		health = maxHealth;
	}

	// Use this for initialization
	public void TakeDamage ( int amount ) 
	{
		health -= amount;
		if( health <= 0)
		{
			Destroy(gameObject);
		}
	}
	

}
