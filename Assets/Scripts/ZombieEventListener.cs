using UnityEngine;
using System.Collections;

public class ZombieEventListener : MonoBehaviour 
{
	public void OnAttackEvent()
	{
		SendMessageUpwards ("OnAttack");
	}
}