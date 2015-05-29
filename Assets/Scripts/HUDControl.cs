using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDControl : MonoBehaviour 
{
	static public HUDControl HUD;
	
	public int health;
	public Text healthText;
	
	void Awake ()
	{
		HUD = this;
		healthText = GetComponent<Text> ();
		healthText.text = "Health : " + health.ToString ();
	}
	
	public void LifeChecker (int damage)
	{
		health += damage;
		healthText.text = "Health : " + health.ToString ();
	}
}