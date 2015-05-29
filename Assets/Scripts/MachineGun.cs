using UnityEngine;
using System.Collections;

public class MachineGun : Weapon
{
	public Transform muzzleTransform;
	
	public override void Fire()
	{
		Transform cameraTransform = Camera.main.transform;
		Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);
		
		RaycastHit hitInfo = new RaycastHit ();
		if( Physics.Raycast(ray, out hitInfo, range))
		{
			//Its a hit!
			Health health = hitInfo.collider.GetComponent<Health> ();
			if(health)
			{
				hitInfo.rigidbody.AddExplosionForce(10f, hitInfo.point ,1f);
				health.TakeDamage(damage);
				VFXManager.Instance.Spawn("BloodSplatter", hitInfo.point , Quaternion.identity );
			}
			else
			{
				//dust
				Quaternion rot = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
				VFXManager.Instance.Spawn("BloodSplatter", hitInfo.point, rot);
			}
		}
		
		VFXManager.Instance.Spawn("MuzzleFlare", muzzleTransform.position, muzzleTransform.rotation);
	}
}
