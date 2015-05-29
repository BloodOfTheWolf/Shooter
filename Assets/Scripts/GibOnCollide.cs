using UnityEngine;
using System.Collections;

public class GibOnCollide : MonoBehaviour
{
	public GameObject gib;
	public GameObject zombie;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Zombie"))
		    {
			Destroy (collision.gameObject);
			}
		Instantiate (gib, transform.position, transform.rotation);
		Destroy (gameObject);

	}
}