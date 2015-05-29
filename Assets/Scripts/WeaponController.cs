using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	public GameObject player;
	public GameObject pistolHull;
	public GameObject pistolMunition;
	public GameObject pistolTrigger;
	public GameObject rocketLauncher;
	public int playerState = 0;

	Weapon currentWeapon;
	public Text gameWonText;

	// Use this for initialization
	void Start () 
	{
		currentWeapon = GetComponentInChildren< Weapon > ();
		Screen.lockCursor = true;
		gameWonText.text = "";

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (currentWeapon)
		{
			if (Input.GetMouseButtonDown( 0 ) )
			{
				currentWeapon.Fire();
			}

			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				playerState = 1;
				pistolHull.renderer.enabled = true;
				pistolMunition.renderer.enabled = true;
				pistolTrigger.renderer.enabled = true;
				rocketLauncher.renderer.enabled = false;
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				playerState = 2;
				pistolHull.renderer.enabled = false;
				pistolMunition.renderer.enabled = false;
				pistolTrigger.renderer.enabled = false;
				rocketLauncher.renderer.enabled = true;
			}
		}


		//if (hitByZombie)
		//{
			//GUIControl.Tables.Life(-10);
		//}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("GameEnd"))
		{
			GameWon ();
		}
	}

	void GameWon ()
	{
		Time.timeScale = 0f;
		gameWonText.text = "YOU WIN!";
	}
}
