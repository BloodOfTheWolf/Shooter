using UnityEngine;
using System.Collections;

[AddComponentMenu("Spawn/Spawn On Button")]
public class SpawnOnButton : MonoBehaviour
{
	public GameObject objectToSpawn;
	public string buttonName = "Fire1";
	public WeaponController player;
	
	// Update is called once per frame
	void Update () 
	{
		if (player.playerState == 2)
		{
		if(Input.GetButtonDown(buttonName))
		{
			Instantiate (objectToSpawn, transform.position, transform.rotation);
		}
		}
	
	}
}
