using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
	{
		public int maxHealth;
		
		public int health;
		
		public Text healthText;
		private bool restart;
		public Text gameOverText;
		public Text restartText;
		
		// Update is called once per frame
		void Start () 
		{
			health = maxHealth;	
			healthText.text = "Health : " + health;
			restart = false;
			gameOverText.text = "";
			restartText.text = "";
		}
		
		// Use this for initialization
		public void TakeDamage ( int amount ) 
		{
			health -= amount;
			healthText.text = "Health : " + health;
			if( health <= 0)
			{
				Destroy(gameObject);
				gameOverText.text = "Game Over...";
				restartText.text = "Press R to Restart";
				restart = true;
			}
			
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
				Time.timeScale = 1.0f;
			}
		}
		
		
	}
}
