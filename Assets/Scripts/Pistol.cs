using UnityEngine;
using System.Collections;

public class Pistol : Weapon 
{
	public Transform muzzleTransform;
	public WeaponController player;

	public override void Fire()
	{
		if (player.playerState == 1) 
		{
						Transform cameraTransform = Camera.main.transform;
						Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);

						RaycastHit hitInfo = new RaycastHit ();
						if (Physics.Raycast (ray, out hitInfo, range)) {
								//Its a hit!
								Health health = hitInfo.collider.GetComponentInParent<Health> ();
								if (health) {
										hitInfo.rigidbody.AddExplosionForce (10f, hitInfo.point, 1f);
										health.TakeDamage (damage);
										VFXManager.Instance.Spawn ("BloodSplatter", hitInfo.point, Quaternion.identity);
								} else {
										//dust
										Quaternion rot = Quaternion.FromToRotation (Vector3.forward, hitInfo.normal);
										VFXManager.Instance.Spawn ("Dust", hitInfo.point, rot);
								}
						}

						VFXManager.Instance.Spawn ("MuzzleFlare", muzzleTransform.position, muzzleTransform.rotation);
				}
	}
}
